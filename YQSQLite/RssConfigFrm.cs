using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace YQSQLite
{
    public partial class RssConfigFrm : Form
    {
        private MainFrm mf;
        public RssConfigFrm()
        {
            InitializeComponent();
        }
        public RssConfigFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void RssConfigFrm_Load(object sender, EventArgs e)
        {
            mfLoad();

        }

        private void mfLoad()
        {
            int selectshow=0;
            switch (mf.configyq.uptime)
            {
                case 15:
                    selectshow = 0;
                    break;
                case 30:
                    selectshow = 1;
                    break;
                case 60:
                    selectshow = 2;
                    break;
                case 120:
                    selectshow = 3;
                    break;
                case 240:
                    selectshow = 4;
                    break;
                case 360:
                    selectshow = 5;
                    break;
                case 720:
                    selectshow = 6;
                    break;
                case 1440:
                    selectshow = 7;
                    break;
            }
            combTime.SelectedIndex = selectshow;
        }
    }
}
