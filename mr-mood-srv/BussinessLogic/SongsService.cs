using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrMood.BussinessLogic.Calculations;
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

        public Task InsertAsync(SongDto songDto)
        {
            var song = new Song()
            {
                Duration = songDto.Duration,
                FileName = songDto.FileName,
                Title = songDto.SongTitle,
                MeanTempo = songDto.MeanTempo,
                MeanEnergy = songDto.MeanEnergy
            };

            var artist = _artistsService.GetByTitle(songDto.ArtistTitle);
            if (artist == null)
            {
                artist = new Artist()
                {
                    Title = songDto.ArtistTitle
                };
            }
            song.Artist = artist;

            var tags = _tagsService.GetByTitles(songDto.Tags).ToList();
            foreach(var nonExistingTagTitleInDatabase in 
                    songDto.Tags.Except(tags.Select(e=>e.Title.ToLowerInvariant())))
            {
                tags.Add(new Tag()
                {
                    Title = nonExistingTagTitleInDatabase
                });
            }
            song.Tags = tags;


            song.SongMarks = new List<SongMark>()
            {
                new SongMark()
                {
                    Energy = Convert.ToInt32(songDto.MeanEnergy),
                    Tempo = Convert.ToInt32(songDto.MeanTempo)
                }
            };

            _repositoryHolder.SongRepository.Insert(song);
            return _uof.SaveAsync();
        }

        public async Task<SongDto> GetAsync(int songId)
        {
            return ToSongDto(await _repositoryHolder.SongRepository.Get(songId));
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
                Tags = song.Tags.Select(e => e.Title).ToList(),
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
