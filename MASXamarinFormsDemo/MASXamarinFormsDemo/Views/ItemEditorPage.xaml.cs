using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MASXamarinFormsDemo.Models;

namespace MASXamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemEditorPage : ContentPage
    {
        public Idea Idea { get; set; }
        public readonly bool IsEditing;
        public bool ItemUpdated = false;

        public ItemEditorPage(Idea idea = null)
        {
            InitializeComponent();
            Idea = idea ?? new Idea(); // don't want to bind to null :)
            IsEditing = idea != null; // determine if we're editing
            SetupUi();
        }

        private void SetupUi()
        {
            Title = IsEditing ? "Edit Idea" : "New Idea";
            tbxTitle.Text = Idea.Title;
            tbxDescription.Text = Idea.Description;
            tbxDepartment.Text = Idea.Department;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            // Make sure they entered everything that's required.
            if (string.IsNullOrWhiteSpace(tbxTitle.Text) ||
                string.IsNullOrWhiteSpace(tbxDescription.Text) ||
                string.IsNullOrWhiteSpace(tbxDepartment.Text))
            {
                await DisplayAlert(
                    Strings.AlertTitle_Error,
                    "Title, Summary, and Department are required.",
                    "OK");
                return;
            }

            Idea.Title = tbxTitle.Text;
            Idea.Description = tbxDescription.Text;
            Idea.Department = tbxDepartment.Text;

            var isLoggedIn = await Utility.EnsureLoggedIn(this, true);
            if (!isLoggedIn) return;
            
            // Attempt to save in service.
            if (IsEditing)
            {
                var success = await App.IdeaService.UpdateIdeaAsync(Idea);
                await DisplayAlert(success ? Strings.AlertTitle_Info : Strings.AlertTitle_Error, 
                    success
                    ? "Idea updated!"
                    : "Couldn't update the idea.", Strings.Button_OK);

                // Send message to update subscribers.
                MessagingCenter.Send(this, "EditingComplete", true);

                ItemUpdated = success;

            }
            else
            {
                var success = await App.IdeaService.AddIdeaAsync(Idea);
                await DisplayAlert(success ? Strings.AlertTitle_Info : Strings.AlertTitle_Error,
                    success
                        ? "Idea added!"
                        : "Couldn't add the idea.", Strings.Button_OK);

                // Send message to update subscribers.
                MessagingCenter.Send(this, "AddItem", Idea);
            }

            // Go back to the calling view.
            if (IsEditing) await Navigation.PopAsync();
            else await Navigation.PopModalAsync();
        }
    }
}