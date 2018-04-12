using MrMood.DataAccess.Context;
using MrMood.DataAccess.Repositories;
using MrMood.Domain;
using System;

namespace MrMood.DataAccess
{
    public class RepositoryHolder
    {
        private readonly Lazy<IRepository<Tag>> _tagRepository;
        private readonly Lazy<IRepository<Song>> _songRepository;
        private readonly Lazy<IRepository<SongMark>> _songMarkRepository;
        private readonly Lazy<IRepository<Artist>> _artistRepository;
        private readonly Lazy<ISimpleRepository<SongTag>> _songTagRepository;
        private readonly MoodContext _context;

        public RepositoryHolder(MoodContext context)
        {
            _context = context;

            _tagRepository = new Lazy<IRepository<Tag>>(CreateTagRepository);
            _songRepository = new Lazy<IRepository<Song>>(CreateSongRepository);
            _songMarkRepository = new Lazy<IRepository<SongMark>>(CreateSongMarkRepository);
            _artistRepository = new Lazy<IRepository<Artist>>(CreateArtistRepository);
            _songTagRepository = new Lazy<ISimpleRepository<SongTag>>(CreateSongTagRepository);
        }

        public IRepository<Tag> TagRepository => _tagRepository.Value;
        public IRepository<Song> SongRepository => _songRepository.Value;
        public IRepository<SongMark> SongMarkRepository => _songMarkRepository.Value;
        public IRepository<Artist> ArtistRepository => _artistRepository.Value;
        public ISimpleRepository<SongTag> SongTagRepository => _songTagRepository.Value;

        private IRepository<Artist> CreateArtistRepository()
            => new ArtistRepository(_context.Artists);

        private IRepository<SongMark> CreateSongMarkRepository()
            => new SongMarkRepository(_context.SongMarks);

        private Repository<Tag> CreateTagRepository()
            => new TagRepository(_context.Tags);
        
        private IRepository<Song> CreateSongRepository()
            => new SongRepository(_context.Songs);

        private ISimpleRepository<SongTag> CreateSongTagRepository()
            => new SongTagRepository(_context.SongTags);
    }
}
