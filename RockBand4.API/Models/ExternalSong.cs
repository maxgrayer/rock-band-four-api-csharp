using System;
namespace RockBand4.API.Models
{
	public class ExternalSong
	{
		public ExternalSong() { }

        public string? SongID { get; set; }
        public string? Album { get; set; }
        public string? Album2 { get; set; }
        public string? Artist { get; set; }
        public string? Artist2 { get; set; }
        public int? BPM { get; set; }
        public int? BandDifficulty { get; set; }
        public int? BandRanking { get; set; }
        public int? BassDifficulty { get; set; }
        public int? BassRanking { get; set; }
        public int? BassSoloCount { get; set; }
        public int? DrumsDifficulty { get; set; }
        public int? DrumsRanking { get; set; }
        public int? DrumsSoloCount { get; set; }
        public string? Gender { get; set; }
        public string? Genre { get; set; }
        public int? GuitarDifficulty { get; set; }
        public int? GuitarRanking { get; set; }
        public int? GuitarSoloCount { get; set; }
        public int? HarmoniesCount { get; set; }
        public string? Name { get; set; }
        public string? Name2 { get; set; }
        public string? Pack { get; set; }
        public string? ReleaseDate { get; set; }
        public string? ReleaseDate2 { get; set; }
        public int? SongIDNumber { get; set; }
        public int? SongLength { get; set; }
        public string[]? SourceArray { get; set; }
        public string? StoreLink { get; set; }
        public int? VocalsDifficulty { get; set; }
        public int? VocalsRanking { get; set; }
        public int? Year { get; set; }
        public string? StoreLinkXbox { get; set; }
        public bool? Cover { get; set; }
        public bool? Listed { get; set; }
        public bool? SeasonPass { get; set; }
        public bool? Freestyle { get; set; }
        public bool? Unavailable { get; set; }
        public string? Spotify { get; set; }
        public bool? BRE { get; set; }
        public int? RivalsCount { get; set; }
    }
}

