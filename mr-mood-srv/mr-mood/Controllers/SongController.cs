using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MrMood.BussinessLogic;
using MrMood.Domain;
using MrMood.Dto;

namespace MrMood.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/songs")]
    public class SongController : Controller
    {
        private const string MultipartContentType = "multipart/form-data";
        private const string UploadsFolder = "uploads";

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SongsService _songsService;

        public SongController(
            IHostingEnvironment hostingEnvironment,
            SongsService songsService)
        {
            _hostingEnvironment = hostingEnvironment;
            _songsService = songsService;
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            var song = await _songsService.GetAsync(id);

            return new JsonResult(song);
        }

        [HttpGet]
        public JsonResult Get([FromQuery]int energy, [FromQuery]int tempo, [FromQuery]int desiredSongsCount)
        {
            return new JsonResult(_songsService.Get(new SongMarkDto() { Energy = energy, Tempo = tempo }, desiredSongsCount);
        }

        // GET: api/Song
        [HttpPost]
        public async Task<JsonResult> Post(IFormFile file, SongDto songDto)
        {
            var guid = Guid.NewGuid().ToString();
            var filePath = Path.Combine(
                _hostingEnvironment.ContentRootPath,
                UploadsFolder,
                guid);

            if (file.Length == 0)
            {
                var jsonResult = new JsonResult("File length is zero");
                jsonResult.StatusCode = (int)HttpStatusCode.BadRequest;

                return jsonResult;
            }
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            songDto.FileName = guid;
            await _songsService.InsertAsync(songDto);

            var result = new JsonResult("Success");
            result.StatusCode = (int)HttpStatusCode.OK;

            return result;
        }


    }
}
