using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

            // Subscribe to changes in the Ideas list.
            MessagingCenter.Subscribe<NewItemPage, Idea>(this, "AddIdea", async (obj, item) =>
            {
                var _item = item as Idea;
                Ideas.Add(_item);
                await IdeaService.AddIdeaAsync(_item);
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
                var items = await IdeaService.GetIdeasAsync(true);
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