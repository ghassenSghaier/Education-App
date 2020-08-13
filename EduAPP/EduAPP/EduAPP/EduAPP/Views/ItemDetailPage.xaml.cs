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
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            Formation Formation = new Formation
            {
                Title = "Item 1",
                Des = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(Formation);
            BindingContext = viewModel;
        }
    }
}