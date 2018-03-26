using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MASXamarinFormsDemo.Models;

namespace MASXamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Idea Idea { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            Idea = new Idea(); // don't want to bind to null :)
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
            await DisplayAlert("Info", await App.IdeaService.AddIdeaAsync(Idea) 
                ? "Sample idea added!" 
                : "Couldn't add the idea.", "OK");

            // Send message to update subscribers.
            MessagingCenter.Send(this, "AddItem", Idea);

            // Go back to the calling view.
            await Navigation.PopModalAsync();
        }
    }
}