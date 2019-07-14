using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.DTOs
{
    public class ClientDTO : PersonDTO
    {
        public double Debt { get; set; }
        public double AmountPayed { get; set; }
        public double TotalDebt { get; set; }
        public List<ConstructionDTO> Constructions { get; set; }
    }
}
