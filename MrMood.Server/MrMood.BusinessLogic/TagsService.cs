using System.Collections.Generic;
using System.Linq;
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
        
        internal IEnumerable<string> GetBySongId(int songId)
        {
            var tags = _repositoryHolder
                .SongRepository
                .Get(e => e.Id == songId)
                .First()
                .Tags
                .Select(e => e.Title);

            return tags.OrderBy(e => e);
        }

        internal void AddTagsToSong(Song song, IEnumerable<string> tagsTitles)
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
            tags.ForEach(t => song.Tags.Add(t));

            _uof.Save();
        }
    }
}
