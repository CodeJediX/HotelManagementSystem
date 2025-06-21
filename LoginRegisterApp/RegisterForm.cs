using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LoginRegisterApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            txtNewPassword.UseSystemPasswordChar = true;
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter both username and password.",
                                "Missing Fields",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string insertSql = "INSERT INTO users (username, password) VALUES (@user, @pass)";
                    using (var cmd = new SQLiteCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", newUsername);
                        cmd.Parameters.AddWithValue("@pass", newPassword);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("✅ Account created successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                // SQLITE_CONSTRAINT (19) indicates a UNIQUE violation on username
                if (ex.ResultCode == SQLiteErrorCode.Constraint)
                {
                    MessageBox.Show("⚠️ Username already exists. Please choose a different one.",
                                    "Duplicate Username",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error while creating account:\n" + ex.Message,
                                    "Database Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void backlogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var login = new Form1())
            {
                login.ShowDialog();
            }

            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
