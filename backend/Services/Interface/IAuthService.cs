using backend.Models.Data;
using backend.Models.Dto;

namespace backend.Services.Interface
{
    public interface IAuthService
    {
        public string? Authenticate(AuthDto authDto);
        public string? GenerateJWTToken(User user);
    }
}
