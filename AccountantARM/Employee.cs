using System;

namespace AccountantARM
{
    public class Employee
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        private bool sex;
        public string Sex
        {
            get
            {
                if (sex)
                    return "М";
                else
                    return "Ж";
            }
            set
            {
                sex = Convert.ToBoolean(value);
            }
        }
        private DateTime dt;
        public string DateBirth
        {
            get
            {
                return dt.ToShortDateString();
            }
            set
            {
                dt = Convert.ToDateTime(value);
            }
        }
        public string Position { get; set; }        
        public int Salary { get; set; }
    }
}
