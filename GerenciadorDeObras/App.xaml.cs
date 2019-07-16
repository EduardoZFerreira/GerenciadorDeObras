using GerenciadorDeObras.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GerenciadorDeObras
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public static MasterDetailPage Master { get; set; }

        public async static Task NavigatePage(Page page)
        {
            App.Master.IsPresented = false;
            await App.Master.Detail.Navigation.PushAsync(page);
        }

        public App()
        {
            InitializeComponent();

            MainPage = new Main();
        }

        public App(string DB_Path)
        {
            InitializeComponent();

            DB_PATH = DB_Path;

            MainPage = new Main();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
