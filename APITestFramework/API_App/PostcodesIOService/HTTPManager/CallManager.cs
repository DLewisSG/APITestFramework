﻿using System;
using System.Threading.Tasks;
using RestSharp;

namespace API_App.PostcodesIOService
{
    public class CallManager
    {
        // Restsharp object which handles comunitcation wiith the API
        readonly IRestClient _client;

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        /// <summary>
        /// Defines and makes the API request, and stores the response
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns>The response content</returns>
        public async Task<string> MakeSinglePostcodeRequest(string postcode)
        {

        }
    }
}
