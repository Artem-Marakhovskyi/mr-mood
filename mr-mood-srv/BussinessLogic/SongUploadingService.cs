using MrMood.DataAccess;
using MrMood.Domain;
using MrMood.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrMood.BussinessLogic
{
    public class SongUploadingService
    {
        private readonly UnitOfWork _uof;
        private readonly RepositoryHolder _repositoryHolder;
        private readonly ArtistsService _artistsService;

        public SongUploadingService(
            UnitOfWork uof, 
            RepositoryHolder repositoryHolder,
            ArtistsService artistsService)
        {
            _uof = uof;
            _repositoryHolder = repositoryHolder;
            _artistsService = artistsService;
        }

        public async Task InsertAsync(SongDto songDto)
        {
            var song = new Song()
            {
                Duration = songDto.Duration,
                FileName = songDto.FileName,
                Title = songDto.SongTitle
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
            
            _repositoryHolder.SongRepository.Insert(song);
            //authors
            //song
            //mark
        }
    }
}
