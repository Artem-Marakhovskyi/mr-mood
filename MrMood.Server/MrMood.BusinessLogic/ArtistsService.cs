using MrMood.DataAccess;
using MrMood.Domain;
using System.Linq;

namespace MrMood.BussinessLogic
{
    public class ArtistsService
    {
        private readonly RepositoryHolder _repositoryHolder;

        public ArtistsService(RepositoryHolder repositoryHolder)
        {
            _repositoryHolder = repositoryHolder;
        }

        public Artist GetByTitle(string title)
        {
            return _repositoryHolder.ArtistRepository
                .Get(
                    e => e.Title.ToLowerInvariant() == title.ToLowerInvariant())
                .FirstOrDefault();
        }
    }
}
