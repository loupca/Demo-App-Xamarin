using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MASXamarinFormsDemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MASXamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavMenuPage : ContentPage
    {
        public ObservableCollection<Models.MenuItem> Items { get; set; }

        public NavMenuPage()
        {
            Title = "MAS Ideas Sample App";
            InitializeComponent();

            Items = new ObservableCollection<Models.MenuItem>
            {
                new Models.MenuItem() { ImageFilename = "icon_home", Text = "Home" },
                new Models.MenuItem() { ImageFilename = "icon_logout", Text = "Log Out" }
            };
			
			MyListView.ItemsSource = Items;
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
            }

            // Deselect item so it doesn't stay highlighted.
            ((ListView)sender).SelectedItem = null;
        }
    }
}
