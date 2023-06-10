using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace UsedGoodsStoreApp.Client.Services;

public class HttpService : IHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly NavigationManager _navigation;

    public HttpService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
    {
        _httpClientFactory = httpClientFactory;
        _navigation = navigationManager;

    }

    public async Task<T> Get<T>(string url)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("WebAPI");
            httpClient.BaseAddress = new Uri(_navigation.BaseUri);
            var response = await httpClient.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) //when controller returns null
            {
                return default(T);
            }

            var result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
            return default;
        }
    }

    public async Task<HttpResponseMessage> Post(string url, object data)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("WebAPI");

            httpClient.BaseAddress = new Uri(_navigation.BaseUri);
            return await httpClient.PostAsJsonAsync(url, data);
        }
        catch (Exception ex)
        {
            throw ex;
            return default;
        }
    }

    public async Task<TResponse> Post<TResponse>(string url, object data)
    {
        var response = await Post(url, data);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<HttpResponseMessage> Post(string url, HttpContent data)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("WebAPI");
            var response = await httpClient.PostAsync(url, data);
            return response;
        }
        catch (Exception ex)
        {
            throw ex;
            return default;
        }
    }

    public async Task<TResponse> Post<TResponse>(string url, HttpContent data)
    {
        var response = await Post("https://localhost:7106/" + url, data);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<HttpResponseMessage> Put(string url, object data)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("WebAPI");
            return await httpClient.PutAsJsonAsync(url, data);
        }
        catch (Exception ex)
        {
            throw ex;
            return default;
        }
    }

    public async Task<TResponse> Put<TResponse>(string url, object data)
    {
        var response = await Put(url, data);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<HttpResponseMessage> Delete(string url)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("WebAPI");
            return await httpClient.DeleteAsync(url);
        }
        catch (Exception ex)
        {
            throw ex;
            return default;
        }
    }

    public async Task<TResponse> Delete<TResponse>(string url)
    {
        var response = await Delete(url);
        if (response == null) return default;
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}