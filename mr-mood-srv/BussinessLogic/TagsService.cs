using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrMood.DataAccess;
using MrMood.Domain;

namespace MrMood.BussinessLogic
{
    public class TagsService
    {
        private readonly RepositoryHolder _repositoryHolder;
        private readonly UnitOfWork _uof;

        public TagsService(
            UnitOfWork uof,
            RepositoryHolder repositoryHolder)
        {
            _uof = uof;
            _repositoryHolder = repositoryHolder;
        }

        public IEnumerable<Tag> GetByTitles(IEnumerable<string> titles)
        {
            return _repositoryHolder.TagRepository.Get(e => titles.Any(x => x.ToLowerInvariant() == e.Title.ToLowerInvariant()));
        }

        public async Task<IEnumerable<Tag>> InsertNonExistingTags(IEnumerable<string> tagsTitles)
        {
            var existingTags = _repositoryHolder.TagRepository
                .Get(e => tagsTitles.Any(x => x.ToLowerInvariant() == e.Title.ToLowerInvariant()));

            var tags = new List<Tag>();
            foreach (var title in 
                     tagsTitles
                        .Select(e => e.ToLowerInvariant())
                        .Except(existingTags.Select(e => e.Title.ToLowerInvariant())))
            {
                var tag = new Tag() { Title = title };
                tags.Add(tag);
                _repositoryHolder.TagRepository.Insert(tag);
            }
            tags.AddRange(existingTags);

            await _uof.SaveAsync();

            return tags;
        }

        internal IEnumerable<string> GetBySongId(int songId)
        {
            var tagIds = _repositoryHolder
                .SongTagRepository
                .Get(e => e.SongId == songId)
                .Select(e => e.TagId);

            return _repositoryHolder.TagRepository
                .Get(
                    e => tagIds.Any(x => x == e.Id),
                    e => e.Title,
                    0, 
                    int.MaxValue)
                .Select(e => e.Title);
        }
    }
}
