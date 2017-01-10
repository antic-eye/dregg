namespace dregg_gui
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckServer = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lbMilestones = new System.Windows.Forms.ListBox();
            this.txt = new System.Windows.Forms.RichTextBox();
            this.tabsOptions = new System.Windows.Forms.TabControl();
            this.tabRelease = new System.Windows.Forms.TabPage();
            this.tabHotfix = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.numRevision = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQueryTickets = new System.Windows.Forms.Button();
            this.lbTickets = new System.Windows.Forms.ListBox();
            this.tabsOptions.SuspendLayout();
            this.tabRelease.SuspendLayout();
            this.tabHotfix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRevision)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Milestone(s)";
            // 
            // btnCheckServer
            // 
            this.btnCheckServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckServer.Location = new System.Drawing.Point(75, 6);
            this.btnCheckServer.Name = "btnCheckServer";
            this.btnCheckServer.Size = new System.Drawing.Size(194, 23);
            this.btnCheckServer.TabIndex = 5;
            this.btnCheckServer.Text = "Get Milestones";
            this.btnCheckServer.UseVisualStyleBackColor = true;
            this.btnCheckServer.Click += new System.EventHandler(this.btnCheckServer_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(374, 360);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(210, 88);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Generate CSV";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "User";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::dregg_gui.Properties.Settings.Default.CLosedOnly;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::dregg_gui.Properties.Settings.Default, "CLosedOnly", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(6, 306);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Get only closed entries";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dregg_gui.Properties.Settings.Default, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPassword.Location = new System.Drawing.Point(80, 58);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(285, 20);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.Text = global::dregg_gui.Properties.Settings.Default.Password;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dregg_gui.Properties.Settings.Default, "User", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUser.Location = new System.Drawing.Point(80, 32);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(285, 20);
            this.txtUser.TabIndex = 8;
            this.txtUser.Text = global::dregg_gui.Properties.Settings.Default.User;
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dregg_gui.Properties.Settings.Default, "RpcUri", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtServer.Location = new System.Drawing.Point(80, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(504, 20);
            this.txtServer.TabIndex = 2;
            this.txtServer.Text = global::dregg_gui.Properties.Settings.Default.RpcUri;
            // 
            // lbMilestones
            // 
            this.lbMilestones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMilestones.FormattingEnabled = true;
            this.lbMilestones.Location = new System.Drawing.Point(6, 35);
            this.lbMilestones.Name = "lbMilestones";
            this.lbMilestones.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMilestones.Size = new System.Drawing.Size(263, 251);
            this.lbMilestones.TabIndex = 14;
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt.Location = new System.Drawing.Point(374, 32);
            this.txt.Name = "txt";
            this.txt.ReadOnly = true;
            this.txt.Size = new System.Drawing.Size(210, 322);
            this.txt.TabIndex = 15;
            this.txt.Text = "";
            // 
            // tabsOptions
            // 
            this.tabsOptions.Controls.Add(this.tabRelease);
            this.tabsOptions.Controls.Add(this.tabHotfix);
            this.tabsOptions.Location = new System.Drawing.Point(80, 93);
            this.tabsOptions.Name = "tabsOptions";
            this.tabsOptions.SelectedIndex = 0;
            this.tabsOptions.Size = new System.Drawing.Size(283, 355);
            this.tabsOptions.TabIndex = 16;
            // 
            // tabRelease
            // 
            this.tabRelease.Controls.Add(this.btnCheckServer);
            this.tabRelease.Controls.Add(this.label2);
            this.tabRelease.Controls.Add(this.checkBox1);
            this.tabRelease.Controls.Add(this.lbMilestones);
            this.tabRelease.Location = new System.Drawing.Point(4, 22);
            this.tabRelease.Name = "tabRelease";
            this.tabRelease.Padding = new System.Windows.Forms.Padding(3);
            this.tabRelease.Size = new System.Drawing.Size(275, 329);
            this.tabRelease.TabIndex = 0;
            this.tabRelease.Text = "New Release";
            this.tabRelease.UseVisualStyleBackColor = true;
            // 
            // tabHotfix
            // 
            this.tabHotfix.Controls.Add(this.lbTickets);
            this.tabHotfix.Controls.Add(this.btnQueryTickets);
            this.tabHotfix.Controls.Add(this.label6);
            this.tabHotfix.Controls.Add(this.numRevision);
            this.tabHotfix.Controls.Add(this.label5);
            this.tabHotfix.Location = new System.Drawing.Point(4, 22);
            this.tabHotfix.Name = "tabHotfix";
            this.tabHotfix.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotfix.Size = new System.Drawing.Size(275, 329);
            this.tabHotfix.TabIndex = 1;
            this.tabHotfix.Text = "New Hotfix";
            this.tabHotfix.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Revision number:";
            // 
            // numRevision
            // 
            this.numRevision.Location = new System.Drawing.Point(101, 61);
            this.numRevision.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numRevision.Name = "numRevision";
            this.numRevision.Size = new System.Drawing.Size(117, 20);
            this.numRevision.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 53);
            this.label6.TabIndex = 2;
            this.label6.Text = "Enter the revision number of the Hotfix. The number will be used in the name i.e." +
    " enter \"1234\" and the tool will search for HF1234 in the tags of tickets.";
            // 
            // btnQueryTickets
            // 
            this.btnQueryTickets.Location = new System.Drawing.Point(225, 58);
            this.btnQueryTickets.Name = "btnQueryTickets";
            this.btnQueryTickets.Size = new System.Drawing.Size(43, 23);
            this.btnQueryTickets.TabIndex = 3;
            this.btnQueryTickets.Text = "???";
            this.btnQueryTickets.UseVisualStyleBackColor = true;
            this.btnQueryTickets.Click += new System.EventHandler(this.btnQueryTickets_Click);
            // 
            // lbTickets
            // 
            this.lbTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTickets.FormattingEnabled = true;
            this.lbTickets.Location = new System.Drawing.Point(6, 91);
            this.lbTickets.Name = "lbTickets";
            this.lbTickets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbTickets.Size = new System.Drawing.Size(263, 225);
            this.lbTickets.TabIndex = 15;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 453);
            this.Controls.Add(this.tabsOptions);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Dregg RN-Generator";
            this.tabsOptions.ResumeLayout(false);
            this.tabRelease.ResumeLayout(false);
            this.tabRelease.PerformLayout();
            this.tabHotfix.ResumeLayout(false);
            this.tabHotfix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRevision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckServer;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox lbMilestones;
        private System.Windows.Forms.RichTextBox txt;
        private System.Windows.Forms.TabControl tabsOptions;
        private System.Windows.Forms.TabPage tabRelease;
        private System.Windows.Forms.TabPage tabHotfix;
        private System.Windows.Forms.NumericUpDown numRevision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnQueryTickets;
        private System.Windows.Forms.ListBox lbTickets;
    }
}

