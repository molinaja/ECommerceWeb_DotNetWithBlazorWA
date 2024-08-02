using Blazored.SessionStorage;
using ECommerceWeb.Dto.Response;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace ECommerceWeb.Client.Auth
{
    public class AuthenticationService(ISessionStorageService sessionStorageService, HttpClient httpClient) : AuthenticationStateProvider
    {

        private readonly ISessionStorageService _sessionStorageService = sessionStorageService;
        private readonly HttpClient _httpClient = httpClient;
        private readonly ClaimsPrincipal _anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly string _sessionUser = "loginSession";
        private readonly string _authenticationType = "JWT";

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sessionUser = await _sessionStorageService.GetItemAsync<LoginDtoResponse>(_sessionUser);
            if (sessionUser == null)//is null when end session or user delete de sesion or closed the tab in the browser
            {

                return await Task.FromResult(new AuthenticationState(_anonymousUser));
            }

            var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new ClaimsIdentity(
                        ConvertToken(sessionUser.Token).Claims, authenticationType: _authenticationType)
                )
             );

            return await Task.FromResult(
                new AuthenticationState(claimsPrincipal)
                );
        }

        public async Task Authenticate(LoginDtoResponse? response)
        {

            ClaimsPrincipal claimsPrincipal;

            if (response != null)
            {

                //declare and add token in obj httpclient
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);

                //recovered the claims from token received
                var jwtToken = ConvertToken(response.Token);
                claimsPrincipal = new ClaimsPrincipal(
                    new ClaimsIdentity(
                        jwtToken.Claims, authenticationType: _authenticationType
                    )
                );

                //set the session in a session manager fot auth the user
                await _sessionStorageService.SetItemAsync(_sessionUser, response);

            }
            else
            {

                claimsPrincipal = _anonymousUser;
                await _sessionStorageService.RemoveItemAsync(_sessionUser);
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(
                    new AuthenticationState(claimsPrincipal)
                )
            );

        }

        private JwtSecurityToken ConvertToken(string tokenSerialized)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenSerialized);
            return token;
        }

    }
}
