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
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void BtnClients_Clicked(object sender, EventArgs e)
        {
            await App.NavigatePage(new ClientsPage());
        }

        private async void BtnEmployees_Clicked(object sender, EventArgs e)
        {
            await App.NavigatePage(new EmployeesPage());
        }

        private async void BtnConstructions_Clicked(object sender, EventArgs e)
        {
            await App.NavigatePage(new ConstructionsPage());
        }
    }
}