using System.Web.Http;
using MrMood.BussinessLogic;
using MrMood.Dto;

namespace MrMood.Api.Controllers
{
    [RoutePrefix("api/marks")]
    public class SongMarkController : ApiController
    {
        private readonly SongMarksService _songMarksService;

        public SongMarkController(
            SongMarksService songMarksService)
        {
            _songMarksService = songMarksService;
        }

        [HttpPost]
        [Route("")]
        public string Post([FromUri] SongMarkDto songMarkDto)
        {
            _songMarksService.Insert(songMarkDto);

            return "Successfully inserted";
        }
    }
}
