using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LoginRegisterApp
{
    public partial class booking_cs : Form
    {
        // Matches the Database.GetConnection() string (users.db with WAL and timeout)
        private readonly string connectionString = "Data Source=users.db;Version=3;Journal Mode=WAL;Cache=Shared;Pooling=True;BusyTimeout=5000;";

        public booking_cs()
        {
            InitializeComponent();
            // Ensure the Load event is properly wired
            this.Load += new EventHandler(this.booking_cs_Load);
        }

        // Override OnLoad as additional guarantee
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                EnableWalMode();
                EnsureRoomTableExistsAndSeed();
                EnsureReservationTableExists();
                LoadRoomGrid();
                LoadReservationGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initialization error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void booking_cs_Load(object sender, EventArgs e)
        {
            try
            {
                EnableWalMode();
                EnsureRoomTableExistsAndSeed();
                EnsureReservationTableExists();
                LoadRoomGrid();
                LoadReservationGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initialization error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableWalMode()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("PRAGMA journal_mode = WAL;", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void EnsureRoomTableExistsAndSeed()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createRoomsSql = @"
                    CREATE TABLE IF NOT EXISTS Rooms (
                        RoomID       INTEGER PRIMARY KEY,
                        RoomType     TEXT,
                        Price        DECIMAL,
                        Availability INTEGER
                    );";
                using (var cmd = new SQLiteCommand(createRoomsSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Seed with 15 rooms if empty
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Rooms;", conn))
                {
                    long count = (long)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        using (var tran = conn.BeginTransaction())
                        {
                            for (int i = 1; i <= 15; i++)
                            {
                                string roomType = (i % 3 == 1) ? "Single"
                                                 : (i % 3 == 2) ? "Double"
                                                 : "Suite";
                                decimal price = (roomType == "Single") ? 50m
                                              : (roomType == "Double") ? 80m
                                              : 120m;

                                using (var insert = new SQLiteCommand(@"
                                    INSERT INTO Rooms (RoomID, RoomType, Price, Availability)
                                    VALUES (@rid, @rtype, @price, 1);
                                ", conn, tran))
                                {
                                    insert.Parameters.AddWithValue("@rid", i);
                                    insert.Parameters.AddWithValue("@rtype", roomType);
                                    insert.Parameters.AddWithValue("@price", price);
                                    insert.ExecuteNonQuery();
                                }
                            }
                            tran.Commit();
                        }
                    }
                }
            }
        }

        private void EnsureReservationTableExists()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createResSql = @"
                    CREATE TABLE IF NOT EXISTS Reservations (
                        ReservationID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClientID      INTEGER,
                        RoomID        INTEGER,
                        CheckInDate   TEXT,
                        CheckOutDate  TEXT,
                        TotalPrice    DECIMAL,
                        FOREIGN KEY (ClientID) REFERENCES Clients(ID),
                        FOREIGN KEY (RoomID)   REFERENCES Rooms(RoomID)
                    );";
                using (var cmd = new SQLiteCommand(createResSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadRoomGrid()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Rooms;", conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewRoom.DataSource = dt;
                }
            }
        }

        private void LoadReservationGrid()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Reservations;", conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewReservations.DataSource = dt;
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtResClientID.Text.Trim(), out int clientId))
                    throw new Exception("Client ID must be an integer.");

                if (!int.TryParse(txtResRoomID.Text.Trim(), out int roomId))
                    throw new Exception("Room ID must be an integer.");

                DateTime checkIn = dtpCheckIn.Value.Date;
                DateTime checkOut = dtpCheckOut.Value.Date;

                if (checkOut <= checkIn)
                    throw new Exception("Check-out date must be after check-in date.");

                int nights = (int)(checkOut - checkIn).TotalDays;
                if (nights <= 0)
                    throw new Exception("Stay must be at least one night.");

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Verify client exists
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Clients WHERE ID = @cid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", clientId);
                        long count = (long)cmd.ExecuteScalar();
                        if (count == 0)
                            throw new Exception($"Client ID {clientId} does not exist.");
                    }

                    // Verify room exists and is available
                    decimal pricePerDay;
                    using (var cmd = new SQLiteCommand("SELECT Price, Availability FROM Rooms WHERE RoomID = @rid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", roomId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new Exception($"Room ID {roomId} does not exist.");

                            bool available = reader.GetInt32(reader.GetOrdinal("Availability")) == 1;
                            pricePerDay = reader.GetDecimal(reader.GetOrdinal("Price"));

                            if (!available)
                                throw new Exception($"Room ID {roomId} is not available.");
                        }
                    }

                    decimal totalPrice = pricePerDay * nights;

                    // Insert into Reservations
                    using (var cmd = new SQLiteCommand(@"
                        INSERT INTO Reservations 
                          (ClientID, RoomID, CheckInDate, CheckOutDate, TotalPrice)
                        VALUES
                          (@cid, @rid, @cin, @cout, @tp);
                    ", conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", clientId);
                        cmd.Parameters.AddWithValue("@rid", roomId);
                        cmd.Parameters.AddWithValue("@cin", checkIn.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@cout", checkOut.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@tp", totalPrice);
                        cmd.ExecuteNonQuery();
                    }

                    // Update room availability
                    using (var cmd = new SQLiteCommand("UPDATE Rooms SET Availability = 0 WHERE RoomID = @rid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", roomId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadRoomGrid();
                    LoadReservationGrid();

                    string receipt = $"Reservation Successful!\n\n" +
                                     $"Client ID:   {clientId}\n" +
                                     $"Room ID:     {roomId}\n" +
                                     $"Check-In:    {checkIn:yyyy-MM-dd}\n" +
                                     $"Check-Out:   {checkOut:yyyy-MM-dd}\n" +
                                     $"Nights:      {nights}\n" +
                                     $"Price/Night: {pricePerDay:C}\n" +
                                     $"Total Price: {totalPrice:C}";

                    MessageBox.Show(receipt, "Reservation Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No action needed
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // No action needed
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            // No action needed
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
