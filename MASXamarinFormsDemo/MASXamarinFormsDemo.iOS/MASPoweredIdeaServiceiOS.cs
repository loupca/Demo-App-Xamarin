using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MASXamarinFormsDemo.iOS;
using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.Services;

namespace MASXamarinFormsDemo.iOS
{
    public class MASPoweredIdeaServiceiOS : IIdeaService<Idea>
    {
        #region Interface Required Functions

        /// <inheritdoc />
        public bool IsAuthenticated { get; set; }

        public Task<bool> LogIn()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCurrentUserName()
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
        public Task<Idea> GetIdeaAsync(Guid id)
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
