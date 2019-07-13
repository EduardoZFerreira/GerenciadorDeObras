using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.Entities
{
    public class EntityCore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public State State { get; set; }
    }
}
