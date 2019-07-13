using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.DTOs
{
    public class EmployeeDTO : PersonDTO
    {
        public double DailyIncome { get; set; }
        public float DaysWorked { get; set; }
        public double TotalIncome { get; set; }
    }
}
