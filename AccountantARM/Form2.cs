using System;
using System.Windows.Forms;

namespace AccountantARM
{
    public partial class Form2 : Form
    {
        string[] mass = null;
        DataBase db;
        public Form2()
        {
            InitializeComponent();
            db = new DataBase();
            mass = db.getLasTaxes();
            showVal();
        }

        private void showVal()
        {
            pdfoTB.Text = mass[0];
            militaryTB.Text = mass[1];
            esvTB.Text = mass[2];
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            if (pdfoTB.Text == "" || militaryTB.Text == "" || esvTB.Text == "")
            {
                MessageBox.Show("Заповнiть всi поля");
                return;
            }            
            db.addTaxes(Double.Parse(pdfoTB.Text), Double.Parse(militaryTB.Text), Double.Parse(esvTB.Text));
            MessageBox.Show("OK");
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            showVal();
        }

        private void TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // && (sender as TextBox).Text.Length > 0

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' && ((sender as TextBox).Text.IndexOf(',') > -1)) ||
                ((e.KeyChar == ',') && (sender as TextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }
    }
}
