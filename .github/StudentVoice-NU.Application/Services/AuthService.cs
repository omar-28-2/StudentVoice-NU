namespace StudentVoiceNU.Application.Services
{
    using Azure.Identity;
    using Microsoft.Graph;
    using StudentVoiceNU.Application.Interfaces.Services;
    using System;
    using System.Threading.Tasks;

    public class AuthService : IAuthService
    {
        private readonly IFirebaseAuthService _firebaseAuthService;

        public AuthService(IFirebaseAuthService firebaseAuthService)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        public async Task<string> AuthenticateWithFirebaseAsync(string firebaseToken)
        {
            var decodedToken = await _firebaseAuthService.VerifyTokenAsync(firebaseToken);
            var email = decodedToken.Claims["email"]?.ToString();

            if (string.IsNullOrEmpty(email))
            {
                throw new UnauthorizedAccessException("Email not found in Firebase token.");
            }

            return await GetNUIdFromEntraAsync(email);
        }

        private async Task<string> GetNUIdFromEntraAsync(string email)
        {
            var tenantId = "2b773d99-f229-4704-b562-5a3198831779"; //  Tenant ID
            var clientId = "a28dce4b-eaf3-44d3-bf5d-a00ad0d8d2be"; //  Client ID
            var clientSecret = "ac6a5ea5-312e-44cc-8255-5c7d8275d625"; //  Client Secret

            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var graphClient = new GraphServiceClient(credential, new[] { "https://graph.microsoft.com/.default" });

            try
            {
                var user = await graphClient.Users[email].GetAsync();
                return user?.Id ?? "UserNotFound"; 
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                return "ErrorFetchingUser"; 
            }
        }
    }
}
