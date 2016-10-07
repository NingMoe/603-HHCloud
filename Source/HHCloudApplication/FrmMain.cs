using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.BLL;
using HH.TiYu.Cloud.WX;
using HH.TiYu.Cloud.WinApp.Host;

namespace HH.TiYu.Cloud.WinApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private Dictionary<Form, string> _openedForms = new Dictionary<Form, string>();
        private bool _EnableSoftDog = false; //启用加密狗
        private DateTime _ExpireDate = new DateTime(2016, 1, 31);
        #endregion

        #region 私有方法
        private void DoLogIn()
        {

            DialogResult ret = DialogResult.Cancel;
            ret = (new FrmLogin()).ShowDialog();
            if (ret == DialogResult.OK)
            {
                //ShowOperatorRights();
                //if (_openedForms != null && _openedForms.Count > 0)
                //{
                //    foreach (Form frm in _openedForms.Keys)
                //    {
                //        if (frm is IOperatorRender)
                //        {
                //            (frm as IOperatorRender).ShowOperatorRights();
                //        }
                //    }
                //}
                //this.lblOperator.Text = Operator.Current.Name;
            }
            else
            {
                Environment.Exit(0);
            }
        }


        #endregion

        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text += string.Format(" [{0}]", Application.ProductVersion);
            DoLogIn();
            WXManager.Current = new WXManager(AppSettings.Current.ConnStr);
            WXManager.Current.Init();
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(AppSettings.Current.ConnStr);
            SelfHostServer.StartWebApiService();
        }
        #endregion

        private void btnPublicWX_Click(object sender, EventArgs e)
        {
            FrmPublicWXMaster frm = new FrmPublicWXMaster();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
