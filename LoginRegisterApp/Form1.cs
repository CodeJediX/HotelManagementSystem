using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LoginRegisterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Ensure the password box masks the input
            txtPassword.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: Quickly verify that our DB file can be opened
            if (!Database.TestConnection())
            {
                MessageBox.Show("❌ Failed to connect to users.db. Make sure the file exists in the output folder.",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Fields",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @user AND password = @pass";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        int matchCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (matchCount > 0)
                        {
                            MessageBox.Show("✅ Login successful!", "Welcome",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            {
                                this.Hide();

                                using (var  dash= new DashBoard())
                                {
                                    dash.ShowDialog();
                                }

                                this.Close();
                            }

                        }
                        else
                        {
                            MessageBox.Show("❌ Invalid username or password.", "Login Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login:\n" + ex.Message, "Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
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
