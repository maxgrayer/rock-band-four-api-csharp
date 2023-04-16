using System;
using RockBand4.API.Models;

namespace RockBand4.API.Services
{
    /// <summary>
    /// A service for interacting with <see cref="PersistedSong"/> models.
    /// </summary>
	public interface ISongService
	{
        /// <summary>
        /// Fetches all records.
        /// </summary>
        /// <returns>A collection of <see cref="PersistedSong"/> models.</returns>
        public Task<IEnumerable<PersistedSong>> GetAll();

        /// <summary>
        /// Retrieves a single <see cref="PersistedSong"/> model.
        /// </summary>
        /// <param name="id">The identifier of the record to retrieve.</param>
        /// <returns>The <see cref="PersistedSong"/> model, if found.</returns>
        public Task<PersistedSong?> Get(int id);

        /// <summary>
        /// Adds a new <see cref="PersistedSong"/> model.
        /// </summary>
        /// <param name="song">The model to persist.</param>
        /// <returns>The code for the outcome of the operation.</returns>
        public Task<int> Create(PersistedSong song);

        /// <summary>
        /// Updates a existing <see cref="PersistedSong"/> model.
        /// </summary>
        /// <param name="song">The model to revise.</param>
        /// <returns>The code for the outcome of the operation.</returns>
        public Task<int> Update(PersistedSong song);

        /// <summary>
        /// Removes a single <see cref="PersistedSong"/> model.
        /// </summary>
        /// <param name="id">The identifier of the record to remove.</param>
        /// <returns>The code for the outcome of the operation.</returns>
        public Task<int> Delete(int id);
    }
}

