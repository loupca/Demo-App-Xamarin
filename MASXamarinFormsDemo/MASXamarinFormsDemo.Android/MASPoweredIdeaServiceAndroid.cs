using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.CA.Mas.Foundation;
using MASXamarinFormsDemo.Droid;
using MASXamarinFormsDemo.Models;
using MASXamarinFormsDemo.Services;
using MASXamarinFormsDemo.Exceptions;
using MASXamarinFormsDemo.Models.JsonResponse;
using Newtonsoft.Json;
using Org.Json;

namespace MASXamarinFormsDemo.Droid
{
    public class MASPoweredIdeaServiceAndroid : IIdeaService<Idea>
    {

        #region Constructor and Class Vars

        /// <summary>
        /// Instance of the App's Main Activity.
        /// </summary>
        private readonly MainActivity _mainActivity;

        public MASPoweredIdeaServiceAndroid(MainActivity mainActivity)
        {
            _mainActivity = mainActivity;

            // Attempt to start MAS SDK.
            if (!StartSdkWithNonDefaultConfig()) throw new CouldNotStartMasException();
        }

        #endregion

        #region Interface Required Functions

        /// <inheritdoc />
        public bool IsAuthenticated => MASUser.CurrentUser?.IsAuthenticated ?? false;

        /// <inheritdoc />
        public async Task<bool> LogIn(string username, string password)
        {
            var funcName = "LogIn";

            try
            {
                // Check if user is already authenticated
                if (IsAuthenticated) return true;
                var callback = new LoginCallback();
                MASUser.Login(username, password.ToCharArray(), callback);


                const int MAX_TRIES = 10;
                var tries = 0;
                while (!IsAuthenticated && tries < MAX_TRIES && !callback.LoginErrorOccurred) // wait for a login to occur
                {
                    await Task.Delay(250); // check for login success
                    tries++;
                }

                return IsAuthenticated;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }

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

        /// <inheritdoc />
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
            var funcName = "AddIdeaAsync";

            try
            {
                // Enable debugging.
                MAS.Debug();

                // Use Uri.Builder() to build the Uri and pass it into a MASRequestBuilder.
                var uriBuilder = new Android.Net.Uri.Builder();

                // Append the endpoint path.
                uriBuilder.AppendEncodedPath("ideas");

                // Create the request builder.
                var builder = new MASRequestBuilder(uriBuilder.Build());

                // Build the new Idea object.
                var json = JsonConvert.SerializeObject(new IdeaCreateRequestJson
                {
                    Title = item.Title,
                    Description = item.Summary,
                    Department = item.Department
                });

                // Set the response type to JSON.
                builder.ResponseBody(MASResponseBody.JsonBody());
                builder.Post(MASRequestBody.JsonBody(new JSONObject(json))); // We're adding, so mark as POST. Default is GET.

                // Invoke the API.
                var request = builder.Build();
                var result = await MAS.Invoke(request);

                // Make sure we received an OK/200 response.
                if (!result.ResponseMessage.Equals("OK", StringComparison.InvariantCultureIgnoreCase))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        /// <inheritdoc />
        public async Task<bool> UpdateIdeaAsync(Idea item)
        {
            var funcName = "UpdateIdeaAsync";

            try
            {
                // Enable debugging.
                MAS.Debug();

                // Use Uri.Builder() to build the Uri and pass it into a MASRequestBuilder.
                var uriBuilder = new Android.Net.Uri.Builder();

                // Append the endpoint path.
                uriBuilder.AppendEncodedPath($"ideas/{item.Id}");

                // Create the request builder.
                var builder = new MASRequestBuilder(uriBuilder.Build());

                // Build the new Idea object.
                var json = JsonConvert.SerializeObject(new IdeaCreateRequestJson
                {
                    Title = item.Title,
                    Description = item.Summary,
                    Department = item.Department
                });

                // Set the response type to JSON.
                builder.ResponseBody(MASResponseBody.JsonBody());
                builder.Put(MASRequestBody.JsonBody(new JSONObject(json))); // We're updating, so mark as PUT. Default is GET.

                // Invoke the API.
                var request = builder.Build();
                var result = await MAS.Invoke(request);

                // Make sure we received an OK/200 response.
                if (!result.ResponseMessage.Equals("OK", StringComparison.InvariantCultureIgnoreCase))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        /// <inheritdoc />
        public async Task<bool> DeleteIdeaAsync(Idea item)
        {
            var funcName = "UpdateIdeaAsync";

            try
            {
                // Enable debugging.
                MAS.Debug();

                // Use Uri.Builder() to build the Uri and pass it into a MASRequestBuilder.
                var uriBuilder = new Android.Net.Uri.Builder();

                // Append the endpoint path.
                uriBuilder.AppendEncodedPath($"ideas/{item.Id}");

                // Create the request builder.
                var builder = new MASRequestBuilder(uriBuilder.Build());

                // Set the response type to JSON.
                builder.ResponseBody(MASResponseBody.JsonBody());
                builder.Delete(null); // We're deleting, so mark as DELETE. Default is GET.

                // Invoke the API.
                var request = builder.Build();
                var result = await MAS.Invoke(request);

                // Make sure we received an OK/200 response.
                if (!result.ResponseMessage.Equals("OK", StringComparison.InvariantCultureIgnoreCase))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return false;
            }
        }

        /// <inheritdoc />
        public async Task<Idea> GetIdeaAsync(Guid id)
        {
            var funcName = "GetIdeaAsync";

            try
            {
                return new Idea();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return new Idea();
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Idea>> GetIdeasAsync(bool forceRefresh = false)
        {
            var funcName = "GetIdeasAsync";

            try
            {
                MAS.Debug();

                // Use Uri.Builder() to build the Uri and pass it into a MASRequestBuilder.
                var uriBuilder = new Android.Net.Uri.Builder();

                // Append the endpoint path.
                uriBuilder.AppendEncodedPath("ideas");

                // Create the request builder.
                var builder = new MASRequestBuilder(uriBuilder.Build());

                // Set the response type to JSON.
                builder.ResponseBody(MASResponseBody.JsonBody());

                // Invoke the API.
                var request = builder.Build();
                var result = await MAS.Invoke(request);

                // Make sure we received an OK/200 response.
                if (!result.ResponseMessage.Equals("OK", StringComparison.InvariantCultureIgnoreCase))
                    return new List<Idea>()
                    {
                        new Idea { Id = Guid.NewGuid(), Summary = "Could not read data from endpoint.", Title = "Error" }
                    };

                var serverResponse = JsonConvert.DeserializeObject<List<IdeaListResponseJson>>(Encoding.UTF8.GetString(result.Body.GetRawContent()));

                return serverResponse.Select(item => new Idea
                {
                    Id = item.Id,
                    Title = item.Title,
                    Summary = item.Description
                }).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {funcName}(): {ex.GetBaseException().Message}");
                return new List<Idea>();
            }

        }


        #endregion

        #region SDK Configuration Functions

        /// <summary>
        /// Start SDK with default after changing the default configuration file
        /// </summary>
        /// <param name="activity"></param>
        public bool StartSdkWithNonDefaultConfig()
        {
            var funcName = "StartSDKChangeDefaultConfig";

            try
            {
                if (IsSdkInitialized(_mainActivity)) return true;

                // Change the default Configuration
                // Example: MAS.SetConfigurationFileName("custom.json");
                MAS.SetConfigurationFileName("msso_config_public.json");

                // Set the credential flow.
                MAS.SetGrantFlow(MASConstants.MasGrantFlowClientCredentials);

                // Usage: MAS.Start(Context context, bool shouldUseDefault);
                MAS.Start(_mainActivity, true);

                return IsSdkInitialized(_mainActivity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{funcName}(): CA Mobile SDK could not start. Exception was: {ex.GetBaseException().Message}");
                return false;
            }
        }

        /// <summary>
        /// Return whether the SDK is Initialized.
        /// </summary>
        /// <param name="activity"></param>
        public static bool IsSdkInitialized(MainActivity activity)
        {
            var funcName = "IsSdkInitialized";

            if (MAS.GetState(activity.ApplicationContext) == MASConstants.MasStateStarted)
            {
                Console.WriteLine($"{funcName}(): CA Mobile SDK started successfully!!");
                return true;
            }

            Console.WriteLine($"{funcName}(): CA Mobile SDK could not start!!");
            return false;
        }

        #endregion

    }
}