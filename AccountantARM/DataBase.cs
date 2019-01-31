using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace AccountantARM
{
    public class DataBase
    {
        private OleDbConnection connection;
        private OleDbCommand command;


        public void update(Employee emp)
        {
            bool sex = false;
            if (emp.Sex == "М")
                sex = true;
            command.CommandText = String.Format(
                    "UPDATE [Employees] SET [Surname] = '{0}', [Firstname] = '{1}', [Secondname] = '{2}', [Sex] = {3}, " +
                    "[DateBirth] = '{4}', [Position] = '{5}', [Salary] = {6} WHERE [id] = {7}",
                        emp.Surname,
                        emp.Firstname,
                        emp.Secondname,
                        sex.ToString(),
                        emp.DateBirth,
                        emp.Position,
                        emp.Salary.ToString(),
                        emp.ID.ToString()
                    );
            connection.Open();
            command.ExecuteReader().Close();
            connection.Close();
        }

        public string[] checkID(DateTime dt, int id)
        {
            List<string> res = new List<string>();
            connection.Open();
            command.CommandText = "SELECT IssuedSalaries.DateIssue FROM IssuedSalaries " +
                "WHERE Month(IssuedSalaries.DateIssue) = Month(DateValue('" + dt.ToShortDateString() + "')) " +
                "AND Year(IssuedSalaries.DateIssue) = Year(DateValue('" + dt.ToShortDateString() + "')) AND IssuedSalaries.idEmployee = " + id.ToString();
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    res.Add(dr["DateIssue"].ToString());
                }
            }
            dr.Close();
            connection.Close();
            return res.ToArray();
        }

        public void wagesDor(DateTime dt, int id, int sal)
        {
            if (id != 0)
            {
                string idTax = getLasTaxes()[3];
                connection.Open();
                command.CommandText = String.Format(
                "INSERT INTO [IssuedSalaries] ([idEmployee], [Salary], [DateIssue], [idTaxes]) " +
                "VALUES ({0}, {1}, '{2}', {3})",
                        id.ToString(),
                        sal.ToString(),
                        dt.ToShortDateString(),
                        idTax
                );
                command.ExecuteReader().Close();
                connection.Close();
            }
            else
            {
                connection.Open();
                try
                {
                    bool flag = false;
                    command.CommandText = "SELECT IssuedSalaries.idEmployee FROM IssuedSalaries " +
                            "WHERE Month([IssuedSalaries].[DateIssue]) = Month('" + dt.ToShortDateString() + "') " +
                            "AND Year([IssuedSalaries].[DateIssue]) = Year('" + dt.ToShortDateString() + "')";

                    OleDbDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                        flag = true;
                    dr.Close();

                    if (!flag)
                    {

                        command.CommandText = "INSERT INTO IssuedSalaries ( idEmployee, Salary, idTaxes, DateIssue) " +
                            "SELECT Employees.id, Employees.Salary, LastTaxes.id, DateValue('" + dt.ToShortDateString() + "') AS[date] " +
                            "FROM Employees, LastTaxes";
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO IssuedSalaries ( idEmployee, Salary, DateIssue, idTaxes ) " +
                                  "SELECT Employees.id as [idEmployee], Employees.Salary, DateValue('" + dt.ToShortDateString() + "') AS [DateIssue], LastTaxes.id as [idTaxes] " +
                                  "FROM Employees, LastTaxes WHERE (Employees.id <> " +
                                  "(SELECT IssuedSalaries.idEmployee FROM IssuedSalaries " +
                                  "WHERE Month([IssuedSalaries].[DateIssue]) = Month('" + dt.ToShortDateString() + "') " +
                                  "AND Year([IssuedSalaries].[DateIssue]) = Year('" + dt.ToShortDateString() + "')))";
                    }                    
                    dr = command.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            System.Windows.Forms.MessageBox.Show(dr["idEmployee"].ToString());
                        }
                    dr.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    throw new Exception(ex.Message);
                }
                /*
                command.CommandText = "INSERT INTO IssuedSalaries ( idEmployee, Salary, idTaxes, DateIssue) " +
                        "SELECT Employees.id, Employees.Salary, LastTaxes.id, DateValue('" + dt.ToShortDateString() + "') AS[date]" +
                        "FROM Employees, LastTaxes";
                connection.Open();
                command.ExecuteReader().Close();
                connection.Close();*/
            }
        }

        public void add(Employee emp)
        {
            bool sex = false;
            if (emp.Sex == "М")
                sex = true;
            command.CommandText = String.Format(
                "INSERT INTO [Employees] ([Surname], [Firstname], [Secondname], [Sex], [DateBirth], [Position], [Salary]) " +
                "VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', {6})",
                        emp.Surname,
                        emp.Firstname,
                        emp.Secondname,
                        sex.ToString(),
                        emp.DateBirth,
                        emp.Position,
                        emp.Salary.ToString()
                );
            connection.Open();
            command.ExecuteReader().Close();
            connection.Close();
        }

        public string[] getLasTaxes()
        {
            string[] res = new string[4];
            command.CommandText = "SELECT * FROM [LastTaxes]";
            connection.Open();
            OleDbDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                res[0] = dr["NDFL"].ToString();
                res[1] = dr["Military"].ToString();
                res[2] = dr["ESV"].ToString();
                res[3] = dr["id"].ToString();
            }
            dr.Close();
            connection.Close();
            return res;
        }

        public void addTaxes(double pdfo, double military, double esv)
        {
            string  str1 = $"{pdfo}".Replace(',', '.'),
                    str2 = $"{military}".Replace(',', '.'),
                    str3 = $"{esv}".Replace(',', '.');

            command.CommandText = "INSERT INTO [Taxes] ([NDFL], [Military], [ESV], [DateChange])" +
                 "VALUES (" + str1 + ", " + str2 + ", " + str3 + ", '" + DateTime.Now.ToString() + "')";
            connection.Open();
            command.ExecuteReader().Close();
            connection.Close();
        }

        public List<Employee> getEmployees()
        {
            List<Employee> list = new List<Employee>();
            command.CommandText = "SELECT * FROM [Employees]";
            connection.Open();
            OleDbDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["id"].ToString()),
                    Surname = dr["surname"].ToString(),
                    Firstname = dr["firstname"].ToString(),
                    Secondname = dr["secondname"].ToString(),
                    Sex = dr["sex"].ToString(),
                    DateBirth = dr["DateBirth"].ToString(),
                    Position = dr["position"].ToString(),
                    Salary = Convert.ToInt32(dr["salary"].ToString())
                });
            }
            dr.Close();
            connection.Close();
            return list;
        }

        public List<CalculationOfTaxes> getCalculationOfTaxes()
        {
            List<CalculationOfTaxes> list = new List<CalculationOfTaxes>();
            command.CommandText = "SELECT (Employees.Surname + ' ' + Employees.Firstname + ' ' + Employees.Secondname) as FIO, " +
                "IssuedSalaries.*, Taxes.NDFL, Taxes.Military, Taxes.ESV " +
                "FROM Taxes INNER JOIN (Employees INNER JOIN IssuedSalaries ON Employees.id = IssuedSalaries.idEmployee) ON Taxes.id = IssuedSalaries.idTaxes";
            connection.Open();
            OleDbDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new CalculationOfTaxes
                {
                    ID = Convert.ToInt32(dr["id"].ToString()),
                    DateIssue = dr["DateIssue"].ToString(),
                    IDEmp = Convert.ToInt32(dr["idEmployee"].ToString()),
                    IDTaxes = Convert.ToInt32(dr["idTaxes"].ToString()),
                    FIO = dr["FIO"].ToString(),
                    ESV = Convert.ToDouble(dr["ESV"].ToString()),
                    Military = Convert.ToDouble(dr["Military"].ToString()),
                    PDFO = Convert.ToDouble(dr["NDFL"].ToString()),
                    Salary = Convert.ToInt32(dr["salary"].ToString())
                });
            }
            dr.Close();
            connection.Close();
            return list;
        }

        public DataBase()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AccountantDatabase.accdb");
            command = new OleDbCommand();
            command.Connection = connection;
        }
    }
}
