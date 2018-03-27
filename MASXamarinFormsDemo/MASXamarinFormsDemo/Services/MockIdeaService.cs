using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MASXamarinFormsDemo.Models;

[assembly: Xamarin.Forms.Dependency(typeof(MASXamarinFormsDemo.Services.MockIdeaService))]
namespace MASXamarinFormsDemo.Services
{
    /// <inheritdoc />
    public class MockIdeaService : IIdeaService<Idea>
    {
        private readonly List<Idea> _ideas;

        public MockIdeaService()
        {
            _ideas = new List<Idea>();
            PopulateMockData();
        }

        private void PopulateMockData()
        {
            var mockItems = new List<Idea>
            {
                new Idea { Id = Guid.NewGuid(), Title = "The Computer", Description = "What a great idea!" },
                new Idea { Id = Guid.NewGuid(), Title = "The Copernican Revolution", Description = "What a great idea!" },
                new Idea { Id = Guid.NewGuid(), Title = "The Onion", Description = "What a great idea!" },
                new Idea { Id = Guid.NewGuid(), Title = "Relativity", Description = "What a great idea!" },
                new Idea { Id = Guid.NewGuid(), Title = "Quantum Theory", Description = "What a great idea!" },
                new Idea { Id = Guid.NewGuid(), Title = "Virtual Reality", Description = "What a great idea!" }
            };

            foreach (var item in mockItems)
            {
                _ideas.Add(item);
            }
        }

        #region Interface Required Items

        public async Task<string> GetCurrentUserName()
        {
            return "John Q. Public";
        }

        /// <inheritdoc />
        public async Task<bool> AddIdeaAsync(Idea idea)
        {
            _ideas.Add(idea);

            return await Task.FromResult(true);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateIdeaAsync(Idea idea)
        {
            var _item = _ideas.FirstOrDefault(arg => arg.Id == idea.Id);
            _ideas.Remove(_item);
            _ideas.Add(idea);

            return await Task.FromResult(true);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteIdeaAsync(Idea idea)
        {
            var _item = _ideas.FirstOrDefault(arg => arg.Id == idea.Id);
            _ideas.Remove(_item);

            return await Task.FromResult(true);
        }

        /// <inheritdoc />
        public async Task<Idea> GetIdeaAsync(Guid id)
        {
            return await Task.FromResult(_ideas.FirstOrDefault(s => s.Id == id));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Idea>> GetIdeasAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_ideas);
        }

        /// <inheritdoc />
        public bool IsAuthenticated { get; set; } = false;

        /// <inheritdoc />
        public async Task<bool> LogIn(string username, string password)
        {
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> LogOut()
        {
            return true;
        }

        #endregion

    }
}