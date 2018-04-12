using System.Collections.Generic;
using System.Linq;
using MrMood.Domain;
using MrMood.Dto;

namespace MrMood.BussinessLogic.Calculations
{
    public class SongMarkCalculator
    {
        public SongMarkDto GetMeanSongMark(IEnumerable<SongMark> songMarks)
        {
            return new SongMarkDto()
            {
                Energy = songMarks.Average(e => e.Energy),
                Tempo = songMarks.Average(e => e.Tempo)
            };
        }
    }
}
