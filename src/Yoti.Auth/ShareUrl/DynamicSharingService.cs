﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Yoti.Auth.Exceptions;

namespace Yoti.Auth.ShareUrl
{
    public static class DynamicSharingService
    {
        internal static async Task<ShareUrlResult> CreateShareURL(HttpClient httpClient, IHttpRequester httpRequester, string apiUrl, string sdkId, AsymmetricCipherKeyPair keyPair, DynamicScenario dynamicScenario)
        {
            Validation.NotNull(httpClient, "HTTP Client");
            Validation.NotNull(httpRequester, "HTTP Requester");
            Validation.NotNull(apiUrl, "API URL");
            Validation.NotNull(sdkId, "Client SDK ID");
            Validation.NotNull(keyPair, "Application Key Pair");
            Validation.NotNull(dynamicScenario, "Dynamic Scenario");

            string endpoint = EndpointFactory.CreateDynamicSharingPath(sdkId);
            HttpMethod httpMethod = HttpMethod.Post;

            try
            {
                string serializedScenario = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicScenario);
                byte[] body = Encoding.UTF8.GetBytes(serializedScenario);

                Dictionary<string, string> headers = HeadersFactory.Create(keyPair, httpMethod, endpoint, body);

                Response response = await httpRequester.DoRequest(
                    httpClient,
                    httpMethod,
                    new Uri(apiUrl + endpoint),
                    headers,
                    body).ConfigureAwait(false);

                if (!response.Success)
                {
                    Response.CreateExceptionFromStatusCode<DynamicShareException>(response);
                }

                var dynamicShareResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ShareUrlResult>(response.Content);

                return dynamicShareResult;
            }
            catch (Exception ex)
            {
                if (ex is DynamicShareException)
                    throw;

                throw new DynamicShareException(
                    $"Inner exception:{Environment.NewLine}{ex.Message}",
                    ex);
            }
        }
    }
}