using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.GUI;


namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            frm.nextForm();
            //AdminForm a = new AdminForm();
            //a.ShowDialog();

        }
    }
}
