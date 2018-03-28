using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MASFoundation;
using MASXamarinFormsDemo.Exceptions;
using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.Models.JsonResponse;
using MASXamarinFormsDemo.Services;
using Newtonsoft.Json;

namespace MASXamarinFormsDemo.iOS
{
    public class MasPoweredIdeaServiceiOS : IIdeaService<Idea>
    {
        public MasPoweredIdeaServiceiOS()
        {
            // Attempt to start MAS SDK.
            StartSdkWithNonDefaultConfig();
        }

        #region Interface Required Functions

        /// <inheritdoc />
        public bool IsAuthenticated { get; set; }

        public async Task<bool> LogIn(string username, string password)
        {
            var result = false;
            MASUser.LoginWithUserName(username, password, completion: (completed, error) =>
            {
                if (completed)
                {
                    // Logged in without an error
                    result = true;
                }

                if (error != null)
                {
                    // Logged in with an error
                    result = false;
                }
            });

            return result;
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
                    MASUser.CurrentUser.LogoutWithCompletion(null);
                    return true;
                }

                return true; // already logged in
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        public async Task<string> GetCurrentUserName()
        {
            var funcName = "GetCurrentUserName";

            try
            {
                // Check if user is already authenticated
                return IsAuthenticated ? MASUser.CurrentUser?.UserName ?? "n/a" : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error in {funcName}(): {ex.GetBaseException().Message}");
                return null;
            }
        }

        /// <inheritdoc />
        public async Task<bool> AddIdeaAsync(Idea item)
        {
            var funcName = "AddIdeaAsync";
            var result = false;

            try
            {
                //  Create MASRequestBuilder with HTTP method.
                var requestBuilder = new MASRequestBuilder("GET")
                {
                    EndPoint = "ideas"
                };

                //  Build MASRequestBuilder to convert into MASRequest object
                var request = requestBuilder.Build();

                //  Using MASRequest object, invoke API
                MAS.Invoke(request, completion: (response, responseObject, error) =>
                {
                    if (error != null)
                    {
                        //  If an error was returned
                        Console.WriteLine($@"{funcName}(): Error: {error.LocalizedDescription}");
                        result = true;
                    }
                    else if (responseObject != null)
                    {
                        Console.WriteLine($@"{funcName}(): Success: {responseObject.ToString()}");
                        result = false;
                    }
                });

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        /// <inheritdoc />
        public async Task<bool> UpdateIdeaAsync(Idea item)
        {
            var funcName = "UpdateIdeaAsync";
            var result = false;

            try
            {
                //  Create MASRequestBuilder with HTTP method.
                var requestBuilder = new MASRequestBuilder("PUT")
                {
                    EndPoint = "ideas"
                };

                //  Build MASRequestBuilder to convert into MASRequest object
                var request = requestBuilder.Build();

                //  Using MASRequest object, invoke API
                MAS.Invoke(request, completion: (response, responseObject, error) =>
                {
                    if (error != null)
                    {
                        //  If an error was returned
                        Console.WriteLine($@"{funcName}(): Error: {error.LocalizedDescription}");
                        result = true;
                    }
                    else if (responseObject != null)
                    {
                        Console.WriteLine($@"{funcName}(): Success: {responseObject.ToString()}");
                        result = false;
                    }
                });

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        /// <inheritdoc />
        public async Task<bool> DeleteIdeaAsync(Idea item)
        {
            var funcName = "DeleteIdeaAsync";
            var result = false;

            try
            {
                //  Create MASRequestBuilder with HTTP method.
                var requestBuilder = new MASRequestBuilder("DELETE")
                {
                    EndPoint = $"ideas/{item.Id}"
                };

                //  Build MASRequestBuilder to convert into MASRequest object
                var request = requestBuilder.Build();

                //  Using MASRequest object, invoke API
                MAS.Invoke(request, completion: (response, responseObject, error) =>
                {
                    if (error != null)
                    {
                        //  If an error was returned
                        Console.WriteLine($@"{funcName}(): Error: {error.LocalizedDescription}");
                        result = true;
                    }
                    else if (responseObject != null)
                    {
                        Console.WriteLine($@"{funcName}(): Success: {responseObject.ToString()}");
                        result = false;
                    }
                });

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        /// <inheritdoc />
        public async Task<Idea> GetIdeaAsync(Guid id)
        {
            var funcName = "AddIdeaAsync";
            var result = new Idea();

            try
            {
                //  Create MASRequestBuilder with HTTP method.
                var requestBuilder = new MASRequestBuilder("GET")
                {
                    EndPoint = $@"ideas/{id}"
                };

                //  Build MASRequestBuilder to convert into MASRequest object
                var request = requestBuilder.Build();

                //  Using MASRequest object, invoke API
                MAS.Invoke(request, completion: (response, responseObject, error) =>
                {
                    if (error != null)
                    {
                        //  If an error was returned
                        Console.WriteLine($@"{funcName}(): Error: {error.LocalizedDescription}");
                    }
                    else if (responseObject != null)
                    {
                        Console.WriteLine($@"{funcName}(): Success: {responseObject.ToString()}");
                        var serverResponse = JsonConvert.DeserializeObject<IdeaResponseJson>(responseObject.ToString());
                        result.Title = serverResponse.Title;
                        result.Department = serverResponse.Department;
                        result.Description = serverResponse.Description;
                        result.Id = serverResponse.Id;
                    }
                });

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error in {funcName}(): {ex.GetBaseException().Message}");
                return result;
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Idea>> GetIdeasAsync(bool forceRefresh = false)
        {
            var funcName = "GetIdeasAsync";
            var result = new List<Idea>();

            try
            {
                //  Create MASRequestBuilder with HTTP method.
                var requestBuilder = new MASRequestBuilder("GET")
                {
                    EndPoint = "ideas"
                };

                //  Build MASRequestBuilder to convert into MASRequest object
                var request = requestBuilder.Build();

                //  Using MASRequest object, invoke API
                MAS.Invoke(request, completion: (response, responseObject, error) =>
                {
                    if (error != null)
                    {
                        //  If an error was returned
                        Console.WriteLine($@"{funcName}(): Error: {error.LocalizedDescription}");
                    }
                    else if (responseObject != null)
                    {
                        Console.WriteLine($@"{funcName}(): Success: {responseObject.ToString()}");
                        var serverResponse = JsonConvert.DeserializeObject<List<IdeaListResponseJson>>(responseObject.ToString());

                        result = serverResponse.Select(item => new Idea
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Description = item.Description,
                            Department = item.Department
                        }).ToList();

                    }
                });

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error in {funcName}(): {ex.GetBaseException().Message}");
                return result;
            }

        }



        #endregion

        #region SDK Configuration Functions

        /// <summary>
        /// Start SDK with default after changing the default configuration file
        /// </summary>
        /// <param name="activity"></param>
        public async void StartSdkWithNonDefaultConfig()
        {
            var funcName = "StartSdkWithNonDefaultConfig";

            try
            {
                MAS.SetConfigurationFileName("msso_config_public");
                MAS.GrantFlow = MASGrantFlow.ClientCredentials;
                if (MAS.MASState == MASState.DidStart) return; // already started
                var success = false;
                MAS.StartWithDefaultConfiguration(true, (result, error) =>
                {
                    success = error != null;
                    if (!success) throw new CouldNotStartMasException();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"{funcName}(): CA Mobile SDK could not start. Exception was: {ex.GetBaseException().Message}");
                throw;
            }
        }

        #endregion


    }
}
