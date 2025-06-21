using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LoginRegisterApp
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        private void client_Load(object sender, EventArgs e)
        {
            try
            {
                // Load data into all DataGridViews when form loads
                LoadAllClients();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error during form load", ex);
            }
        }

        // Tab 1 - Get Details functionality
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName?.Text?.Trim() ?? "";
                string lastName = txtLastName?.Text?.Trim() ?? "";
                string address = txtAddress?.Text?.Trim() ?? "";

                // Validate input fields
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("Please enter both first name and last name.", "Missing Fields",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Clients (FirstName, LastName, Address) VALUES (@firstName, @lastName, @address)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@address", address);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Client added successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear input fields
                            ClearAddClientFields();

                            // Refresh all DataGridViews
                            LoadAllClients();
                        }
                        else
                        {
                            MessageBox.Show("❌ Failed to add client.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error adding client", ex);
            }
        }

        // Tab 2 - Delete Client functionality
        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                string idText = txtDeleteID?.Text?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(idText))
                {
                    MessageBox.Show("Please enter a client ID to delete.", "Missing ID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(idText, out int clientId))
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid ID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to delete client with ID {clientId}?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Clients WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", clientId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Client deleted successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear input field
                            if (txtDeleteID != null) txtDeleteID.Clear();

                            // Refresh all DataGridViews
                            LoadAllClients();
                        }
                        else
                        {
                            MessageBox.Show("❌ No client found with the specified ID.", "Not Found",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error deleting client", ex);
            }
        }

        // Tab 3 - Update Client functionality
        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {
                string idText = txtUpdateID?.Text?.Trim() ?? "";
                string firstName = txtUpdateFirstName?.Text?.Trim() ?? "";
                string lastName = txtUpdateLastName?.Text?.Trim() ?? "";
                string address = txtUpdateAddress?.Text?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(idText))
                {
                    MessageBox.Show("Please enter a client ID to update.", "Missing ID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(idText, out int clientId))
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid ID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("Please enter both first name and last name.", "Missing Fields",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Clients SET FirstName = @firstName, LastName = @lastName, Address = @address WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@id", clientId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Client updated successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear input fields
                            ClearUpdateClientFields();

                            // Refresh all DataGridViews
                            LoadAllClients();
                        }
                        else
                        {
                            MessageBox.Show("❌ No client found with the specified ID.", "Not Found",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error updating client", ex);
            }
        }

        // Helper method to load all clients into DataGridViews
        private void LoadAllClients()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, FirstName, LastName, Address FROM Clients ORDER BY ID";
                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable clientsTable = new DataTable();
                        adapter.Fill(clientsTable);

                        // Update all DataGridViews with the same data
                        SafeSetDataSource(dataGridViewGet, clientsTable.Copy());
                        SafeSetDataSource(dataGridViewDelete, clientsTable.Copy());
                        SafeSetDataSource(dataGridViewUpdate, clientsTable.Copy());

                        // Configure DataGridView appearance after a short delay
                        System.Threading.Thread.Sleep(100); // Allow columns to be created
                        ConfigureDataGridViews();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error loading clients", ex);
            }
        }

        // Safe method to set DataSource
        private void SafeSetDataSource(DataGridView dgv, DataTable dataTable)
        {
            try
            {
                if (dgv != null)
                {
                    dgv.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error setting data source for {dgv?.Name ?? "DataGridView"}", ex);
            }
        }

        // Configure DataGridView properties for better user experience
        private void ConfigureDataGridViews()
        {
            try
            {
                ConfigureSingleDataGridView(dataGridViewGet);
                ConfigureSingleDataGridView(dataGridViewDelete);
                ConfigureSingleDataGridView(dataGridViewUpdate);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error configuring DataGridViews", ex);
            }
        }

        private void ConfigureSingleDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            try
            {
                // Check if DataSource is not null and has data
                if (dgv.DataSource == null || dgv.Columns.Count == 0)
                    return;

                // Wait for columns to be fully initialized
                Application.DoEvents();

                // Check and configure ID column
                if (HasColumn(dgv, "ID"))
                {
                    dgv.Columns["ID"].ReadOnly = true;
                    dgv.Columns["ID"].Width = 50;
                    dgv.Columns["ID"].HeaderText = "Client ID";
                }

                // Check and configure FirstName column
                if (HasColumn(dgv, "FirstName"))
                {
                    dgv.Columns["FirstName"].Width = 100;
                    dgv.Columns["FirstName"].HeaderText = "First Name";
                }

                // Check and configure LastName column
                if (HasColumn(dgv, "LastName"))
                {
                    dgv.Columns["LastName"].Width = 100;
                    dgv.Columns["LastName"].HeaderText = "Last Name";
                }

                // Check and configure Address column
                if (HasColumn(dgv, "Address"))
                {
                    dgv.Columns["Address"].Width = 200;
                    dgv.Columns["Address"].HeaderText = "Address";
                }

                // Set general DataGridView properties
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error configuring DataGridView {dgv.Name}", ex);
            }
        }

        // Safe method to check if column exists
        private bool HasColumn(DataGridView dgv, string columnName)
        {
            try
            {
                return dgv != null && dgv.Columns != null && dgv.Columns.Contains(columnName);
            }
            catch
            {
                return false;
            }
        }

        // Helper methods to clear input fields
        private void ClearAddClientFields()
        {
            try
            {
                if (txtID != null) txtID.Clear();
                if (txtFirstName != null) txtFirstName.Clear();
                if (txtLastName != null) txtLastName.Clear();
                if (txtAddress != null) txtAddress.Clear();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error clearing add client fields", ex);
            }
        }

        private void ClearUpdateClientFields()
        {
            try
            {
                if (txtUpdateID != null) txtUpdateID.Clear();
                if (txtUpdateFirstName != null) txtUpdateFirstName.Clear();
                if (txtUpdateLastName != null) txtUpdateLastName.Clear();
                if (txtUpdateAddress != null) txtUpdateAddress.Clear();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error clearing update client fields", ex);
            }
        }

        // Event handlers for DataGridView selection to populate update fields
        private void dataGridViewUpdate_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUpdate?.SelectedRows?.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewUpdate.SelectedRows[0];

                    if (txtUpdateID != null && HasColumn(dataGridViewUpdate, "ID"))
                        txtUpdateID.Text = selectedRow.Cells["ID"].Value?.ToString() ?? "";

                    if (txtUpdateFirstName != null && HasColumn(dataGridViewUpdate, "FirstName"))
                        txtUpdateFirstName.Text = selectedRow.Cells["FirstName"].Value?.ToString() ?? "";

                    if (txtUpdateLastName != null && HasColumn(dataGridViewUpdate, "LastName"))
                        txtUpdateLastName.Text = selectedRow.Cells["LastName"].Value?.ToString() ?? "";

                    if (txtUpdateAddress != null && HasColumn(dataGridViewUpdate, "Address"))
                        txtUpdateAddress.Text = selectedRow.Cells["Address"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error in update selection change", ex);
            }
        }

        private void dataGridViewDelete_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDelete?.SelectedRows?.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridViewDelete.SelectedRows[0];

                    if (txtDeleteID != null && HasColumn(dataGridViewDelete, "ID"))
                        txtDeleteID.Text = selectedRow.Cells["ID"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error in delete selection change", ex);
            }
        }

        // Centralized error handling method
        private void ShowErrorMessage(string context, Exception ex)
        {
            try
            {
                string errorMessage = $"Error in {context}:\n\n{ex.Message}\n\nApplication will continue running.";
                MessageBox.Show(errorMessage, "Error - Application Continues",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                // Last resort - if even showing error message fails
                try
                {
                    MessageBox.Show("A critical error occurred, but application will continue running.",
                                   "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    // Do nothing - prevent infinite error loops
                }
            }
        }

        // Existing event handlers (keeping them as placeholders)
        private void label1_Click(object sender, EventArgs e)
        {
            // Keep existing implementation if needed
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Keep existing implementation if needed
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Keep existing implementation if needed
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Keep existing implementation if needed
        }
    }
}
