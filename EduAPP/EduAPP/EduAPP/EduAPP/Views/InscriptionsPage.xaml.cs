﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EduAPP.Models;
using EduAPP.Views;
using EduAPP.ViewModels;


namespace EduAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class InscriptionsPage : ContentPage
    {
        InscriptionsViewModel viewModel;

        public InscriptionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new InscriptionsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Inscription;
            if (item == null)
                return;

            await Navigation.PushAsync(new InscriptionDetailPage(new InscriptionDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        
        /**async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }**/


        protected override void OnAppearing()
        {
            base.OnAppearing();            

            if (viewModel.Inscriptions.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
        
    }
}