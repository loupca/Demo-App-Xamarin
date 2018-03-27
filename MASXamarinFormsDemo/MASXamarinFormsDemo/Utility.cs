using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MASXamarinFormsDemo.Views;
using Xamarin.Forms;

namespace MASXamarinFormsDemo
{
    public static class Utility
    {
        public static async Task<bool> EnsureLoggedIn(ContentPage page, bool showMustLoginAlert)
        {
            // Make sure they're logged in.
            if (App.IdeaService.IsAuthenticated) return true;

            // Optionally, let them know they need to login, then show them the login prompt.
            if (showMustLoginAlert)
                await page.DisplayAlert(
                    Strings.AlertTitle_Info,
                "You must log in before performing this action.",
                "OK");

            await page.Navigation.PushModalAsync(new LoginPage());
            return false;
        }
    }
}
