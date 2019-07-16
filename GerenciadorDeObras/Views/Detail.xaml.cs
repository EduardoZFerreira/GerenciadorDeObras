using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GerenciadorDeObras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public string Day { get; }
        public string Date { get;  }
        public Detail()
        {
            var culture = new System.Globalization.CultureInfo("pt-BR");
            Day = culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek).ToUpper();
            Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            InitializeComponent();
            BindingContext = this;
        }
    }
}