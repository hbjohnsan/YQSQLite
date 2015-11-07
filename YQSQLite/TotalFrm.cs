using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace YQSQLite
{
    public partial class TotalFrm : DockContent
    {
        private MainFrm mf;
        public TotalFrm()
        {
            InitializeComponent();
        }
        public TotalFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void TotalFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
