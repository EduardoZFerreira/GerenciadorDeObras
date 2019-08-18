using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GerenciadorDeObras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        private EmployeeDTO Employee;
        public EmployeePage(EmployeeDTO dto)
        {
            InitializeComponent();
            SetDto(dto);
            BindingContext = Employee;
        }

        private void SetDto(EmployeeDTO dto)
        {
            Employee = dto;
        }
        
        private void PagamentoCompleto(object sender, EventArgs e)
        {
            UpdateEmployee(Employee, Employee.TotalIncome, 0);
        }

        private void PagamentoParcial(object sender, EventArgs e)
        {
            ToggleButtons();
        }

        private void ToggleButtons()
        {
            PartialPaymentButton.IsVisible = !PartialPaymentButton.IsVisible;
            SavePaymentButton.IsVisible = !SavePaymentButton.IsVisible;
            CancelPaymentButton.IsVisible = !CancelPaymentButton.IsVisible;
            PaymentEntry.IsVisible = !PaymentEntry.IsVisible;
        }

        private void DefinirPagamentoParcial(object sender, EventArgs e)
        {
            UpdateEmployee(Employee, double.Parse(PaymentEntry.Text), Employee.DaysWorked);
            ToggleButtons();
        }

        private void UpdateEmployee(EmployeeDTO dto, double payed, float daysLeft)
        {
            dto.DaysWorked = daysLeft;
            dto.TotalIncome -= payed;
            if (EmployeeService.Build().Update(dto))
            {
                SetDto(dto);
            }
        }

    }
}