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
    public partial class ConstructionsPage : ContentPage
    {
        public ConstructionsPage()
        {
            InitializeComponent();
            List<ConstructionDTO> constructions = ConstructionService.Build().GetAll();
            ConstructionsListView.ItemsSource = new ObservableCollection<ConstructionDTO>(constructions);
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await App.NavigatePage(new CreateConstructionPage());
        }
    }
}