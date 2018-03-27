using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.ViewModels;

namespace MASXamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdeaDetailPage : ContentPage
    {
        public Idea Idea;
        private ItemEditorPage Editor;

        public IdeaDetailPage(Idea idea)
        {
            InitializeComponent();
            Idea = idea;
            BindingContext = Idea;
            SetupUi();
        }

        private void SetupUi()
        {
            // Wire-up the edit button.
            ToolbarItems.Add(new ToolbarItem("Edit", "icon_edit", async () =>
            {
                Editor = new ItemEditorPage(Idea);
                MessagingCenter.Subscribe<ItemEditorPage, bool>(this, "EditingComplete", async (page, editingComplete) =>
                {
                    if (editingComplete) await Navigation.PopAsync();
                });
                await Navigation.PushAsync(Editor);
            }));

            // Wire-up the delete button.
            ToolbarItems.Add(new ToolbarItem("Delete", "icon_delete", async () =>
            {
                var isLoggedIn = await Utility.EnsureLoggedIn(this, true);
                if (!isLoggedIn) return;

                var okToDelete = await DisplayAlert(
                    Strings.AlertTitle_Question,
                    "Are you sure? This action cannot be undone.",
                    Strings.Button_OK,
                    Strings.Button_Cancel);

                if (!okToDelete) return;
                if (!App.IdeaService.IsAuthenticated) return;

                if (await App.IdeaService.DeleteIdeaAsync(Idea))
                {
                    await DisplayAlert(Strings.AlertTitle_Info, "Idea deleted.", Strings.Button_OK);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert(Strings.AlertTitle_Error, "Idea could not be deleted.", Strings.Button_OK);
                }

            }));
        }

        protected override void OnDisappearing()
        {
            // Make sure we unsubscribe from the editing message.
            MessagingCenter.Unsubscribe<ItemEditorPage, bool>(this, "EditingComplete");
        }
    }
}