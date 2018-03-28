using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = MASXamarinFormsDemo.Models.MenuItem;

namespace MASXamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavMenuPage : ContentPage
    {
        public ObservableCollection<Models.MenuItem> Items { get; set; } = new ObservableCollection<MenuItem>();

        private NavMenuPage PageInstance;

        public NavMenuPage()
        {
            Title = "MAS Ideas Sample App";
            InitializeComponent();
            BindingContext = this;
            SetupUi();
        }

        void SetupUi()
        {
            // Subscribe to auth changes.
            MessagingCenter.Subscribe<IIdeaService<Idea>, string>(this, "AuthChanged", (sender, message) =>
             {
                 UpdateLoginDisplay();
             });

            // Update the logged-in status UI.
            UpdateLoginDisplay();
        }

        async void UpdateLoginDisplay()
        {
            if (App.IdeaService.IsAuthenticated)
            {
                lblUsername.IsVisible = true;
                lblUsername.Text = await App.IdeaService.GetCurrentUserName();
                lblLoginStatus.TextColor = Color.Green;
                lblLoginStatus.Text = "Logged In";

                Items.Clear();
                Items.Add(new Models.MenuItem() { ImageFilename = "icon_logout", Text = "Log Out" });
            }
            else
            {
                lblUsername.IsVisible = false;
                lblLoginStatus.TextColor = Color.DarkRed;
                lblLoginStatus.Text = "Not Logged In";

                Items.Clear();
                Items.Add(new Models.MenuItem() { ImageFilename = "icon_login", Text = "Log In" });
            }
        }

        /// <summary>
        /// Handle menu item taps.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            switch ((e.Item as Models.MenuItem).Text)
            {
                case "Home":
                    await DisplayAlert("Whoops!", "Press OK for finger exercise.", "OK");
                    break;
                case "Log Out":
                    var success = await App.IdeaService.LogOut();
                    await DisplayAlert("Info", await App.IdeaService.LogOut() ? "You've been logged out." : "Couldn't log you out.", "OK");
                    break;
                case "Log In":
                    await Utility.EnsureLoggedIn(this, false);
                    break;
            }

            // Deselect item so it doesn't stay highlighted.
            ((ListView)sender).SelectedItem = null;
        }
    }
}
