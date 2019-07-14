using GerenciadorDeObras.Data;
using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDeObras.Services
{
    public class ConstructionService
    {
        public static ConstructionService Build()
        {
            return new ConstructionService();
        }

        public bool Create(ConstructionDTO entityDto)
        {
            return ConstructionRepository.Build().Create(ConstructionMapper.Build().ToEntity(entityDto));
        }

        public bool Update(ConstructionDTO entityDto)
        {
            return ConstructionRepository.Build().Update(ConstructionMapper.Build().ToEntity(entityDto));
        }

        public bool UpdateWithChildren(ConstructionDTO entityDto)
        {
            return ConstructionRepository.Build().UpdateWithChildren(ConstructionMapper.Build().ToEntity(entityDto));
        }

        public bool CreateOrUpdate(ConstructionDTO entityDto)
        {
            return entityDto.Id > 0 ? Update(entityDto) : Create(entityDto);
        }

        public List<ConstructionDTO> GetAll()
        {

            return ConstructionMapper.Build().ToDtoList(ConstructionRepository.Build().GetAll()).ToList();
        }

        public ConstructionDTO GetWithChildren(int id)
        {
            return ConstructionMapper.Build().ToDto(ConstructionRepository.Build().GetWithChildren(id));
        }

        public bool Delete(ConstructionDTO entityDto)
        {
            return ConstructionRepository.Build().Delete(ConstructionMapper.Build().ToEntity(entityDto));
        }

    }
}
