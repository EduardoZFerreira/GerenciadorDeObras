using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDeObras.Mappers
{
    public class ConstructionMapper
    {
        public static ConstructionMapper Build()
        {
            return new ConstructionMapper();
        }
        public Construction ToEntity(ConstructionDTO dto)
        {
            Construction Construction = new Construction()
            {
                Id = dto.Id,
                Title = dto.Title,
                Desc = dto.Desc,
                Deadline = dto.Deadline,
                Cost = dto.Cost,
                EndPrice = dto.EndPrice,
                Client = ClientMapper.Build().ToEntity(dto.Client),
                Crew = EmployeeMapper.Build().ToEntityList(dto.Crew).ToList()
            };
            return Construction;
        }

        public IEnumerable<Construction> ToEntityList(List<ConstructionDTO> Constructions)
        {
            foreach (ConstructionDTO c in Constructions)
            {
                yield return ToEntity(c);
            }
        }

        public IEnumerable<ConstructionDTO> ToDtoList(List<Construction> Constructions)
        {
            foreach (Construction c in Constructions)
            {
                yield return ToDto(c);
            }
        }

        public ConstructionDTO ToDto(Construction entity)
        {
            ConstructionDTO dto = new ConstructionDTO()
            {
                Id = entity.Id,
                Title = entity.Title,
                Desc = entity.Desc,
                Deadline = entity.Deadline,
                Cost = entity.Cost,
                EndPrice = entity.EndPrice,
                Client = ClientMapper.Build().ToDto(entity.Client),
                Crew = EmployeeMapper.Build().ToDtoList(entity.Crew).ToList()
            };
            return dto;
        }
    }
}
