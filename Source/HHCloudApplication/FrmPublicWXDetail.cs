using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.Model.Security;
using HH.TiYu.Cloud.BLL;
using HH.TiYu.Cloud.WX;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.WinApp
{
    public partial class FrmPublicWXDetail : LJH.GeneralLibrary.Core.UI.FrmDetailBase
    {
        public FrmPublicWXDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowDBConnet(string connStr)
        {
            if (!string.IsNullOrEmpty(connStr))
            {
                try
                {
                    var sb = new SqlConnectionStringBuilder(connStr);
                    txtServer.Text = sb.DataSource;
                    txtDataBase.Text = sb.InitialCatalog;
                    if (sb.IntegratedSecurity)
                    {
                        this.rdSystem.Checked = true;
                    }
                    else
                    {
                        this.rdUser.Checked = true;
                        this.txtUserID.Text = sb.UserID;
                        this.txtPasswd.Text = sb.Password;
                    }
                }
                catch
                {
                }
            }
        }

        private string GetDBConnect()
        {
            try
            {
                var sb = new SqlConnectionStringBuilder();
                sb.DataSource = this.txtServer.Text;
                sb.InitialCatalog = this.txtDataBase.Text;
                sb.IntegratedSecurity = rdSystem.Checked;
                sb.UserID = this.txtUserID.Text;
                sb.Password = this.txtPasswd.Text;
                sb.PersistSecurityInfo = true;
                sb.ConnectTimeout = 5;
                return sb.ConnectionString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("ID不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("AppID不能为空");
                txtAppID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAppSecret.Text))
            {
                MessageBox.Show("AppSecret不能为空");
                txtAppSecret.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtToken.Text))
            {
                MessageBox.Show("Token不能为空");
                txtToken.Focus();
                return false;
            }
            return true;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.PublicWX, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            PublicWX wx = UpdatingItem as PublicWX;
            txtID.Text = wx.ID;
            txtID.Enabled = false;
            txtName.Text = wx.Name;
            txtAppID.Text = wx.AppID;
            txtAppSecret.Text = wx.AppSecret;
            txtToken.Text = wx.Token;
            txtEncodingAESKey.Text = wx.EncodingAESKey;
            ShowDBConnet(wx.DBConnect);
        }

        protected override Object GetItemFromInput()
        {
            PublicWX info = UpdatingItem as PublicWX;
            if (UpdatingItem == null)
            {
                info = new PublicWX();
                info.ID = txtID.Text;
            }
            info.Name = txtName.Text;
            if (info.AppID != txtAppID.Text || info.AppSecret != txtAppSecret.Text) //如果重新设置了APPID或APPSECRET
            {
                info.AccessToken = null;
                info.AccessTokenTime = null;
                info.AccessTokenExpireTime = null;
            }
            info.AppID = txtAppID.Text;
            info.AppSecret = txtAppSecret.Text;
            info.Token = txtToken.Text;
            info.EncodingAESKey = txtEncodingAESKey.Text;
            info.DBConnect = GetDBConnect();
            return info;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            PublicWX wx = addingItem as PublicWX;
            CommandResult ret = (new PublicWXBLL(AppSettings.Current.ConnStr)).Add(wx);
            if (ret.Result == ResultCode.Successful)
            {
                if (WXManager.Current != null) WXManager.Current.Add(wx);
            }
            return ret;
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            PublicWX wx = updatingItem as PublicWX;
            CommandResult ret = (new PublicWXBLL(AppSettings.Current.ConnStr)).Update(wx);
            if (ret.Result == ResultCode.Successful)
            {
                if (WXManager.Current != null) WXManager.Current.Add(wx);
            }
            return ret;
        }
        #endregion
    }
}
