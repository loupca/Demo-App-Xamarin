using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MASXamarinFormsDemo.Models;

namespace MASXamarinFormsDemo.Services
{
    public class MASPoweredIdeaService : IIdeaService<Idea>
    {

        #region Interface Required Items

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
