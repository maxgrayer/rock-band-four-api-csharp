using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBand4.API.Models
{
	/// <summary>
	/// Model representing a row from the database
	/// </summary>
	public class PersistedSong
	{
		public PersistedSong() { }

        /// <summary>
        /// Creates a new <see cref="PersistedSong"/> from a provided <see cref="ExternalSong"/>.
        /// </summary>
        /// <param name="externalSong">The external record to persist.</param>
        public PersistedSong(ExternalSong externalSong)
        {
            Id = externalSong.SongIDNumber;
            Artist = externalSong.Artist;
            Title = externalSong.Name;
            Album = externalSong.Album;
            TrackNumber = -1;
            Genre = externalSong.Genre;
            Year = externalSong.Year;
            Bpm = externalSong.BPM;
            Duration = externalSong.SongLength;
            DisplayRankGuitar = externalSong.GuitarDifficulty;
            DisplayRankBass = externalSong.BassDifficulty;
            DisplayRankDrums = externalSong.DrumsDifficulty;
            DisplayRankVocal = externalSong.VocalsDifficulty;
            DisplayRankBand = externalSong.BandDifficulty;
            ShortName = externalSong.SongID;
            ReleaseDate = externalSong.ReleaseDate;
            IsOwned = false;
            OnWishlist = false;
            SortArtist = externalSong.Artist2;
            SortTitle = externalSong.Name2;
            SortAlbum = externalSong.Album2;
            SortRankGuitar = externalSong.GuitarRanking;
            SortRankBass = externalSong.BassRanking;
            SortRankDrums = externalSong.DrumsRanking;
            SortRankVocal = externalSong.VocalsRanking;
            SortRankBand = externalSong.BandRanking;
            XboxStoreLink = externalSong.StoreLinkXbox;
            AwsArtworkLink = string.Empty;
        }

        public int? Id { get; set; }
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public string? Album { get; set; }
        [Column("track_num")]
        public int? TrackNumber { get; set; }
        public string? Genre { get; set; }
        public int? Year { get; set; }
        public int? Bpm { get; set; }
        public int? Duration { get; set; }
        [Column("display_rank_guitar")]
        public int? DisplayRankGuitar { get; set; }
        [Column("display_rank_bass")]
        public int? DisplayRankBass { get; set; }
        [Column("display_rank_drums")]
        public int? DisplayRankDrums { get; set; }
        [Column("display_rank_vocal")]
        public int? DisplayRankVocal { get; set; }
        [Column("display_rank_band")]
        public int? DisplayRankBand { get; set; }
        public string? ShortName { get; set; }
        [Column("release_date")]
        public string? ReleaseDate { get; set; }
        [Column("is_owned")]
        public bool? IsOwned { get; set; }
        [Column("on_wishlist")]
        public bool? OnWishlist { get; set; }
        [Column("sort_artist")]
        public string? SortArtist { get; set; }
        [Column("sort_title")]
        public string? SortTitle { get; set; }
        [Column("sort_album")]
        public string? SortAlbum { get; set; }
        [Column("sort_rank_guitar")]
        public int? SortRankGuitar { get; set; }
        [Column("sort_rank_bass")]
        public int? SortRankBass { get; set; }
        [Column("sort_rank_drum")]
        public int? SortRankDrums { get; set; }
        [Column("sort_rank_vocal")]
        public int? SortRankVocal { get; set; }
        [Column("sort_rank_band")]
        public int? SortRankBand { get; set; }
        [Column("xbox_store_link")]
        public string? XboxStoreLink { get; set; }
        [Column("aws_artwork_link")]
        public string? AwsArtworkLink { get; set; }
    }
}

