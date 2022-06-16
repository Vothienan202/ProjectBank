using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class MoSoMoi : Form
    {
        public MoSoMoi()
        {
            InitializeComponent();
        }

        private void bt_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
