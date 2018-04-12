using System;
using System.Threading.Tasks;
using MrMood.BussinessLogic.Calculations;
using MrMood.DataAccess;
using MrMood.Domain;
using MrMood.Dto;

namespace MrMood.BussinessLogic
{
    public class SongMarksService
    {
        private readonly RepositoryHolder _repositoryHolder;
        private readonly UnitOfWork _uof;
        private readonly SongMarkCalculator _songMarkCalculator;

        public SongMarksService(
            UnitOfWork uof,
            RepositoryHolder repositoryHolder,
            SongMarkCalculator songMarkCalculator)
        {
            _uof = uof;
            _repositoryHolder = repositoryHolder;
            _songMarkCalculator = songMarkCalculator;
        }

        public async Task InsertAsync(SongMarkDto songMarkDto)
        {
            var song = await _repositoryHolder.SongRepository.Get(songMarkDto.SongId);
            var newSongMark =
                new SongMark()
                {
                    Energy = Convert.ToInt32(songMarkDto.Energy),
                    Tempo = Convert.ToInt32(songMarkDto.Tempo),
                    Song = song
                };
            _repositoryHolder.SongMarkRepository.Insert(newSongMark);

            RecalculateMeanForSong(song, newSongMark);

            _repositoryHolder.SongRepository.Update(songMarkDto.SongId, song);

            await _uof.SaveAsync();
        }

        private void RecalculateMeanForSong(Song song, SongMark newSongMark)
        {
            var sourceSongMarks = new SongMark[song.SongMarks.Count + 1];
            song.SongMarks.CopyTo(sourceSongMarks);
            sourceSongMarks[sourceSongMarks.Length - 1] = newSongMark;
            var meanMarks = _songMarkCalculator.GetMeanSongMark(sourceSongMarks);

            song.MeanEnergy = meanMarks.Energy;
            song.MeanTempo = meanMarks.Tempo;
        }
    }
}
