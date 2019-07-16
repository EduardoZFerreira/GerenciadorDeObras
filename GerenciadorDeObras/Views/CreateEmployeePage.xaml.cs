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
    public partial class CreateEmployeePage : ContentPage
    {
        public EmployeeDTO Employee = new EmployeeDTO();
        public CreateEmployeePage()
        {
            InitializeComponent();
        }

        private void SetDto(EmployeeDTO dto)
        {
            Employee = dto;
        }

        private void SetEntriesFromDto(EmployeeDTO dto)
        {
            Name.Text = dto.Name;
            Phone.Text = dto.Phone;
            Address.Text = dto.Address;
            DailyIncome.Text = dto.DailyIncome.ToString();
        }

        private EmployeeDTO UpdateDtoFromEntries(EmployeeDTO dto)
        {
            dto.Name = Name.Text;
            dto.Phone = Phone.Text;
            dto.Address = Address.Text;
            dto.DailyIncome = double.Parse(DailyIncome.Text);
            return dto;
        }

        private async void CreateEmployeeButton_Clicked(object sender, EventArgs e)
        {
            if (EmployeeService.Build().Create(UpdateDtoFromEntries(Employee)))
            {
                await DisplayAlert("Sucesso", "Cadastro atualizado!", "Ok");
                await App.NavigatePage(new EmployeesPage());
            }
        }
    }
}