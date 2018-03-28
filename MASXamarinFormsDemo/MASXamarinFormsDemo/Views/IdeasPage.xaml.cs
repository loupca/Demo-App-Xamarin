using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.ViewModels;

namespace MASXamarinFormsDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdeasPage : ContentPage
    {
        readonly IdeasViewModel _viewModel;

        public IdeasPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new IdeasViewModel();
        }

        #region Event Handlers

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Idea;
            if (item == null)
                return;

            // Manually deselect item so it doesn't stay selected.
            IdeasListView.SelectedItem = null;

            await Navigation.PushAsync(new IdeaDetailPage(item));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            // Make sure they're logged in before adding.
            if (await Utility.EnsureLoggedIn(this, true))
            {
                await Navigation.PushModalAsync(new NavigationPage(new ItemEditorPage(/* null creates a new Idea */)));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(null);
        }

        #endregion

    }
}