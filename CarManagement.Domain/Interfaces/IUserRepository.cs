using CarManagement.Domain.Entities;
using System.Text;

namespace CarManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
      Task<User> RegisterUser(User user, CancellationToken token);
      Task<User> Login(string email, string password, CancellationToken token);
      string Hash(string password);
      bool Verify(string password, string hash);
      string Generate(User user);
      Task<User?> GetByEmailAsync(string email);
      Task UpdateAsync(User user);
    }
}
