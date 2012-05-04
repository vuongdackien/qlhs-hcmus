using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTabbedMdi;

namespace QLHS_THPT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm1 f = new XtraForm1();
            f.MdiParent = this;
            f.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /*
              // Create a BarManager that will display a bar of commands at the top of the main form.
            BarManager barManager = new BarManager();
            barManager.Form = this;
            // Create a bar with a New button.
            barManager.BeginUpdate();
            Bar bar = new Bar(barManager, "My Bar");
            bar.DockStyle = BarDockStyle.Top;
            barManager.MainMenu = bar;
            BarItem barItem = new BarButtonItem(barManager, "New");
            barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick);
            bar.ItemLinks.Add(barItem);
            barManager.EndUpdate();
            // Create an XtraTabbedMdiManager that will manage MDI child windows.
        }

        int ctr = 0;
        void barItem_ItemClick(object sender, ItemClickEventArgs e) {
            // Create an MDI child form.
            XtraForm1 f = new XtraForm1();
            f.Text = "Child Form " + (++ctr).ToString();
            f.MdiParent = this;
            f.Show();
        }*/
        }
    }
}