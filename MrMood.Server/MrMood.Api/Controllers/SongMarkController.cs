using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using MrMood.BussinessLogic;
using MrMood.Dto;

namespace MrMood.Api.Controllers
{
    [Route("api/marks")]
    public class SongMarkController : ApiController
    {
        private readonly SongMarksService _songMarksService;

        public SongMarkController(
            SongMarksService songMarksService)
        {
            _songMarksService = songMarksService;
        }

        [HttpPost]
        public string Post([FromBody]SongMarkDto songDto)
        {
            _songMarksService.Insert(songDto);

            return "Successfully inserted";
        }
    }
}
