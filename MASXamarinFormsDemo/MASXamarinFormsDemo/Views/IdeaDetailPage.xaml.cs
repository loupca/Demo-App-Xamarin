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
        ItemDetailViewModel viewModel;

        public IdeaDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public IdeaDetailPage()
        {
            InitializeComponent();

            var item = new Idea
            {
                Title = "Idea Title",
                Summary = "Description of the idea."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}