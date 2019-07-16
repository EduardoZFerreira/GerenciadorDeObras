using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace GerenciadorDeObras.Entities
{
    [Table("Construction")]
    public class Construction : EntityCore
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        [ManyToOne]
        public Client Client { get; set; }
        public DateTime Deadline { get; set; }
        public double Cost { get; set; }
        public double EndPrice { get; set; }
        [ManyToMany(typeof(ConstrucionEmployee))]
        public List<Employee> Crew { get; set; }
        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }
        public string Status { get; set; }
    }
}
