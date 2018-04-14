using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using MrMood.BussinessLogic;
using MrMood.Dto;

namespace MrMood.Api.Controllers
{
    [RoutePrefix("api/songs")]
    public class SongController : ApiController
    {
        private const string MultipartContentType = "multipart/form-data";
        private const string UploadsFolder = "App_Data";
        
        private readonly SongsService _songsService;

        public SongController(
            SongsService songsService)
        {
            _songsService = songsService;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var song = _songsService.Get(id);

            return Json(song);
        }

        [HttpGet]
        [Route("{energy}/{tempo}/{desiredSongsCount}")]
        public IHttpActionResult Get([FromUri]int energy, [FromUri]int tempo, [FromUri]int desiredSongsCount)
        {
            return Json(
                _songsService.Get(
                    new SongMarkDto()
                    {
                        Energy = energy,
                        Tempo = tempo
                    }, 
                    desiredSongsCount));
        }


        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] SongDto songDto)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var guid = Guid.NewGuid().ToString();
            var filePath = Path.Combine(
                HostingEnvironment.MapPath("~/" + UploadsFolder),
                guid);

            var provider = new MultipartFormDataStreamProvider(filePath);
            await Request.Content.ReadAsMultipartAsync(provider);

            var inStream = provider.GetStream(Request.Content, Request.Content.Headers);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await inStream.CopyToAsync(fileStream);

                if (inStream.Length == 0)
                {
                    return BadRequest("File is empty");
                }
            }

            songDto.FileName = guid;
            _songsService.Insert(songDto);

            return Ok();
        }


    }
}
