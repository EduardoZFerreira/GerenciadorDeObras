using GerenciadorDeObras.Data;
using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeObras.Services
{
    public class ClientService
    {
        public static ClientService Build()
        {
            return new ClientService();
        }

        public bool Create(ClientDTO entityDto)
        {
            return ClientRepository.Build().Create(ClientMapper.Build().ToEntity(entityDto));
        }

        public bool Update(ClientDTO entityDto)
        {
            return ClientRepository.Build().Update(ClientMapper.Build().ToEntity(entityDto));
        }

        public bool UpdateWithChildren(ClientDTO entityDto)
        {
            return ClientRepository.Build().UpdateWithChildren(ClientMapper.Build().ToEntity(entityDto));
        }

        public bool CreateOrUpdate(ClientDTO entityDto)
        {
            return entityDto.Id > 0 ? Update(entityDto) : Create(entityDto);
        }

        public List<ClientDTO> GetAll()
        {

            return ClientMapper.Build().ToDtoList(ClientRepository.Build().GetAll()).ToList();
        }

        public ClientDTO GetWithChildren(int id)
        {
            return ClientMapper.Build().ToDto(ClientRepository.Build().GetWithChildren(id));
        }

        public bool Delete(ClientDTO entityDto)
        {
            return ClientRepository.Build().Delete(ClientMapper.Build().ToEntity(entityDto));
        }
    }
}
