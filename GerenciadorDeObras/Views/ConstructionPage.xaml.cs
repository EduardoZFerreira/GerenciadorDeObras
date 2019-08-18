using GerenciadorDeObras.DTOs;
using GerenciadorDeObras.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GerenciadorDeObras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConstructionPage : ContentPage
    {
        private ConstructionDTO Construction;
        public ConstructionPage(int id)
        {
            InitializeComponent();
            SetDto(ConstructionService.Build().GetWithChildren(id));
            RefreshList();
            EmployeesPicker.ItemsSource = new ObservableCollection<EmployeeDTO>(GetEmployees());
        }

        private void RefreshList()
        {
            CurrentEmployeesListView.ItemsSource = new ObservableCollection<EmployeeDTO>(Construction.Crew);
        }

        private void SetDto(ConstructionDTO dto)
        {
            dto.Crew = dto.Crew != null ? dto.Crew : new List<EmployeeDTO>();
            Construction = dto;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            return EmployeeService.Build().GetAll();
        }
        
        private void EmployeesPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Construction.Crew.Add((EmployeeDTO)EmployeesPicker.SelectedItem);
            if (ConstructionService.Build().UpdateWithChildren(Construction)) RefreshList();
        }

        private void AddDay(object sender, EventArgs e)
        {
            AtualizaDiasTrabalhados(Construction.Crew.Find(x => x.Id == Convert.ToInt32(((Button)sender).ClassId)), 1);
        }

        private void AddHalfDay(object sender, EventArgs e)
        {
            AtualizaDiasTrabalhados(Construction.Crew.Find(x => x.Id == Convert.ToInt32(((Button)sender).ClassId)), (float)0.5);
        }

        private void AtualizaDiasTrabalhados(EmployeeDTO emp, float day)
        {
            emp.DaysWorked += day;
            if (EmployeeService.Build().Update(emp)) DisplayAlert("Sucesso!", "Atualizado", "Ok");
        }

    }
}