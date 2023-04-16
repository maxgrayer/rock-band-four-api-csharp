using System;
using Microsoft.EntityFrameworkCore;
using RockBand4.API.DbContext;
using RockBand4.API.Models;

namespace RockBand4.API.Services
{
	public class SongService : ISongService
	{
        private readonly MariaDbContext _dbContext;

        public SongService(MariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(PersistedSong song)
        {
            _dbContext.Songs.Add(song);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                _dbContext.Songs.Remove(
                    new PersistedSong
                    {
                        Id = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<PersistedSong?> Get(int id)
        {
            return await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PersistedSong>> GetAll()
        {
            return await _dbContext.Songs.ToListAsync();
        }

        public async Task<int> Update(PersistedSong song)
        {
            try
            {
                _dbContext.Songs.Update(song);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}

