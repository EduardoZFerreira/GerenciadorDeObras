using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.Entities
{
    public class ConstrucionEmployee
    {
        [ForeignKey(typeof(Employee)]
        public int EmployeeId { get; set; }
        [ForeignKey(typeof(Construction)]
        public int ConstructionId { get; set; }
    }
}
