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

        public IdeaDetailPage(Idea idea)
        {
            InitializeComponent();
            Idea = idea;
            BindingContext = this;
            SetupUi();
        }

	    private void SetupUi()
	    {
            // Wire-up the edit button.
            ToolbarItems.Add(new ToolbarItem("Edit", null, async () =>
                {
                    await Navigation.PushAsync(new ItemEditorPage(Idea));
                }));
	    }

    }
}