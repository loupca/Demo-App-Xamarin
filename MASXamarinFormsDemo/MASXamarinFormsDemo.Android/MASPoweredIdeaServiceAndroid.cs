using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MASXamarinFormsDemo.Droid;
using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MASPoweredIdeaServiceAndroid))]
namespace MASXamarinFormsDemo.Droid
{
    class MASPoweredIdeaServiceAndroid : IIdeaService<Idea>
    {
        #region Interface Required Functions

        /// <inheritdoc />
        public bool IsAuthenticated { get; set; }

        /// <inheritdoc />
        public Task<bool> LogOut()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> AddIdeaAsync(Idea item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> UpdateIdeaAsync(Idea item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> DeleteIdeaAsync(Idea item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Idea> GetIdeaAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IEnumerable<Idea>> GetIdeasAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}