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

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Idea;
            if (item == null)
                return;

            await Navigation.PushAsync(new IdeaDetailPage(item));

            // Manually deselect item so it doesn't stay selected.
            IdeasListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemEditorPage(/* null creates a new Idea */)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Ideas.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}