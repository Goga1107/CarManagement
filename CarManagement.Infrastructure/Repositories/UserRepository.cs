using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using CarManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CarManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarDbContext _db;
        private readonly IConfiguration _config;

        public UserRepository(CarDbContext db,IConfiguration config)
        {
            _db = db;
            _config = config;
        }
      
        public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, string hash) => BCrypt.Net.BCrypt.Verify(password,hash);

        public async Task<User> Login(string email, string password, CancellationToken token)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == email, token);
            if (user == null)
            {
                return null;
            }
            bool isPasswordValid = Verify(password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return null;
            }
            return user;
        }

        public async Task<User> RegisterUser(User user, CancellationToken cancellation)
        {
            try
            {
                User us = new User
                {
                    FullName = user.FullName,
                    CreatedAt = DateTime.UtcNow,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Role = "Mechanic"
                };
                _db.Users.Add(us);
                await _db.SaveChangesAsync(cancellation);
                return us;
            }
            catch (Exception ex) {
                 
                Console.WriteLine($"error {ex.Message}");
                throw;
            }
        }

        public string Generate(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role) 
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
