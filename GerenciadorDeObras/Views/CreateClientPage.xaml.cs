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
    public partial class CreateClientPage : ContentPage
    {
        public ClientDTO Client = new ClientDTO();
        public CreateClientPage()
        {
            InitializeComponent();
        }

        private void SetDto(ClientDTO dto)
        {
            Client = dto;
        }

        private void SetEntriesFromDto(ClientDTO dto)
        {
            Name.Text = dto.Name;
            Mail.Text = dto.Email;
            Phone.Text = dto.Phone;
            Address.Text = dto.Address;
        }

        private ClientDTO UpdateDtoFromEntries(ClientDTO dto)
        {
            dto.Name = Name.Text;
            dto.Email = Mail.Text;
            dto.Phone = Phone.Text;
            dto.Address = Address.Text;
            return dto;
        }

        private async void CreateClientBtn_Clicked(object sender, EventArgs e)
        {
            if(ClientService.Build().Create(UpdateDtoFromEntries(Client)))
            {
                await DisplayAlert("Sucesso", "Cadastro atualizado!", "Ok");
                await App.NavigatePage(new ClientsPage());
            }
        }
    }
}