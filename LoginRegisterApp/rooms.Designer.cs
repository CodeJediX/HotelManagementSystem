namespace LoginRegisterApp
{
    partial class rooms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResID = new System.Windows.Forms.Label();
            this.txtResIDToDelete = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewReservationsDelete = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservationsDelete)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(63, 52);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(250, 19);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Enter Reservation ID to delete :";
            // 
            // txtResIDToDelete
            // 
            this.txtResIDToDelete.Location = new System.Drawing.Point(319, 52);
            this.txtResIDToDelete.Name = "txtResIDToDelete";
            this.txtResIDToDelete.Size = new System.Drawing.Size(151, 23);
            this.txtResIDToDelete.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(504, 47);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 33);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridViewReservationsDelete
            // 
            this.dataGridViewReservationsDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservationsDelete.Location = new System.Drawing.Point(28, 110);
            this.dataGridViewReservationsDelete.Name = "dataGridViewReservationsDelete";
            this.dataGridViewReservationsDelete.RowHeadersWidth = 51;
            this.dataGridViewReservationsDelete.RowTemplate.Height = 24;
            this.dataGridViewReservationsDelete.Size = new System.Drawing.Size(636, 342);
            this.dataGridViewReservationsDelete.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewReservationsDelete);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.txtResIDToDelete);
            this.groupBox1.Controls.Add(this.lblResID);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 490);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete Reservation";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 525);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "rooms";
            this.Text = "rooms";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservationsDelete)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.TextBox txtResIDToDelete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewReservationsDelete;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}