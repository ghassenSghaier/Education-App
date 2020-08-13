using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using EduAPP.Models;
using EduAPP.Views;


namespace EduAPP.ViewModels
{
    public class InscriptionsViewModel : InscriptionBaseViewModel
    {
        public ObservableCollection<Inscription> Inscriptions { get; set; }
        public Command LoadItemsCommand { get; set; }

        public InscriptionsViewModel()
        {
            Title = "Inscriptions";
            Inscriptions = new ObservableCollection<Inscription>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<InscriptionDetailPage, string>(this, "DeleteTodoItem", async (obj, item) =>
            {
                var newItem = item as string;
                await DataStore.DeleteTodoItemAsync(newItem);
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
                Inscriptions.Clear();
                var items = await DataStore.RefreshDataAsync();
                foreach (var item in items)
                {
                    Inscriptions.Add(item);
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