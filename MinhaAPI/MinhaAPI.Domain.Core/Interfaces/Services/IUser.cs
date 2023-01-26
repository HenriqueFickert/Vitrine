using System.Security.Claims;

namespace MinhaAPI.Domain.Core.Interfaces.Services
{
    public interface IUser
    {
        string Name { get; }

        bool IsAuthenticated();

        bool IsInRole(string role);

        Guid GetUserId();

        string GetUserEmail();

        string GetUserRole();

        IEnumerable<string> GetUserClaims();

        IEnumerable<Claim> GetClaimsIdentity();
    }
}