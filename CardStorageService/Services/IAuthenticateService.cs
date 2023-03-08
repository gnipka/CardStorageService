using CardStorageService.Models;
using CardStorageService.Models.Requests;

namespace CardStorageService.Services
{
    public interface IAuthenticateService
    {
        public AuthenticationResponse Login(AuthenticationRequest request);
        public SessionInfo GetSessionInfo(string sessionToken);
    }
}
