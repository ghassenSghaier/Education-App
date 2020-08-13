using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EduAPP.Services;
using EduAPP.Views;

namespace EduAPP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<FoRestService>();
            DependencyService.Register<InRestService>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
