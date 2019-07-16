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
    public partial class CreateConstructionPage : ContentPage
    {
        public DateTime MinDate { get; } = DateTime.Today.AddDays(1);
        public ConstructionDTO Construction = new ConstructionDTO();
        public CreateConstructionPage()
        {
            InitializeComponent();
            Deadline.MinimumDate = MinDate;
            ClientsPicker.ItemsSource = new ObservableCollection<ClientDTO>(GetClients());
        }

        private List<ClientDTO> GetClients()
        {
            return ClientService.Build().GetAll();
        }

        private void SetDto(ConstructionDTO dto)
        {
            Construction = dto;
        }

        private void SetEntriesFromDto(ConstructionDTO dto)
        {
            
        }

        private ConstructionDTO UpdateDtoFromEntries(ConstructionDTO dto)
        {
            dto.Client = (ClientDTO)ClientsPicker.SelectedItem;
            dto.Title = Title.Text;
            dto.Desc = Desc.Text;
            dto.Cost = double.Parse(Cost.Text);
            dto.EndPrice = double.Parse(EndPrice.Text);
            dto.Deadline = Deadline.Date;
            return dto;
        }

        private async void CreateConstructionBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                ConstructionDTO constr = UpdateDtoFromEntries(Construction);
                constr.Id = ConstructionService.Build().Create(constr);
                if (UpdateClientDebt(constr))
                {
                    await DisplayAlert("Sucesso!", "Construção atualizada!", "Ok");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("ERRO!", "Aconteceu algo errado, detalhes: " + ex.Message, "Ok");
            }
        }

        private bool UpdateClientDebt(ConstructionDTO construction)
        {
            ClientDTO client = Construction.Client;
            client.TotalDebt += construction.EndPrice;
            client.Constructions.Add(construction);
            return ClientService.Build().UpdateWithChildren(client);
        }

    }
}