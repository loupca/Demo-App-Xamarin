using System;
using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.Services;
using MASXamarinFormsDemo.Views;
using Xamarin.Forms;

namespace MASXamarinFormsDemo
{
    public partial class App : Application
    {
        public static IIdeaService<Idea> IdeaService;

        public App()
        {
            InitializeComponent();

            // Uncomment this once you have things wired up, and kill the mock service.
            /*
            // Get an instance of the Idea Service for the platform we're on.
            IdeaService = DependencyService.Get<IIdeaService<Idea>>();
            */
            IdeaService = new MockIdeaService(); // and then uncomment this, since we're using the real thing

            // Kick off the UI.
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
