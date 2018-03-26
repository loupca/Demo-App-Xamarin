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
        public bool IsEditing = false;

        public ItemEditorPage(Idea idea = null)
        {
            InitializeComponent();
            IsEditing = idea != null; // determine if we're editing
            Idea = idea ?? new Idea(); // don't want to bind to null :)
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            // Make sure they entered everything that's required.
            if (string.IsNullOrWhiteSpace(Idea.Title) || 
                string.IsNullOrWhiteSpace(Idea.Summary) ||
                string.IsNullOrWhiteSpace(Idea.Department))
            {
                await DisplayAlert(
                    "Error", 
                    "Title, Summary, and Department are required.", 
                    "OK");
                return;
            }

            // Attempt to save in service.
            if (IsEditing)
            {
                await DisplayAlert("Info", await App.IdeaService.UpdateIdeaAsync(Idea)
                    ? "Idea updated!"
                    : "Couldn't update the idea.", "OK");
            }
            else
            {
                await DisplayAlert("Info", await App.IdeaService.AddIdeaAsync(Idea)
                    ? "Idea added!"
                    : "Couldn't add the idea.", "OK");
            }

            // Send message to update subscribers.
            MessagingCenter.Send(this, "AddItem", Idea);

            // Go back to the calling view.
            await Navigation.PopModalAsync();
        }
    }
}