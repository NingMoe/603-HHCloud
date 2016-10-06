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
using HH.TiYu.Cloud.WX;

namespace HH.TiYu.Cloud.WinApp
{
    public partial class FrmWXCustomerMemu : Form
    {
        public FrmWXCustomerMemu()
        {
            InitializeComponent();
        }

        public PublicWX PublicWX { get; set; }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (PublicWX == null) return;
                string ret = await new WXClient().GetMenu(PublicWX);
                if (!string.IsNullOrEmpty(ret))
                {
                    this.Invoke((Action)(() => { this.txtMenu.Text = ret; }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (PublicWX == null) return;
                string menu = txtMenu.Text;
                string ret = await new WXClient().SetMenu(PublicWX, menu);
                if (!string.IsNullOrEmpty(ret))
                {
                    this.Invoke((Action)(() => { MessageBox.Show(ret); }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
