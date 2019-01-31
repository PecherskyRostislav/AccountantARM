using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountantARM
{
    public class CalculationOfTaxes
    {
        public string FIO { get; set; }
        public int ID { get; set; }
        public int IDEmp { get; set; }
        public int IDTaxes { get; set; }
        public int Salary { get; set; }
        public double Total {
            get
            {
                return Salary - PDFO - Military;
            }
        }
        private double pdfo;
        public double PDFO { 
            get
            {
                return Salary * pdfo / 100;
            }
            set
            {
                pdfo = value;
            }
        }
        private double milit;
        public double Military {
            get
            {
                return Salary * milit / 100;
            }
            set
            {
                milit = value;
            }
        }
        private double esv;
        public double ESV {
            get
            {
                return Salary * esv / 100;
            }
            set
            {
                esv = value;
            }
        }
        private DateTime dt;
        public string DateIssue
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

        public string pdfoInfo()
        {
            return $"ПДФО - {pdfo}%" + Environment.NewLine +
                   "Оклад * ПДФО = Сума налогу" + Environment.NewLine +
                   $"{Salary} * {pdfo} / 100 = {PDFO}";
        }

        public string militaryInfo()
        {
            return $"Військовий збір - {milit}%" + Environment.NewLine +
                   "Оклад * Військ. зб. = Сума збору" + Environment.NewLine +
                   $"{Salary} * {milit} / 100 = {Military}";
        }

        public string ESVInfo()
        {
            return $"ЄСВ - {esv}%" + Environment.NewLine +
                   "Оклад * ЄСВ = Сума ЄСВ" + Environment.NewLine +
                   $"{Salary} * {esv} / 100 = {ESV}";
        }

        public string totalInfo()
        {
            return "До виплати = Оклад - ПДФО - Вiйськовий збiр" + Environment.NewLine +
                   $"{Salary} - {PDFO} - {Military} = {Total}";
        }
    }
}
