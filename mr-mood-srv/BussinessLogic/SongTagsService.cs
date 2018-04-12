using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MrMood.DataAccess;
using MrMood.Domain;

namespace MrMood.BussinessLogic
{
    public class SongTagsService
    {
        private readonly RepositoryHolder _repositoryHolder;
        private readonly UnitOfWork _uof;

        public SongTagsService(
            UnitOfWork uof,
            RepositoryHolder repositoryHolder)
        {
            _uof = uof;
            _repositoryHolder = repositoryHolder;
        }

        public Task AddTagsToSong(int songId, IEnumerable<int> tagsId)
        {
            foreach (var tagId in tagsId)
            {
                AddTagToSongInternal(songId, tagId);
            }

            return _uof.SaveAsync();
        }

        public Task AddTagToSong(int songId, int tagId)
        {
            AddTagToSongInternal(songId, tagId);

            return _uof.SaveAsync();
        }

        private void AddTagToSongInternal(int songId, int tagId)
        {
            _repositoryHolder.SongTagRepository.Insert(
                new SongTag()
                {
                    SongId = songId,
                    TagId = tagId
                });
        }
    }
}
