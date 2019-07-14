using GerenciadorDeObras.Data;
using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDeObras.Services
{
    public class EmployeeService
    {
        public static EmployeeService Build()
        {
            return new EmployeeService();
        }

        public bool Create(EmployeeDTO entityDto)
        {
            return EmployeeRepository.Build().Create(EmployeeMapper.Build().ToEntity(entityDto));
        }

        public bool Update(EmployeeDTO entityDto)
        {
            return EmployeeRepository.Build().Update(EmployeeMapper.Build().ToEntity(entityDto));
        }

        public bool CreateOrUpdate(EmployeeDTO entityDto)
        {
            return entityDto.Id > 0 ? Update(entityDto) : Create(entityDto);
        }

        public List<EmployeeDTO> GetAll()
        {

            return EmployeeMapper.Build().ToDtoList(EmployeeRepository.Build().GetAll()).ToList();
        }

        public EmployeeDTO GetWithChildren(int id)
        {
            return EmployeeMapper.Build().ToDto(EmployeeRepository.Build().GetWithChildren(id));
        }

        public bool Delete(EmployeeDTO entityDto)
        {
            return EmployeeRepository.Build().Delete(EmployeeMapper.Build().ToEntity(entityDto));
        }

    }
}
