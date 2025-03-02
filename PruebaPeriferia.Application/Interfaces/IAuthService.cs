using PruebaPeriferia.Domain.Enums;

namespace PruebaPeriferia.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string name);
        string GenerateToken(string username);
    }
}
