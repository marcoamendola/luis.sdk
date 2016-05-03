using Microsoft.ProjectOxford.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk
{

    internal interface IRestServiceClient
    {
        Task<TResponse> GetAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody);
        Task<TResponse> PostAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody);
        Task<TResponse> PutAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody);
        Task<TResponse> DeleteAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody);
    }


    public abstract class RestServiceClient : ServiceClient, IRestServiceClient
    {
        
        protected async Task<TResponse> PutAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return await SendAsync<TRequest, TResponse>(HttpMethod.Put, apiUrl, requestBody);
        }

        protected async Task<TResponse> DeleteAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return await SendAsync<TRequest, TResponse>(HttpMethod.Delete, apiUrl, requestBody);
        }

        #region IRestServiceClient implementation

        async Task<TResponse> IRestServiceClient.GetAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return await GetAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        async Task<TResponse> IRestServiceClient.PostAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return await PostAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        async Task<TResponse> IRestServiceClient.PutAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return await PutAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        async Task<TResponse> IRestServiceClient.DeleteAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return await DeleteAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        #endregion
    }
}
