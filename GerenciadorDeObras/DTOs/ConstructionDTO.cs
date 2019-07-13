using GerenciadorDeObras.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.DTOs
{
    public class ConstructionDTO : EntityCoreDTO
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public ClientDTO Client { get; set; }
        public DateTime Deadline { get; set; }
        public double Cost { get; set; }
        public double EndPrice { get; set; }
        public List<EmployeeDTO> Crew { get; set; }
        public StatusEnum Status { get; set; }
    }
}
