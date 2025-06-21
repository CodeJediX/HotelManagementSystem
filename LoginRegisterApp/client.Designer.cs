namespace LoginRegisterApp
{
    partial class client
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.dataGridViewGet = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.txtDeleteID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewDelete = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewUpdate = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.txtUpdateAddress = new System.Windows.Forms.TextBox();
            this.txtUpdateLastName = new System.Windows.Forms.TextBox();
            this.txtUpdateFirstName = new System.Windows.Forms.TextBox();
            this.txtUpdateID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.adadwdw = new System.Windows.Forms.Label();
            this.adwd = new System.Windows.Forms.Label();
            this.ada = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGet)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelete)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdate)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(719, 480);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnAddClient);
            this.tabPage1.Controls.Add(this.dataGridViewGet);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(711, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Get Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(46, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 187);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clients";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(302, 69);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(277, 89);
            this.txtAddress.TabIndex = 7;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(114, 91);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(153, 22);
            this.txtFirstName.TabIndex = 6;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(114, 136);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(155, 22);
            this.txtLastName.TabIndex = 5;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(114, 41);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(155, 22);
            this.txtID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(287, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Home Address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name :";
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddClient.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClient.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddClient.Location = new System.Drawing.Point(303, 216);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(81, 30);
            this.btnAddClient.TabIndex = 9;
            this.btnAddClient.Text = "Submit";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // dataGridViewGet
            // 
            this.dataGridViewGet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGet.Location = new System.Drawing.Point(23, 270);
            this.dataGridViewGet.Name = "dataGridViewGet";
            this.dataGridViewGet.RowHeadersWidth = 51;
            this.dataGridViewGet.RowTemplate.Height = 24;
            this.dataGridViewGet.Size = new System.Drawing.Size(671, 175);
            this.dataGridViewGet.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.dataGridViewDelete);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(711, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Delete Client";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteClient);
            this.groupBox2.Controls.Add(this.txtDeleteID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Montserrat", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(95, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 149);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remove Clients";
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.BackColor = System.Drawing.Color.Red;
            this.btnDeleteClient.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteClient.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteClient.Location = new System.Drawing.Point(215, 78);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(83, 27);
            this.btnDeleteClient.TabIndex = 3;
            this.btnDeleteClient.Text = "Remove Client";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // txtDeleteID
            // 
            this.txtDeleteID.Location = new System.Drawing.Point(272, 29);
            this.txtDeleteID.Name = "txtDeleteID";
            this.txtDeleteID.Size = new System.Drawing.Size(164, 20);
            this.txtDeleteID.TabIndex = 1;
            this.txtDeleteID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Enter Client\'s ID To Remove :";
            // 
            // dataGridViewDelete
            // 
            this.dataGridViewDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDelete.Location = new System.Drawing.Point(6, 228);
            this.dataGridViewDelete.Name = "dataGridViewDelete";
            this.dataGridViewDelete.RowHeadersWidth = 51;
            this.dataGridViewDelete.RowTemplate.Height = 24;
            this.dataGridViewDelete.Size = new System.Drawing.Size(699, 217);
            this.dataGridViewDelete.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewUpdate);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(711, 451);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Update Client";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUpdate
            // 
            this.dataGridViewUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUpdate.Location = new System.Drawing.Point(12, 262);
            this.dataGridViewUpdate.Name = "dataGridViewUpdate";
            this.dataGridViewUpdate.RowHeadersWidth = 51;
            this.dataGridViewUpdate.RowTemplate.Height = 24;
            this.dataGridViewUpdate.Size = new System.Drawing.Size(679, 172);
            this.dataGridViewUpdate.TabIndex = 10;
            this.dataGridViewUpdate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdateClient);
            this.groupBox3.Controls.Add(this.txtUpdateAddress);
            this.groupBox3.Controls.Add(this.txtUpdateLastName);
            this.groupBox3.Controls.Add(this.txtUpdateFirstName);
            this.groupBox3.Controls.Add(this.txtUpdateID);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.adadwdw);
            this.groupBox3.Controls.Add(this.adwd);
            this.groupBox3.Controls.Add(this.ada);
            this.groupBox3.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(34, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(634, 232);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update Clients";
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.BackColor = System.Drawing.Color.Chartreuse;
            this.btnUpdateClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateClient.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnUpdateClient.Location = new System.Drawing.Point(256, 180);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(80, 31);
            this.btnUpdateClient.TabIndex = 8;
            this.btnUpdateClient.Text = "Update";
            this.btnUpdateClient.UseVisualStyleBackColor = false;
            // 
            // txtUpdateAddress
            // 
            this.txtUpdateAddress.Location = new System.Drawing.Point(324, 65);
            this.txtUpdateAddress.Multiline = true;
            this.txtUpdateAddress.Name = "txtUpdateAddress";
            this.txtUpdateAddress.Size = new System.Drawing.Size(282, 88);
            this.txtUpdateAddress.TabIndex = 7;
            // 
            // txtUpdateLastName
            // 
            this.txtUpdateLastName.Location = new System.Drawing.Point(119, 132);
            this.txtUpdateLastName.Name = "txtUpdateLastName";
            this.txtUpdateLastName.Size = new System.Drawing.Size(151, 23);
            this.txtUpdateLastName.TabIndex = 6;
            // 
            // txtUpdateFirstName
            // 
            this.txtUpdateFirstName.Location = new System.Drawing.Point(121, 87);
            this.txtUpdateFirstName.Name = "txtUpdateFirstName";
            this.txtUpdateFirstName.Size = new System.Drawing.Size(149, 23);
            this.txtUpdateFirstName.TabIndex = 5;
            // 
            // txtUpdateID
            // 
            this.txtUpdateID.Location = new System.Drawing.Point(119, 38);
            this.txtUpdateID.Name = "txtUpdateID";
            this.txtUpdateID.Size = new System.Drawing.Size(151, 23);
            this.txtUpdateID.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(321, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Home Address :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // adadwdw
            // 
            this.adadwdw.AutoSize = true;
            this.adadwdw.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adadwdw.Location = new System.Drawing.Point(28, 135);
            this.adadwdw.Name = "adadwdw";
            this.adadwdw.Size = new System.Drawing.Size(85, 16);
            this.adadwdw.TabIndex = 2;
            this.adadwdw.Text = "Last Name :";
            // 
            // adwd
            // 
            this.adwd.AutoSize = true;
            this.adwd.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adwd.Location = new System.Drawing.Point(28, 90);
            this.adwd.Name = "adwd";
            this.adwd.Size = new System.Drawing.Size(87, 16);
            this.adwd.TabIndex = 1;
            this.adwd.Text = "First Name :";
            // 
            // ada
            // 
            this.ada.AutoSize = true;
            this.ada.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ada.Location = new System.Drawing.Point(28, 42);
            this.ada.Name = "ada";
            this.ada.Size = new System.Drawing.Size(85, 16);
            this.ada.TabIndex = 0;
            this.ada.Text = "ID Number :";
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 525);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "client";
            this.Text = "client";
            this.Load += new System.EventHandler(this.client_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelete)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdate)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.DataGridView dataGridViewGet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.TextBox txtDeleteID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.DataGridView dataGridViewDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label adadwdw;
        private System.Windows.Forms.Label adwd;
        private System.Windows.Forms.Label ada;
        private System.Windows.Forms.DataGridView dataGridViewUpdate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateClient;
        private System.Windows.Forms.TextBox txtUpdateAddress;
        private System.Windows.Forms.TextBox txtUpdateLastName;
        private System.Windows.Forms.TextBox txtUpdateFirstName;
        private System.Windows.Forms.TextBox txtUpdateID;
    }
}