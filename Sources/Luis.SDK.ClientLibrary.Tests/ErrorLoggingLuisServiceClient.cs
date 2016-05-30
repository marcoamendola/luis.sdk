using Luis.Sdk;
using Microsoft.ProjectOxford.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.SDK.ClientLibrary.Tests
{
    class ErrorLoggingLuisServiceClient : LuisServiceClient
    {
        public ErrorLoggingLuisServiceClient(string subscriptionKey) : base(subscriptionKey)
        {
        }

        protected override Task<TResponse> GetAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return WithErrorLogging(
                base.GetAsync<TRequest, TResponse>(apiUrl, requestBody)
            );
        }
        protected override Task<TResponse> PostAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return WithErrorLogging(
                base.PostAsync<TRequest, TResponse>(apiUrl, requestBody)
            );
        }
        protected override Task<TResponse> PutAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return WithErrorLogging(
                base.PutAsync<TRequest, TResponse>(apiUrl, requestBody)
            );
        }
        protected override Task<TResponse> DeleteAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return WithErrorLogging(
                base.DeleteAsync<TRequest, TResponse>(apiUrl, requestBody)
            );
        }

        Task<TResponse> WithErrorLogging<TResponse>(Task<TResponse> task)
        {
            task.ContinueWith(t =>
            {
                var ex = task.Exception.InnerException as ClientException;
                if (ex != null)
                {
                    Debug.WriteLine($"{ex.Error.Code}: {ex.Error.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

            return task;
        }
    }
}
