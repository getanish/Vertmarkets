﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VertMarkets.Entities;
using VertMarkets.Interfaces;

namespace VertMarkets.ServiceAgents
{
    /// <summary>
    /// MagazineStore Service Agent
    /// </summary>
    /// <seealso cref="VertMarkets.Interfaces.IMagazineStoreSa" />
    public class MagazineStoreSa : IMagazineStoreSa
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly MagazineStoreConfiguration _configuration;
        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;
        /// <summary>
        /// The content type json
        /// </summary>
        private const string ContentTypeJson = "application/json";
        /// <summary>
        /// The token
        /// </summary>
        private string _token;


        /// <summary>
        /// Initializes a new instance of the <see cref="MagazineStoreSa" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MagazineStoreSa(IOptions<MagazineStoreConfiguration> options) :
            this(options, new HttpClient())
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MagazineStoreSa" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <exception cref="ArgumentException">BaseUrl</exception>
        public MagazineStoreSa(IOptions<MagazineStoreConfiguration> options, HttpClient httpClient)
        {
            _configuration = options.Value;
            _client = httpClient;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentTypeJson));
            _client.Timeout = TimeSpan.FromSeconds(_configuration.TimeOutInSeconds);
            if (string.IsNullOrEmpty(_configuration.BaseUrl))
            {
                throw new ArgumentException(nameof(_configuration.BaseUrl));
            }
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetCategories()
        {
            var url = $"{_configuration.BaseUrl}/api/categories/{await GetToken()}";
            var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response?.StatusCode is HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<CategoriesResponse>(responseContent)?.Data ??
                       throw new Exception("Failed to get categories");

            throw new Exception("Failed to get categories");
        }

        /// <summary>
        /// Gets the subscribers.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Subscriber>> GetSubscribers()
        {
            var url = $"{_configuration.BaseUrl}/api/subscribers/{await GetToken()}";
            var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response?.StatusCode is HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<SubscriberResponse>(responseContent)?.Data ??
                       throw new Exception("Failed to get subscribers");

            throw new Exception("Failed to get subscribers");
        }

        /// <summary>
        /// Gets the magazines.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public async Task<List<Magazine>> GetMagazines(string category)
        {
            var url = $"{_configuration.BaseUrl}/api/magazines/{await GetToken()}/{category}";
            var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response?.StatusCode is HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<MagazineResponse>(responseContent)?.Data ??
                       throw new Exception("Failed to get magazines");

            throw new Exception("Failed to get magazines");
        }

        /// <summary>
        /// Submits the answer.
        /// </summary>
        /// <param name="subcribers">The subcribers.</param>
        /// <returns></returns>
        public async Task<SubmissionResponse> SubmitAnswer(IEnumerable<string> subcribers)
        {
            var url = $"{_configuration.BaseUrl}/api/answer/{await GetToken()}";
            var data = JsonConvert.SerializeObject(new ApiAnswer { Subscribers = subcribers });
            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new StringContent(data, Encoding.UTF8, ContentTypeJson) }; ;
            var response = await _client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response?.StatusCode is HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<SubmissionResponse>(responseContent) ??
                       throw new Exception("Failed to sumbit answer");

            throw new Exception("Failed to sumbit answer");

        }



        private async Task<string> GetToken()
        {
            return _token ?? (_token = await GetTokenFromService());
            async Task<String> GetTokenFromService()
            {
                var url = $"{_configuration.BaseUrl}/api/token";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await _client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response?.StatusCode is HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<ApiResponse>(responseContent)?.token ??
                           throw new Exception("Failed to get token");

                throw new Exception("Failed to get token");
            }
        }


    }
}
