using System;
using System.Linq;
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
                _dbContext.Songs.Remove(new PersistedSong { Id = id });
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

        public async Task<int> Sync()
        {
            var currentLocalSongList = await _dbContext.Songs.ToListAsync();
            var currentExternalSongList = await MakeExternalSongRequest();

            if (currentExternalSongList == null)
            {
                return -1;
            }

            try
            {
                foreach (var externalSong in currentExternalSongList)
                {
                    if (!currentLocalSongList.Any(item => item.ShortName == externalSong.SongID))
                    {
                        _dbContext.Songs.Add(new PersistedSong(externalSong));
                    }
                }

                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private async Task<IEnumerable<ExternalSong>?> MakeExternalSongRequest()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://rb4.app");
            var response = await httpClient.GetAsync("SongList");

            if (!response.IsSuccessStatusCode)
            {
                return new List<ExternalSong>();
            }

            return await response.Content.ReadFromJsonAsync<List<ExternalSong>>();
        }
    }
}

