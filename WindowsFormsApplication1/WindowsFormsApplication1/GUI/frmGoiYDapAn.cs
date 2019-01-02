using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Object;
namespace WindowsFormsApplication1.GUI
{
    public partial class frmGoiYDapAn : Form
    {
        public frmGoiYDapAn(List<string> dapan)
        {
            InitializeComponent();
            List<GoiYDapAn> list = new List<GoiYDapAn>();
            for( int i = 0; i < dapan.Count;i++)
            {
                GoiYDapAn a = new GoiYDapAn
                {
                    dapan = dapan[i],
                    socau = "Cau " + (i + 1).ToString()
                };
                list.Add(a);
            }
            dgvGoiY.DataSource = list;
        }
    }
}
