using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace GerenciadorDeObras.Entities
{
    [Table("Client")]
    public class Client : Person
    {
        public double Debt { get; private set; }
        public double AmountPayed { get; set; }
        public double TotalDebt { get; set; }
        [OneToMany]
        public List<Construction> Constructions { get; set; }

        public Client CalculateDebt()
        {
            Debt = TotalDebt - AmountPayed;
            return this;
        }

    }
}
