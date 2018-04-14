using System;
using System.Collections.Generic;
using System.Linq;
using MrMood.DataAccess;
using MrMood.Domain;
using MrMood.Dto;

namespace MrMood.BussinessLogic
{
    public class SongsService
    {
        private readonly UnitOfWork _uof;
        private readonly RepositoryHolder _repositoryHolder;
        private readonly ArtistsService _artistsService;
        private readonly TagsService _tagsService;
        private readonly SongMarkCalculator _songMarkCalculator;

        public SongsService(
            UnitOfWork uof,
            RepositoryHolder repositoryHolder,
            ArtistsService artistsService,
            TagsService tagsService,
            SongMarkCalculator songMarkCalculator)
        {
            _uof = uof;
            _repositoryHolder = repositoryHolder;
            _artistsService = artistsService;
            _tagsService = tagsService;
            _songMarkCalculator = songMarkCalculator;
        }

        public void Insert(SongDto songDto)
        {
            var song = new Song()
            {
                Duration = songDto.Duration,
                FileName = songDto.FileName,
                Title = songDto.SongTitle,
                MeanTempo = songDto.MeanTempo,
                MeanEnergy = songDto.MeanEnergy,
                Artist = GetSongArtist(songDto),
                SongMarks = new List<SongMark>()
                {
                    new SongMark()
                    {
                        Energy = Convert.ToInt32(songDto.MeanEnergy),
                        Tempo = Convert.ToInt32(songDto.MeanTempo)
                    }
                }
            };

            _repositoryHolder.SongRepository.Insert(song);

            _uof.Save();
            _tagsService.AddTagsToSong(song, songDto.Tags);

        }

        public SongDto Get(int songId)
        {
            var song = _repositoryHolder.SongRepository.Get(songId);
                
            return song == null ? null : ToSongDto(song);
        }

        public IEnumerable<SongDto> Get(SongMarkDto searchMarkDto, int desiredSongs)
        {
            var songsSelected = new List<SongDto>();
            var songDistance = new List<Tuple<Song, double>>();

            var songs
                = _repositoryHolder
                .SongRepository
                .Get();

            foreach (var song in songs)
            {
                songDistance.Add(
                    new Tuple<Song, double>(
                        song,
                        _songMarkCalculator
                            .GetDistance(
                                searchMarkDto,
                                new SongMarkDto()
                                {
                                    Energy = song.MeanEnergy,
                                    Tempo = song.MeanTempo
                                }
                            )
                    )
                );
            }

            return songDistance
                .OrderBy(e => e.Item2)
                .Take(desiredSongs)
                .Select(e => ToSongDto(e.Item1));
        }
        
        private Artist GetSongArtist(SongDto songDto)
        {
            var artist = _artistsService.GetByTitle(songDto.ArtistTitle);
            if (artist == null)
            {
                artist = new Artist()
                {
                    Title = songDto.ArtistTitle
                };
            }

            return artist;
        }

        private SongDto ToSongDto(Song song)
        {
            return new SongDto()
            {
                SongTitle = song.Title,
                Id = song.Id,
                FileName = song.FileName,
                Duration = song.Duration,
                ArtistTitle = song.Artist.Title,
                Tags = _tagsService.GetBySongId(song.Id),
                MeanTempo = song.MeanTempo,
                MeanEnergy = song.MeanEnergy,
                SongMarks = song.SongMarks.Select(
                    e => new SongMarkDto()
                    {
                        Energy = e.Energy,
                        Tempo = e.Tempo
                    })
            };
        }
    }
}
