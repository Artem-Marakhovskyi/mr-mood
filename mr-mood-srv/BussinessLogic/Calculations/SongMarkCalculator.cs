using System;
using System.Collections.Generic;
using System.Linq;
using MrMood.Domain;
using MrMood.Dto;

namespace MrMood.BussinessLogic.Calculations
{
    internal class SongMarkCalculator
    {
        internal SongMarkDto GetMeanSongMark(IEnumerable<SongMark> songMarks)
        {
            return new SongMarkDto()
            {
                Energy = songMarks.Average(e => e.Energy),
                Tempo = songMarks.Average(e => e.Tempo)
            };
        }

        internal double GetDistance(SongMarkDto searchMarkDto, SongMarkDto songMarkDto)
        {
            return Math.Sqrt(
                Math.Pow(searchMarkDto.Energy - songMarkDto.Energy, 2) 
                    + Math.Pow(searchMarkDto.Tempo - songMarkDto.Tempo, 2));
        }
    }
}
