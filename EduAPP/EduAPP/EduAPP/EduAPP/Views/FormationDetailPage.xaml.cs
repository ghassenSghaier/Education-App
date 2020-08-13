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
    public partial class FormationDetailPage : ContentPage
    {
        FormationDetailViewModel viewModel;

        public FormationDetailPage(FormationDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public FormationDetailPage()
        {
            InitializeComponent();

            var formation = new Formation
            {
                Title = "Item 1",
                Des = "This is an item description."
            };

            viewModel = new FormationDetailViewModel(formation);
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var inscription = new Inscription
            {                
                ForId = viewModel.Item.ForId,
                Title= viewModel.Item.Title,
                InscId = Guid.NewGuid().ToString(),
                Date = DateTime.Now
        };
            MessagingCenter.Send(this, "SaveTodoInscri", inscription);
            //await Navigation.PopModalAsync();
            await Navigation.PopAsync();
        }

    }
}