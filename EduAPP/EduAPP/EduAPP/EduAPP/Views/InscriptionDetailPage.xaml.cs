using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EduAPP.Models;
using EduAPP.ViewModels;


namespace EduAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class InscriptionDetailPage : ContentPage
    {
        InscriptionDetailViewModel viewModel;

        public InscriptionDetailPage(InscriptionDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public InscriptionDetailPage()
        {
            InitializeComponent();

            var inscription = new Inscription
            {
                Title = "Item 1",
                Date = DateTime.Now
            };

            viewModel = new InscriptionDetailViewModel(inscription);
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            string InscId = viewModel.Inscription.InscId;                       
            MessagingCenter.Send(this, "DeleteTodoItem", InscId);
            //await Navigation.PopModalAsync();
            await Navigation.PopAsync();
        }
    }
}