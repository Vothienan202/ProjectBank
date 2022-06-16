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
    public partial class GuiTietKiem : Form
    {

        public Form currentForm;

        public GuiTietKiem()
        {
            InitializeComponent();
        }

        public void OpenForm(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            p_form.Controls.Add(form);
            p_form.Tag = form;
            form.BringToFront();
            form.Show();

        }



        private void bt_MoSoMoi_Click(object sender, EventArgs e)
        {
            OpenForm(new MoSoMoi());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new RutTienGui());
        }
    }
}
