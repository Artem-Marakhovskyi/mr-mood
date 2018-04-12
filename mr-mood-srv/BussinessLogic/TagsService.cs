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

        public IEnumerable<Tag> GetByTitles(IEnumerable<string> titles)
        {
            return _repositoryHolder.TagRepository.Get(e => titles.Any(x => x.ToLowerInvariant() == e.Title.ToLowerInvariant()));
        }
    }
}
