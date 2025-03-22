namespace StudentVoiceNU.Infrastructure.Services
{
    using FirebaseAdmin;
    using FirebaseAdmin.Auth;
    using Google.Apis.Auth.OAuth2;
    using StudentVoiceNU.Application.Interfaces.Services;
    using System.Threading.Tasks;

    public class FirebaseAuthService : IFirebaseAuthService
    {
        private readonly FirebaseApp _firebaseApp;

        public FirebaseAuthService()
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                _firebaseApp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("F:\\semester 6\\project gdg\\StudentVoice-NU\\StudentVoice-NU.API\\Secrets\\student-voice-f22b7-firebase-adminsdk-fbsvc-ab5c4645b9.json"),
                });
            }
            else
            {
                _firebaseApp = FirebaseApp.DefaultInstance; 
            }
        }

        public async Task<FirebaseToken> VerifyTokenAsync(string idToken)
        {
            return await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
        }
    }
}
