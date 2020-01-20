using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemWspomagania.API.Models;

namespace SystemWspomagania.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Soldier> Login(string username, string password)
        {
            var soldier = await _context.Soldiers.FirstOrDefaultAsync(x => x.Username == username);

            if (soldier == null)
                return null;
                
            if (!VerifyPasswordHash(password, soldier.PasswordHash, soldier.PasswordSalt))
                return null;

            return soldier;

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<Soldier> Register(Soldier soldier, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            soldier.PasswordHash = passwordHash;
            soldier.PasswordSalt = passwordSalt;

            await _context.Soldiers.AddAsync(soldier);
            await _context.SaveChangesAsync();

            return soldier;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Soldiers.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
    }
}