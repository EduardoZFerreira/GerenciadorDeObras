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
    public partial class ClientsPage : ContentPage
    {
        public ClientsPage()
        {
            InitializeComponent();
            List<ClientDTO> clients =  ClientService.Build().GetAll();
            ClientsListView.ItemsSource = new ObservableCollection<ClientDTO>(clients);
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await App.NavigatePage(new CreateClientPage());
        }
    }
}