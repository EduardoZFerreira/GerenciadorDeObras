using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDeObras.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeMapper Build()
        {
            return new EmployeeMapper();
        }
        public Employee ToEntity(EmployeeDTO dto)
        {
            Employee Employee = new Employee()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                DailyIncome = dto.DailyIncome,
                DaysWorked = dto.DaysWorked,
                TotalIncome = dto.TotalIncome
            };
            if(dto.TotalIncome == 0) Employee = Employee.CalculateIncome();
            return Employee;
        }

        public Employee ToEntityWithChildren(EmployeeDTO dto)
        {
            Employee Employee = new Employee()
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                DailyIncome = dto.DailyIncome,
                DaysWorked = dto.DaysWorked,
                Constructions = dto.Constructions != null ? ConstructionMapper.Build().ToEntityList(dto.Constructions).ToList() : new List<Construction>()
            };
            Employee = Employee.CalculateIncome();
            return Employee;
        }


        public IEnumerable<Employee> ToEntityList(List<EmployeeDTO> Employees)
        {
            foreach (EmployeeDTO c in Employees)
            {
                yield return ToEntity(c);
            }
        }

        public IEnumerable<EmployeeDTO> ToDtoList(List<Employee> Employees)
        {
            foreach (Employee c in Employees)
            {
                yield return ToDto(c);
            }
        }
        public EmployeeDTO ToDto(Employee entity)
        {
            if(entity.TotalIncome == 0) entity = entity.CalculateIncome();
            EmployeeDTO employee = new EmployeeDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                DailyIncome = entity.DailyIncome,
                DaysWorked = entity.DaysWorked,
                TotalIncome = entity.TotalIncome
            };
            return employee;
        }

        public EmployeeDTO ToDtoWithChildren(Employee entity)
        {
            entity = entity.CalculateIncome();
            EmployeeDTO employee = new EmployeeDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                DailyIncome = entity.DailyIncome,
                DaysWorked = entity.DaysWorked,
                TotalIncome = entity.TotalIncome,
                Constructions = entity.Constructions != null ? ConstructionMapper.Build().ToDtoList(entity.Constructions).ToList() : new List<ConstructionDTO>()
            };
            return employee;
        }

    }
}
