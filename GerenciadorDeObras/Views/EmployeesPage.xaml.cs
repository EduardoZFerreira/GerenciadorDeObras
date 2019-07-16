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
    public partial class EmployeesPage : ContentPage
    {
        public EmployeesPage()
        {
            InitializeComponent();
            List<EmployeeDTO> employees = EmployeeService.Build().GetAll();
            EmployeesListView.ItemsSource = new ObservableCollection<EmployeeDTO>(employees);
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await App.NavigatePage(new CreateEmployeePage());
        }
    }
}