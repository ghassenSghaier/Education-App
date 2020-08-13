using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using EduAPP.Models;
using EduAPP.Views;


namespace EduAPP.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Formation> Formations { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Formations";
            Formations = new ObservableCollection<Formation>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Formation>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Formation;
                Formations.Add(newItem);
                await DataStore.SaveTodoItemAsync(newItem,true);
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