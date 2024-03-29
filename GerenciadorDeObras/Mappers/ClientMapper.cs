﻿using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeObras.Mappers
{
    public class ClientMapper
    {
        public static ClientMapper Build()
        {
            return new ClientMapper();
        }
        public Client ToEntity(ClientDTO dto)
        {
            Client client = new Client()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                TotalDebt = dto.TotalDebt,
                AmountPayed = dto.AmountPayed,
                Constructions = new List<Construction>()
            };
            client = client.CalculateDebt();
            return client;
        }

        public Client ToEntityWithChildren(ClientDTO dto)
        {
            Client client = new Client()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                TotalDebt = dto.TotalDebt,
                AmountPayed = dto.AmountPayed,
                Constructions = dto.Constructions != null ? ConstructionMapper.Build().ToEntityList(dto.Constructions).ToList() : new List<Construction>()
            };
            client = client.CalculateDebt();
            return client;
        }

        public IEnumerable<Client> ToEntityList(List<ClientDTO> clients)
        {
            foreach(ClientDTO c in clients)
            {
                yield return ToEntity(c);
            }
        }

        public IEnumerable<ClientDTO> ToDtoList(List<Client> clients)
        {
            foreach (Client c in clients)
            {
                yield return ToDto(c);
            }
        }

        public ClientDTO ToDto(Client entity)
        {
            ClientDTO client = new ClientDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                TotalDebt = entity.TotalDebt,
                AmountPayed = entity.AmountPayed,
                Debt = entity.Debt,
                Constructions = new List<ConstructionDTO>()
            };
            return client;
        }

        public ClientDTO ToDtoWithChildren(Client entity)
        {
            ClientDTO client = new ClientDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                TotalDebt = entity.TotalDebt,
                AmountPayed = entity.AmountPayed,
                Debt = entity.Debt,
                Constructions = entity.Constructions != null ? ConstructionMapper.Build().ToDtoList(entity.Constructions).ToList() : new List<ConstructionDTO>()
            };
            return client;
        }
    }
}
