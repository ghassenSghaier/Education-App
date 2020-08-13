using EduAPP;
using EduAPP.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EduAPP.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();            
        }

        protected async void OnClicked(object source, EventArgs args)
        {
            if (email.Text == "admin@hotmail.com" && password.Text =="123")
            {
                Application.Current.MainPage = new NavigationPage(new ItemsPage());                
            }
            else if(email.Text == "user@hotmail.com" && password.Text == "123")
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Alert", "User/Mail error", "OK");
            }

        }
    }
}
