using MrMood.DataAccess;
using MrMood.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
