using System;
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

        public void Insert(SongMarkDto songMarkDto)
        {
            var song = _repositoryHolder.SongRepository.Get(songMarkDto.SongId);
            var newSongMark =
                new SongMark()
                {
                    Energy = Convert.ToInt32(songMarkDto.Energy),
                    Tempo = Convert.ToInt32(songMarkDto.Tempo),
                    Song = song
                };
            song.SongMarks.Add(newSongMark);
            RecalculateMeanForSong(song);

            _repositoryHolder.SongRepository.Update(songMarkDto.SongId, song);

            _uof.Save();
        }

        private void RecalculateMeanForSong(Song song)
        {
            var sourceSongMarks = new SongMark[song.SongMarks.Count];
            song.SongMarks.CopyTo(sourceSongMarks, 0);
            var meanMarks = _songMarkCalculator.GetMeanSongMark(sourceSongMarks);

            song.MeanEnergy = meanMarks.Energy;
            song.MeanTempo = meanMarks.Tempo;
        }
    }
}
