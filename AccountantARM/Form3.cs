using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountantARM
{
    public partial class Form3 : Form
    {
        DataBase db = new DataBase();
        List<int> peopleID = new List<int>();
        List<int> salList = new List<int>();
        public Form3()
        {
            InitializeComponent();
            peopleCB.SelectedIndex = 0;
            foreach (Employee em in db.getEmployees())
            {
                peopleID.Add(em.ID);
                peopleCB.Items.Add(em.Position + ": " + em.Surname + " " + em.Firstname[0] + ". " + em.Secondname[0] + ".");
                salList.Add(em.Salary);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if(peopleCB.SelectedIndex == 0)
            {
                try
                {
                    db.wagesDor(dateTP.Value, 0, 0);
                    MessageBox.Show("OK");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("У вибраному мiсяцi всі отримали зарплату");
                }
                return;
            }

            string[] mas = db.checkID(dateTP.Value, peopleID[peopleCB.SelectedIndex - 1]);
            if (mas.Length != 0)
            {
                string messageText = "Робiтнику, у вибраному мiсяци, вже була нарахована зарплатня за такими датами: " 
                    + Convert.ToDateTime(mas[0]).ToShortDateString();
                for (int i = 1; i < mas.Length; i++)
                    messageText += "; " + Convert.ToDateTime(mas[i]).ToShortDateString();
                messageText += "." + Environment.NewLine + "Ви впевнені, що бажаєте видати зарплату знову?";
                DialogResult result = MessageBox.Show(messageText, peopleCB.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.wagesDor(dateTP.Value, peopleID[peopleCB.SelectedIndex - 1], salList[peopleCB.SelectedIndex - 1]);
                    MessageBox.Show("OK");
                }
            }
            else
            {
                db.wagesDor(dateTP.Value, peopleID[peopleCB.SelectedIndex - 1], salList[peopleCB.SelectedIndex - 1]);
                MessageBox.Show("OK");
            }           
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
