using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.Entities
{
    [Table("Employee")]
    public class Employee : Person
    {
        public double DailyIncome { get; set; }
        public float DaysWorked { get; set; }
        public double TotalIncome { get; private set; }
        public float LastDaysWorked { get; set; }
        public double LastIncome { get; set; }
        [ManyToMany(typeof(ConstrucionEmployee))]
        public List<Construction> Constructions { get; set; }
        public Employee CalculateIncome()
        {
            TotalIncome = DaysWorked * DailyIncome;
            return this;
        }
    }
}
