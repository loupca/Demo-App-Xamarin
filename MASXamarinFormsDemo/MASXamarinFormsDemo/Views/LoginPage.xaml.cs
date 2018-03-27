using System;
using System.Threading.Tasks;
using MASXamarinFormsDemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MASXamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Toggles the UI availability.
        /// </summary>
        /// <param name="enableUi"></param>
        private void ToggleUi(bool enableUi)
        {
            pleaseWait.IsRunning = !enableUi;
            tbxUsername.IsEnabled = enableUi;
            tbxPassword.IsEnabled = enableUi;
        }

        /// <summary>
        /// Handles the login button tapped event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnLogin_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxUsername.Text) ||
                string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                await DisplayAlert("Error", "Please enter a username and password.", "OK");
                return;
            }

            ToggleUi(false);

            await App.IdeaService
                .LogIn(tbxUsername.Text, tbxPassword.Text)
                .ContinueWith(async (task) =>
                {
                    var loginSuccessful = task.Result;
                    if (loginSuccessful)
                    {
                        await DisplayAlert("Info", "Login successful.", "OK");
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Error occurred logging in. Check your credentials and network connectivity.", "OK");
                    }

                    ToggleUi(true);
                }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}