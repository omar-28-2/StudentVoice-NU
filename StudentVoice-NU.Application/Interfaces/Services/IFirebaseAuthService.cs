namespace StudentVoiceNU.Application.Interfaces.Services
{
    using System.Threading.Tasks;
    using FirebaseAdmin.Auth;

    public interface IFirebaseAuthService
    {
        Task<FirebaseToken> VerifyTokenAsync(string idToken);
    }
}
