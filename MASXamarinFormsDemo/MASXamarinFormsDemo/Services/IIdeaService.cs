﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASXamarinFormsDemo.Services
{
    public interface IIdeaService<T>
    {
        /// <summary>
        /// Flags whether the user is currently authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Logs the user in. If the user is already logged in, True will be returned.
        /// </summary>
        Task<bool> LogIn(string username, string password);

        /// <summary>
        /// Logs the user out. If the user is not logged in, True will be returned.
        /// </summary>
        Task<bool> LogOut();

        /// <summary>
        /// Gets currently logged-in user's name. Returns null if not logged in.
        /// </summary>
        Task<string> GetCurrentUserName();

        /// <summary>
        /// Adds an Idea. Will automatically authenticate through MAS, if necessary.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> AddIdeaAsync(T item);

        /// <summary>
        /// Updates an Idea.  Will automatically authenticate through MAS, if necessary.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateIdeaAsync(T item);

        /// <summary>
        /// Deletes an Idea.  Will automatically authenticate through MAS, if necessary.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> DeleteIdeaAsync(T item);

        /// <summary>
        /// Retrieves an Idea.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetIdeaAsync(Guid id);

        /// <summary>
        /// Gets all Ideas.
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetIdeasAsync(bool forceRefresh = false);
    }
}
