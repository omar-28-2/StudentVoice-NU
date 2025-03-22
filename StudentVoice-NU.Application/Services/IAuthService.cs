namespace StudentVoiceNU.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> AuthenticateWithFirebaseAsync(string firebaseToken);
    }
}
