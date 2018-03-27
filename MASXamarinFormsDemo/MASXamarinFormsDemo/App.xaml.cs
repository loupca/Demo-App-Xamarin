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

            // By default, for demo purposes, we'll log the current user out. 
            // Feel free to remove if you want the credentials saved between
            // app launches.
            IdeaService.LogOut();

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
