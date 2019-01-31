using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AccountantARM
{
    public partial class Form1 : Form
    {
        private bool showEditing = false, showMoreInfo = false, clearRows = false, showFilter = false;
        private int table = 0;
        private DataBase db = new DataBase();
        private List<CalculationOfTaxes> ctList = new List<CalculationOfTaxes>();
        public Form1()
        {
            InitializeComponent();
            moreInfoBtn.Visible = false;
            showData();
        }
        
        private DataGridViewColumn[] createColumns()
        {
            DataGridViewColumn[] result = null;
            if (table == 0)
            {
                DataGridViewTextBoxColumn id, surn, firs, secn, date, posit, salary, sex;
                id = new DataGridViewTextBoxColumn
                {
                    Visible = false,
                    ReadOnly = true,
                    HeaderText = "ID"
                };
                surn = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Прізвище"                    
                };
                firs = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Ім'я"
                };
                secn = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "По батькові"
                };
                sex = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Стать"
                };
                date = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Дата народження"
                };
                posit = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Посада"
                };
                salary = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Оклад"
                };
                result = new DataGridViewColumn[] { id, surn, firs, secn, sex, date, posit, salary };
            }
            else
            {
                DataGridViewTextBoxColumn id, idEmp, fio, date, salary, NDFL, Military, ESV, Total;
                id = new DataGridViewTextBoxColumn
                {
                    Visible = false,
                    ReadOnly = true,
                    HeaderText = "ID"
                };
                idEmp = new DataGridViewTextBoxColumn
                {
                    Visible = false,
                    ReadOnly = true,
                    HeaderText = "ID"
                };
                salary = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Оклад"
                };
                date = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Дата нарахування"
                };
                fio = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "ПIБ"
                };
                NDFL = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "ПДФО"
                };
                Military = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "Військовий збір"
                };
                ESV = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "ЄСВ"
                };
                Total = new DataGridViewTextBoxColumn
                {
                    ReadOnly = true,
                    HeaderText = "До виплати"
                };
                result = new DataGridViewColumn[] { id, idEmp, fio, date, salary, NDFL, Military, ESV, Total };
            }
            return result;
        }

        private void showData()
        {
            clearRows = true;
            dGV.Rows.Clear();
            clearRows = false;
            dGV.Columns.Clear();
            dGV.Columns.AddRange(createColumns());
            if (table == 0)
                foreach (Employee em in db.getEmployees())
                    dGV.Rows.Add(em.ID, em.Surname, em.Firstname, em.Secondname, em.Sex, em.DateBirth, em.Position, em.Salary);
            else
            {
                ctList = new List<CalculationOfTaxes>();
                foreach (CalculationOfTaxes ct in db.getCalculationOfTaxes())
                {
                    ctList.Add(ct);
                    dGV.Rows.Add(ct.ID, ct.IDEmp, ct.FIO, ct.DateIssue, ct.Salary, ct.PDFO, ct.Military, ct.ESV, ct.Total);                    
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void filterBtnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshFilter();
            showFilter = !showFilter;
            filterPanel.Visible = showFilter;
        }

        private void dGV_SelectionChanged(object sender, EventArgs e)
        {
            if (clearRows) return;
            if (!addCheckMode.Checked && table == 0)
            {
                addValueToChangeFiels();
            }
            if(table == 1)
            {
                
                moreInfoValToPanel();
            }
        }

        private void moreInfoValToPanel()
        {
            int index = dGV.CurrentRow.Index;
            fioTB.Text = ctList[index].FIO;
            salaryIssTB.Text = ctList[index].Salary.ToString();
            dateIssTB.Text = ctList[index].DateIssue;
            pdfoTB.Text = ctList[index].pdfoInfo();
            militaryTB.Text = ctList[index].militaryInfo();
            esvTB.Text = ctList[index].ESVInfo();
            resultTB.Text = ctList[index].totalInfo();
        }

        private void addValueToChangeFiels()
        {
            int index = dGV.CurrentRow.Index;
            indexTB.Text = dGV[0, index].Value.ToString();
            surnameTB.Text = dGV[1, index].Value.ToString();
            fristnameTB.Text = dGV[2, index].Value.ToString();
            secondnameTB.Text = dGV[3, index].Value.ToString();
            sexCB.Text = dGV[4, index].Value.ToString();
            dateBirthDTP.Value = Convert.ToDateTime(dGV[5, index].Value.ToString());
            positionTB.Text = dGV[6, index].Value.ToString();
            salaryTB.Text = dGV[7, index].Value.ToString();
        }

        private void addCheckMode_CheckedChanged(object sender, EventArgs e)
        {
            if (addCheckMode.Checked)
            {
                clearAddData();
                changeAddBtn.Text = "Додати";
            }
            else
            {
                addValueToChangeFiels();
                changeAddBtn.Text = "Змiнити";
            }
        }

        private void clearAddData()
        {
            surnameTB.Text = "";
            fristnameTB.Text = "";
            secondnameTB.Text = "";
            dateBirthDTP.Value = DateTime.Now;
            positionTB.Text = "";
            salaryTB.Text = "";
        }

        private void refreshValBtn_Click(object sender, EventArgs e)
        {
            if (addCheckMode.Checked)
            {
                clearAddData();
            }
            else
            {
                addValueToChangeFiels();
            }
        }

        private void changeAddBtn_Click(object sender, EventArgs e)
        {
            if(surnameTB.Text.Trim() == "" || fristnameTB.Text.Trim() == "" || 
                secondnameTB.Text.Trim() == "" || positionTB.Text.Trim() == "" || salaryTB.Text.Trim() == "")
            {
                MessageBox.Show("Заповнiть всi поля.");
                return;
            }
            if (addCheckMode.Checked)
            {
                bool sex = false;
                if (sexCB.Text == "М")
                    sex = true;
                db.add(new Employee
                {
                    ID = -1,
                    Surname = surnameTB.Text.Trim(),
                    Firstname = fristnameTB.Text.Trim(),
                    Secondname = secondnameTB.Text.Trim(),
                    Sex = sex.ToString(),
                    DateBirth = dateBirthDTP.Value.ToString(),
                    Position = positionTB.Text.Trim(),
                    Salary = Convert.ToInt32(salaryTB.Text)
                });
                clearAddData();
                showData();
            }
            else
            {
                bool sex = false;
                if (sexCB.Text == "М")
                    sex = true;
                db.update(new Employee
                {
                    ID = Convert.ToInt32(indexTB.Text),
                    Surname = surnameTB.Text.Trim(),
                    Firstname = fristnameTB.Text.Trim(),
                    Secondname = secondnameTB.Text.Trim(),
                    Sex = sex.ToString(),
                    DateBirth = dateBirthDTP.Value.ToString(),
                    Position = positionTB.Text.Trim(),
                    Salary = Convert.ToInt32(salaryTB.Text)
                });
                showData();
                addValueToChangeFiels();
            }
            MessageBox.Show("OK");
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            showData();
            if (showFilter)
                filtration();
            MessageBox.Show("OK");
        }

        private void salaryTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void employeesBtn_Click(object sender, EventArgs e)
        {
            table = 0;
            editinShowBtn.Visible = true;
            editAddPanel.Visible = showEditing;
            moreInfoPanel.Visible = false;
            moreInfoBtn.Visible = false;
            showData();
            refreshFilter();
        }               

        private void salaryBtn_Click(object sender, EventArgs e)
        {
            table = 1;
            moreInfoBtn.Visible = true;
            moreInfoPanel.Visible = showMoreInfo;
            editinShowBtn.Visible = false;
            editAddPanel.Visible = false;
            showData();
            refreshFilter();
        }

        private void forThisMonth_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void exportBtnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGV.Rows.Count == 0)
            {
                MessageBox.Show("Немає записів");
                return;
            }
            Excel.Application excelapp = new Excel.Application();
            Excel.Range excelcells;
            Excel.Workbooks excelappworkbooks;
            Excel.Workbook excelappworkbook;
            Excel.Sheets excelsheets;
            Excel.Worksheet excelworksheet;
            try
            {
                //Открытие и создание книги               
                excelapp.SheetsInNewWorkbook = 1;
                excelapp.Workbooks.Add(Type.Missing);

                excelappworkbooks = excelapp.Workbooks;
                excelappworkbook = excelappworkbooks[1];

                excelsheets = excelappworkbook.Worksheets;
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);


                int numberOfRows = 1, i = 0;
                excelcells = excelworksheet.get_Range("A" + numberOfRows.ToString(), "G" + numberOfRows.ToString());
                excelcells.Merge(Type.Missing);
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "Робiтники";
                if(table == 1)
                    excelcells.Value = "Видана зарплатня";
                excelcells.Font.Bold = true;
                numberOfRows += 2;

                excelcells = excelworksheet.get_Range("A" + numberOfRows.ToString(), "A" + numberOfRows.ToString());
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "Прізвище";
                if (table == 1)
                    excelcells.Value = "ПIБ";
                excelcells.Font.Bold = true;
                excelcells = excelworksheet.get_Range("B" + numberOfRows.ToString(), "B" + numberOfRows.ToString());
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "Ім'я";
                if (table == 1)
                    excelcells.Value = "Дата видачi";
                excelcells.Font.Bold = true;
                excelcells = excelworksheet.get_Range("C" + numberOfRows.ToString(), "C" + numberOfRows.ToString());
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "По батькові";
                if (table == 1)
                    excelcells.Value = "Оклад";
                excelcells.Font.Bold = true;
                excelcells = excelworksheet.get_Range("D" + numberOfRows.ToString(), "D" + numberOfRows.ToString());
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "Стать";
                if (table == 1)
                    excelcells.Value = "ПДФО";
                excelcells.Font.Bold = true;
                excelcells = excelworksheet.get_Range("E" + numberOfRows.ToString(), "E" + numberOfRows.ToString());
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "Дата народження";
                if (table == 1)
                    excelcells.Value = "Військовий збір";
                excelcells.Font.Bold = true;
                excelcells = excelworksheet.get_Range("F" + numberOfRows.ToString(), "F" + numberOfRows.ToString());
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "Посада";
                if (table == 1)
                    excelcells.Value = "ЄСВ";
                excelcells.Font.Bold = true;
                excelcells = excelworksheet.get_Range("G" + numberOfRows.ToString(), "G" + numberOfRows.ToString());
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.Value = "Оклад";
                if (table == 1)
                    excelcells.Value = "До виплати";
                excelcells.Font.Bold = true;
                numberOfRows++;
                
                for (i = numberOfRows; i < dGV.Rows.Count + numberOfRows; i++)
                {
                    if (!dGV.Rows[i - numberOfRows].Visible)
                        continue;
                    excelcells = excelworksheet.get_Range("A" + i.ToString(), "A" + i.ToString());
                    excelcells.Value = Convert.ToString(dGV[1 + table, i - numberOfRows].Value);
                    excelcells = excelworksheet.get_Range("B" + i.ToString(), "B" + i.ToString());
                    excelcells.Value = Convert.ToString(dGV[2 + table, i - numberOfRows].Value);
                    excelcells = excelworksheet.get_Range("C" + i.ToString(), "C" + i.ToString());
                    excelcells.Value = Convert.ToString(dGV[3 + table, i - numberOfRows].Value);
                    excelcells = excelworksheet.get_Range("D" + i.ToString(), "D" + i.ToString());
                    excelcells.Value = Convert.ToString(dGV[4 + table, i - numberOfRows].Value);
                    excelcells = excelworksheet.get_Range("E" + i.ToString(), "E" + i.ToString());
                    excelcells.Value = Convert.ToString(dGV[5 + table, i - numberOfRows].Value);
                    excelcells = excelworksheet.get_Range("F" + i.ToString(), "F" + i.ToString());
                    excelcells.Value = Convert.ToString(dGV[6 + table, i - numberOfRows].Value);
                    excelcells = excelworksheet.get_Range("G" + i.ToString(), "G" + i.ToString());
                    excelcells.Value = Convert.ToString(dGV[7 + table, i - numberOfRows].Value);
                }
                i++;
                excelcells = excelworksheet.get_Range("G" + i.ToString(), "G" + i.ToString());
                excelcells.Value = "Дата: " + DateTime.Now.ToShortDateString();
                excelcells.Font.Bold = true;
                excelworksheet.Columns.AutoFit();
                excelapp.Visible = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                excelapp.Workbooks.Close();
                excelapp.Quit();
            }
        }

        private void refreshFiltBtn_Click(object sender, EventArgs e)
        {
            refreshFilter();
            filtration();
        }
        
        private void filtration()
        {  
            if (table == 0)
            {
                for (int i = 0; i < dGV.RowCount; i++)
                {
                    dGV.Rows[i].Visible = true;
                    if (dGV[1, i].Value.ToString().ToLower().IndexOf(surFiltTB.Text.Trim().ToLower()) == -1)
                    {
                        dGV.Rows[i].Visible = false;
                        continue;
                    }
                    if(dGV[6, i].Value.ToString().ToLower().IndexOf(positionFiltTB.Text.Trim().ToLower()) == -1)
                    {
                        dGV.Rows[i].Visible = false;
                        continue;
                    }
                    if(sexFiltCB.SelectedIndex != 2)
                        if(dGV[4, i].Value.ToString() != sexFiltCB.Text)
                        {
                            dGV.Rows[i].Visible = false;
                            continue;
                        }
                    if(salFiltCB.SelectedIndex != 3 && salFiltTB.Text != "")
                        if(!checkDoubleValue(
                            Convert.ToDouble(salFiltTB.Text), 
                            Convert.ToDouble(dGV[7, i].Value.ToString()), 
                            salFiltCB.SelectedIndex
                            ))
                        {
                            dGV.Rows[i].Visible = false;
                            continue;
                        }

                    if(dateFiltCB.SelectedIndex != 3)
                        if(!checkDateValue(dateFiltTP.Value, Convert.ToDateTime(dGV[5, i].Value.ToString()), dateFiltCB.SelectedIndex))
                        {
                            dGV.Rows[i].Visible = false;
                            continue;
                        }
                }
            }
            else
            {
                for (int i = 0; i < dGV.RowCount; i++)
                {
                    dGV.Rows[i].Visible = true;
                    if (dGV[2, i].Value.ToString().ToLower().IndexOf(surFiltTB.Text.Trim().ToLower()) == -1)
                    {
                        dGV.Rows[i].Visible = false;
                        continue;
                    }                    
                    if (resultFiltCB.SelectedIndex != 3 && resultFiltTB.Text != "")
                        if (!checkDoubleValue(
                            Convert.ToDouble(resultFiltTB.Text),
                            Convert.ToDouble(dGV[7, i].Value.ToString()),
                            resultFiltCB.SelectedIndex
                            ))
                        {
                            dGV.Rows[i].Visible = false;
                            continue;
                        }
                    if (salFiltCB.SelectedIndex != 3 && salFiltTB.Text != "")
                        if (!checkDoubleValue(
                            Convert.ToDouble(salFiltTB.Text),
                            Convert.ToDouble(dGV[4, i].Value.ToString()),
                            salFiltCB.SelectedIndex
                            ))
                        {
                            dGV.Rows[i].Visible = false;
                            continue;
                        }

                    if (dateFiltCB.SelectedIndex != 3)
                        if (!checkDateValue(dateFiltTP.Value, Convert.ToDateTime(dGV[3, i].Value.ToString()), dateFiltCB.SelectedIndex))
                        {
                            dGV.Rows[i].Visible = false;
                            continue;
                        }
                }
            }
        }

        private bool checkDateValue(DateTime filter, DateTime table, int index)
        {
            bool flag = false;
            switch (index)
            {
                case 0:
                    if (filter.Date < table.Date)
                        flag = true;
                    break;
                case 1:
                    if (filter.Date > table.Date)
                        flag = true;
                    break;
                case 2:
                    if (filter.Date == table.Date)
                        flag = true;
                    break;
            }
            return flag;
        }

        private bool checkDoubleValue(double filter, double table, int index)
        {
            bool flag = false;
            switch(index)
            {
                case 0:
                    if (filter < table)
                        flag = true;
                    break;
                case 1:
                    if (filter > table)
                        flag = true;
                    break;
                case 2:
                    if (filter == table)
                        flag = true;
                    break;
            }
            return flag;
        }

        private void refreshFilter()
        {
            for (int i = 0; i < dGV.RowCount; i++)
                dGV.Rows[i].Visible = true;
            surFiltTB.Clear();
            sexFiltCB.SelectedIndex = 2;
            positionFiltTB.Clear();
            salFiltTB.Clear();
            salFiltCB.SelectedIndex = 3;
            dateFiltTP.Value = DateTime.Now;
            dateFiltCB.SelectedIndex = 3;
            resultFiltTB.Clear();
            resultFiltCB.SelectedIndex = 3;
            if (table == 0)
            {
                filoLBL.Text = "Прізвище";
                resultGgroupBox.Visible = false;
                sexLBL.Visible = true;
                sexFiltCB.Visible = true;
                posLBL.Visible = true;
                positionFiltTB.Visible = true;
                dateGroupBox.Text = "Дата народження";               
            }
            else
            {
                filoLBL.Text = "ПIБ";
                sexLBL.Visible = !true;
                sexFiltCB.Visible = !true;
                posLBL.Visible = !true;
                positionFiltTB.Visible = !true;
                dateGroupBox.Text = "Дата видачi";
                resultGgroupBox.Visible = !false;
            }
        }

        private void filterOnBtn_Click(object sender, EventArgs e)
        {
            filtration();
        }

        private void lastTaxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void moreInfoBtn_Click(object sender, EventArgs e)
        {
            showMoreInfo = !showMoreInfo;
            moreInfoPanel.Visible = showMoreInfo;
        }

        private void editinShowBtn_Click(object sender, EventArgs e)
        {
            showEditing = !showEditing;
            editAddPanel.Visible = showEditing;
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
