using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.Model.Security;
using HH.TiYu.Cloud.BLL;
using HH.TiYu.Cloud.WebApi;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.WinApp
{
    public partial class FrmPublicWXMaster : LJH.GeneralLibrary.Core.UI.FrmMasterBase
    {
        public FrmPublicWXMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法及事件处理
        protected override LJH.GeneralLibrary.Core.UI.FrmDetailBase GetDetailForm()
        {
            return new FrmPublicWXDetail();
        }

        protected override bool DeletingItem(object item)
        {
            PublicWXBLL bll = new PublicWXBLL(AppSettings.Current.ConnStr);
            PublicWX info = item as PublicWX;
            CommandResult result = bll.Delete(info);
            if (result.Result == ResultCode.Successful)
            {
                if (WXManager.Current != null) WXManager.Current.Remove(info);
            }
            else
            {
                MessageBox.Show(result.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            List<PublicWX> items = null;
            PublicWXBLL bll = new PublicWXBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                items = bll.GetItems(null).QueryObjects.ToList();
            }
            else
            {
                items = bll.GetItems(SearchCondition).QueryObjects.ToList();
            }
            if (items != null && items.Count > 0) return items.Select(it => (object)it).ToList();
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PublicWX info = item as PublicWX;
            row.Tag = item;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colName"].Value = info.Name;
            row.Cells["colAppID"].Value = info.AppID;
            row.Cells["colAppSecret"].Value = info.AppSecret;
            row.Cells["colToken"].Value = info.Token;
            row.Cells["colEncodingAESKey"].Value = info.EncodingAESKey;
            row.Cells["colAccessToken"].Value = info.AccessToken;
            row.Cells["colAccessTokenExpireTime"].Value = info.AccessTokenExpireTime;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.PublicWX, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.PublicWX, PermissionActions.Edit);
            cMnu_Export.Enabled = Operator.Current.Permit(Permission.PublicWX, PermissionActions.Export);
        }
        #endregion
    }
}
