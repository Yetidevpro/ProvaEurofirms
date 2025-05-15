using Microsoft.EntityFrameworkCore;
using PruebaEurofirms.Domain.Models;
using PruebaEurofirms.Domain.Repositories;
using System;



namespace PruebaEurofirms.Infrastructure.Repositories
{
    public class SqliteCharacterRepository : ICharacterRepository
    {
        private readonly CharacterDbContext _context;

        public SqliteCharacterRepository(CharacterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetCharactersByStatusAsync(string status)
        {
            return await _context.Characters
                .Where(c => c.Status.ToLower() == status.ToLower())
                .ToListAsync();
        }


        public async Task<bool> SaveCharactersAsync(IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                if (!await _context.Characters.AnyAsync(c => c.CharacterId == character.CharacterId))
                {
                    _context.Characters.Add(character);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return false;

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }
    }
}
