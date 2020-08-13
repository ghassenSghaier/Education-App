using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using EduAPP.Models;
using EduAPP.Views;

namespace EduAPP.ViewModels
{
    public class FormationsViewModel : FormationBaseViewModel
    {
        public ObservableCollection<Formation> Formations { get; set; }
        public Command LoadItemsCommand { get; set; }

        public FormationsViewModel()
        {
            Title = "Formations";
            Formations = new ObservableCollection<Formation>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<FormationDetailPage, Inscription>(this, "SaveTodoInscri", async (obj, item) =>
            {
                var newItem = item as Inscription;
                await DataStore.SaveInscriAsync(newItem,true);
                //MessagingCenter.Unsubscribe<Inscription>(this, "SaveTodoInscri");
            });            
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Formations.Clear();
                var items = await DataStore.RefreshDataAsync();
                foreach (var item in items)
                {
                    Formations.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}