using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LoginRegisterApp
{
    public partial class rooms : Form
    {
        // Same connection string as your booking form
        private readonly string connectionString =
            "Data Source=users.db;Version=3;Journal Mode=WAL;Cache=Shared;Pooling=True;BusyTimeout=5000;";

        public rooms()
        {
            InitializeComponent();

            // Hook up the Load event for this form
            this.Load += rooms_Load;

            // Hook up the click event for the Delete button
            this.btnDelete.Click += btnDelete_Click;
        }

        private void rooms_Load(object sender, EventArgs e)
        {
            try
            {
                EnableWalMode();
                EnsureReservationTableExists();
                LoadReservationGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Initialization error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
                    dataGridViewReservationsDelete.DataSource = dt;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtResIDToDelete.Text.Trim(), out int resId))
                    throw new Exception("Reservation ID must be a valid integer.");

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // 1) Verify that the Reservation exists, and grab its RoomID
                    int roomId;
                    using (var cmd = new SQLiteCommand(
                        "SELECT RoomID FROM Reservations WHERE ReservationID = @rid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", resId);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                            throw new Exception($"Reservation ID {resId} does not exist.");

                        roomId = Convert.ToInt32(result);
                    }

                    // 2) Delete the reservation row
                    using (var cmd = new SQLiteCommand(
                        "DELETE FROM Reservations WHERE ReservationID = @rid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", resId);
                        cmd.ExecuteNonQuery();
                    }

                    // 3) Update that Room’s availability back to 1
                    using (var cmd = new SQLiteCommand(
                        "UPDATE Rooms SET Availability = 1 WHERE RoomID = @roomid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@roomid", roomId);
                        cmd.ExecuteNonQuery();
                    }

                    // 4) Refresh the grid so the user immediately sees the change
                    LoadReservationGrid();

                    MessageBox.Show(
                        $"Reservation ID {resId} was deleted.\nRoom ID {roomId} is now available.",
                        "Deletion Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Deletion error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Stub, in case the Designer wired this up automatically; no logic needed here.
        private void dataGridViewReservationsDelete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No action required
        }

        // (Optional) If you have a GroupBox or other container in your Designer, you can keep its Enter event stub:
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // No action required
        }
    }
}
