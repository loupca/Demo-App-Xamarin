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

        public async Task<bool> LogIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<bool> LogOut()
        {
            var funcName = "LogOut";

            try
            {
                // Check if user is already authenticated
                if (IsAuthenticated)
                {
                    MASUser.CurrentUser.Logout(null);
                    return true;
                }

                return true; // already logged in
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        public async Task<string> GetCurrentUserName()
        {
            var funcName = "GetCurrentUserName";

            try
            {
                // Check if user is already authenticated
                if (IsAuthenticated)
                {
                    return MASUser.CurrentUser.DisplayName;
                }

                return null; // already logged in
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return null;
            }
        }

        /// <inheritdoc />
        public async Task<bool> AddIdeaAsync(Idea item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateIdeaAsync(Idea item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<bool> DeleteIdeaAsync(Idea item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<Idea> GetIdeaAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Idea>> GetIdeasAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
