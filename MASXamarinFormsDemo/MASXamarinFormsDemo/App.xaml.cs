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

            // Kick off the UI.
            MainPage = new MainPage();
        }

        public static void RaiseAuthChanged()
        {
            MessagingCenter.Send(IdeaService, "AuthChanged", "stub");
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
