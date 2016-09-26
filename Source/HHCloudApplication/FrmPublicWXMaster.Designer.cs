namespace HH.TiYu.Cloud.WinApp
{
    partial class FrmPublicWXMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RoleView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMnu_Fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMnu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppSecret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEncodingAESKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccessToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccessTokenExpireTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RoleView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoleView
            // 
            this.RoleView.AllowUserToAddRows = false;
            this.RoleView.AllowUserToDeleteRows = false;
            this.RoleView.AllowUserToResizeRows = false;
            this.RoleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colAppID,
            this.colAppSecret,
            this.colToken,
            this.colEncodingAESKey,
            this.colAccessToken,
            this.colAccessTokenExpireTime});
            this.RoleView.ContextMenuStrip = this.contextMenuStrip1;
            this.RoleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleView.Location = new System.Drawing.Point(0, 0);
            this.RoleView.Name = "RoleView";
            this.RoleView.RowHeadersVisible = false;
            this.RoleView.RowTemplate.Height = 23;
            this.RoleView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleView.Size = new System.Drawing.Size(1113, 393);
            this.RoleView.TabIndex = 60;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMnu_Fresh,
            this.cMnu_Add,
            this.cMnu_Delete,
            this.cMnu_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 92);
            // 
            // cMnu_Fresh
            // 
            this.cMnu_Fresh.Name = "cMnu_Fresh";
            this.cMnu_Fresh.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Fresh.Text = "刷新";
            // 
            // cMnu_Add
            // 
            this.cMnu_Add.Name = "cMnu_Add";
            this.cMnu_Add.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Add.Text = "新建";
            // 
            // cMnu_Delete
            // 
            this.cMnu_Delete.Name = "cMnu_Delete";
            this.cMnu_Delete.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Delete.Text = "删除";
            // 
            // cMnu_Export
            // 
            this.cMnu_Export.Name = "cMnu_Export";
            this.cMnu_Export.Size = new System.Drawing.Size(109, 22);
            this.cMnu_Export.Text = "导出...";
            this.cMnu_Export.Visible = false;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 100;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.DataPropertyName = "RoleName";
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 100;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colAppID
            // 
            this.colAppID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAppID.HeaderText = "AppID";
            this.colAppID.MinimumWidth = 100;
            this.colAppID.Name = "colAppID";
            this.colAppID.ReadOnly = true;
            // 
            // colAppSecret
            // 
            this.colAppSecret.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAppSecret.HeaderText = "AppSecret";
            this.colAppSecret.MinimumWidth = 100;
            this.colAppSecret.Name = "colAppSecret";
            this.colAppSecret.ReadOnly = true;
            // 
            // colToken
            // 
            this.colToken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colToken.HeaderText = "Token";
            this.colToken.MinimumWidth = 100;
            this.colToken.Name = "colToken";
            this.colToken.ReadOnly = true;
            // 
            // colEncodingAESKey
            // 
            this.colEncodingAESKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEncodingAESKey.HeaderText = "EncodingAESKey";
            this.colEncodingAESKey.MinimumWidth = 150;
            this.colEncodingAESKey.Name = "colEncodingAESKey";
            this.colEncodingAESKey.ReadOnly = true;
            this.colEncodingAESKey.Width = 150;
            // 
            // colAccessToken
            // 
            this.colAccessToken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAccessToken.HeaderText = "AccessToken";
            this.colAccessToken.MinimumWidth = 250;
            this.colAccessToken.Name = "colAccessToken";
            this.colAccessToken.ReadOnly = true;
            this.colAccessToken.Width = 250;
            // 
            // colAccessTokenExpireTime
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.colAccessTokenExpireTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAccessTokenExpireTime.FillWeight = 200F;
            this.colAccessTokenExpireTime.HeaderText = "AccessToken过期";
            this.colAccessTokenExpireTime.Name = "colAccessTokenExpireTime";
            this.colAccessTokenExpireTime.ReadOnly = true;
            this.colAccessTokenExpireTime.Width = 200;
            // 
            // FrmPublicWXMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 415);
            this.Controls.Add(this.RoleView);
            this.Name = "FrmPublicWXMaster";
            this.Text = "微信公众号管理";
            this.Controls.SetChildIndex(this.RoleView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RoleView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RoleView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Fresh;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Add;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Delete;
        private System.Windows.Forms.ToolStripMenuItem cMnu_Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppSecret;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEncodingAESKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessTokenExpireTime;
    }
}