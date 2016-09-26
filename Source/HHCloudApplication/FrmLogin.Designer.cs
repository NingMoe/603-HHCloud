namespace HH.TiYu.Cloud.WinApp
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLogName = new System.Windows.Forms.ComboBox();
            this.chkRememberLogid = new System.Windows.Forms.CheckBox();
            this.txtPassword = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gpDB = new System.Windows.Forms.GroupBox();
            this.txtPasswd = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtUserID = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtDataBase = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtServer = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.rdSystem = new System.Windows.Forms.RadioButton();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.gpDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdvance
            // 
            this.btnAdvance.Location = new System.Drawing.Point(308, 76);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(131, 23);
            this.btnAdvance.TabIndex = 9;
            this.btnAdvance.Text = "高级>>";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLogName);
            this.groupBox3.Controls.Add(this.chkRememberLogid);
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(7, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 105);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // txtLogName
            // 
            this.txtLogName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtLogName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLogName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLogName.Location = new System.Drawing.Point(69, 20);
            this.txtLogName.MaxLength = 20;
            this.txtLogName.Name = "txtLogName";
            this.txtLogName.Size = new System.Drawing.Size(209, 20);
            this.txtLogName.TabIndex = 0;
            // 
            // chkRememberLogid
            // 
            this.chkRememberLogid.AutoSize = true;
            this.chkRememberLogid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkRememberLogid.Location = new System.Drawing.Point(194, 80);
            this.chkRememberLogid.Name = "chkRememberLogid";
            this.chkRememberLogid.Size = new System.Drawing.Size(84, 16);
            this.chkRememberLogid.TabIndex = 4;
            this.chkRememberLogid.Text = "记住登录名";
            this.chkRememberLogid.UseVisualStyleBackColor = true;
            this.chkRememberLogid.CheckedChanged += new System.EventHandler(this.chkRememberLogid_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPassword.Location = new System.Drawing.Point(69, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(209, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gpDB
            // 
            this.gpDB.Controls.Add(this.txtPasswd);
            this.gpDB.Controls.Add(this.txtUserID);
            this.gpDB.Controls.Add(this.txtDataBase);
            this.gpDB.Controls.Add(this.txtServer);
            this.gpDB.Controls.Add(this.label6);
            this.gpDB.Controls.Add(this.label5);
            this.gpDB.Controls.Add(this.label4);
            this.gpDB.Controls.Add(this.label3);
            this.gpDB.Controls.Add(this.rdUser);
            this.gpDB.Controls.Add(this.rdSystem);
            this.gpDB.Location = new System.Drawing.Point(7, 121);
            this.gpDB.Name = "gpDB";
            this.gpDB.Size = new System.Drawing.Size(436, 101);
            this.gpDB.TabIndex = 10;
            this.gpDB.TabStop = false;
            this.gpDB.Text = "数据库设置";
            // 
            // txtPasswd
            // 
            this.txtPasswd.Enabled = false;
            this.txtPasswd.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPasswd.Location = new System.Drawing.Point(281, 69);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(131, 21);
            this.txtPasswd.TabIndex = 5;
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUserID.Location = new System.Drawing.Point(75, 69);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(131, 21);
            this.txtUserID.TabIndex = 4;
            // 
            // txtDataBase
            // 
            this.txtDataBase.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDataBase.Location = new System.Drawing.Point(281, 42);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(131, 21);
            this.txtDataBase.TabIndex = 3;
            // 
            // txtServer
            // 
            this.txtServer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtServer.Location = new System.Drawing.Point(76, 42);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(131, 21);
            this.txtServer.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "数据库：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "服务器：";
            // 
            // rdUser
            // 
            this.rdUser.AutoSize = true;
            this.rdUser.Location = new System.Drawing.Point(175, 20);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(107, 16);
            this.rdUser.TabIndex = 1;
            this.rdUser.Text = "用户名密码验证";
            this.rdUser.UseVisualStyleBackColor = true;
            this.rdUser.Click += new System.EventHandler(this.rdUser_CheckedChanged);
            // 
            // rdSystem
            // 
            this.rdSystem.AutoSize = true;
            this.rdSystem.Checked = true;
            this.rdSystem.Location = new System.Drawing.Point(41, 20);
            this.rdSystem.Name = "rdSystem";
            this.rdSystem.Size = new System.Drawing.Size(95, 16);
            this.rdSystem.TabIndex = 0;
            this.rdSystem.TabStop = true;
            this.rdSystem.Text = "系统集成验证";
            this.rdSystem.UseVisualStyleBackColor = true;
            this.rdSystem.Click += new System.EventHandler(this.rdSystem_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(308, 17);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(131, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "登录(&L)";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(308, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "退出软件(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(457, 233);
            this.Controls.Add(this.btnAdvance);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gpDB);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gpDB.ResumeLayout(false);
            this.gpDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox txtLogName;
        private System.Windows.Forms.CheckBox chkRememberLogid;
        public LJH.GeneralLibrary.WinformControl.DBCTextBox txtPassword;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpDB;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPasswd;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtUserID;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtDataBase;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdUser;
        private System.Windows.Forms.RadioButton rdSystem;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.Button btnCancel;
    }
}