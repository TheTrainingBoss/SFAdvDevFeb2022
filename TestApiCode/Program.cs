using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TestApiCode
{
    public class Program
    {
        private static TokenClient tokenClient;

        public static void Main(string[] args)
        {
            // The token client is used to make calls to the STS endpoint where you can retrieve the access token.
            // The AuthenticationStyle.PostValues tells that the parameters will be send into the body of the request
            // For the different Authentication Styles please check https://github.com/IdentityModel/IdentityModel
            tokenClient = new TokenClient(TokenEndpoint, ClientId, ClientSecret, AuthenticationStyle.PostValues);
            TokenResponse tokenResponse = RequestToken();
            string accessToken = tokenResponse.AccessToken;
            //The purpose of the refresh token is to retrieve new access token when the ols expires
            string refreshToken = tokenResponse.RefreshToken;
            Console.WriteLine("Access token: {0}", accessToken);
            Console.WriteLine("Refresh token: {0}", refreshToken);
            string reponseHtml = CallApi(accessToken);
            Console.WriteLine("Api Response: {0}", reponseHtml);
            var newTokenResponse = RefreshToken(refreshToken);
            Console.WriteLine("New access token: {0}", accessToken);
            Console.WriteLine("New refresh token: {0}", refreshToken);
        }

        public static TokenResponse RequestToken()
        {
            //This is call to the token endpoint with the parameters that are set
            TokenResponse tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync(Username, Password, AdditionalParameters).Result;

            if (tokenResponse.IsError)
            {
                throw new ApplicationException("Couldn't get access token. Error: " + tokenResponse.Error);
            }

            return tokenResponse;
        }

        public static string CallApi(string accessToken)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WebApiNewsEndPoint);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + accessToken);

            string html = string.Empty;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }

        public static TokenResponse RefreshToken(string refreshToken)
        {
            //This is call to the token endpoint that can retrieve new access and refresh token from the current refresh token
            return tokenClient.RequestRefreshTokenAsync(refreshToken).Result;
        }

        public const string ClientId = "postman";
        public const string ClientSecret = "secret";
        public const string TokenEndpoint = "http://localhost:56995/Sitefinity/oauth/token";
        public const string Username = "nick@foo.com";
        public const string Password = "admin1234";
        public static readonly Dictionary<string, string> AdditionalParameters = new Dictionary<string, string>()
        {
            { "membershipProvider", "Default" }
        };
        public const string WebApiNewsEndPoint = "http://localhost:56995/api/default/newsitems";
    }
}