using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.Views;

namespace MASXamarinFormsDemo.ViewModels
{
    public class IdeasViewModel : BaseViewModel
    {
        public ObservableCollection<Idea> Ideas { get; set; }

        public Command LoadItemsCommand { get; set; }

        public IdeasViewModel()
        {
            Title = "Ideas";
            Ideas = new ObservableCollection<Idea>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // Subscribe to additions in the Ideas list.
            MessagingCenter.Subscribe<ItemEditorPage, Idea>(this, "AddItem", async (obj, item) =>
            {
                var _item = item;
                Ideas.Add(_item);
            });

            // Subscribe to updates in the Ideas list.
            MessagingCenter.Subscribe<ItemEditorPage, Idea>(this, "UpdateItem", async (obj, item) =>
            {
                var _item = item;
                var idea = Ideas.First(i => i == _item);
                idea.Title = _item.Description;
                idea.Department = _item.Department;
                idea.Description = _item.Description;
            });

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Ideas.Clear();
                var items = await IdeaService.GetIdeasAsync(true).ConfigureAwait(false);
                foreach (var item in items)
                {
                    Ideas.Add(item);
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