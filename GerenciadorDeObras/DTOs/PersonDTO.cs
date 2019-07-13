using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeObras.DTOs
{
    public class PersonDTO : EntityCoreDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
    }
}
