using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrMood.BussinessLogic;
using MrMood.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MrMood.Api.Controllers
{
    [Route("api/marks")]
    public class SongMarkController : Controller
    {
        private readonly SongMarksService _songMarksService;

        public SongMarkController(
            SongMarksService songMarksService)
        {
            _songMarksService = songMarksService;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody]SongMarkDto songDto)
        {
            await _songMarksService.InsertAsync(songDto);

            var result = new JsonResult("Successfully inserted");
            result.StatusCode = (int)HttpStatusCode.OK;

            return result;
        }
    }
}
