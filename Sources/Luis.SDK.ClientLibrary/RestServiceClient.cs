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
        protected virtual new Task<TResponse> GetAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody) {
            return base.GetAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        protected virtual new Task<TResponse> PostAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return base.PostAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        protected virtual Task<TResponse> PutAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return SendAsync<TRequest, TResponse>(HttpMethod.Put, apiUrl, requestBody);
        }

        protected virtual Task<TResponse> DeleteAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return SendAsync<TRequest, TResponse>(HttpMethod.Delete, apiUrl, requestBody);
        }

        #region IRestServiceClient implementation

        Task<TResponse> IRestServiceClient.GetAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return GetAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        Task<TResponse> IRestServiceClient.PostAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return PostAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        Task<TResponse> IRestServiceClient.PutAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return PutAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        Task<TResponse> IRestServiceClient.DeleteAsync<TRequest, TResponse>(string apiUrl, TRequest requestBody)
        {
            return DeleteAsync<TRequest, TResponse>(apiUrl, requestBody);
        }

        #endregion
    }
}
