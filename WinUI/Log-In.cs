using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfMUI;

namespace WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            LoadPlayerWN.NewPlayer(usrnm_create_TB.Text, pswrd_create_TB.Text, rce_create_TB.Text, class_create_TB.Text, dscrptn_create_TB.Text, wpn_create_TB.Text);
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }
    }
}
