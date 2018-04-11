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
        private readonly SongUploadingService _songUploadingService;

        public SongController(
            IHostingEnvironment hostingEnvironment,
            SongUploadingService songUploadingService)
        {
            _hostingEnvironment = hostingEnvironment;
            _songUploadingService = songUploadingService;
        }

        // GET: api/Song
        [HttpPost]
        public async Task<JsonResult> UploadFile(IFormFile file, SongDto songDto)
        {
            var guid = Guid.NewGuid().ToString();
            var filePath = Path.Combine(
                _hostingEnvironment.ContentRootPath,
                UploadsFolder,
                guid);

            if (file.Length == 0)
            {
                var result = new JsonResult("File length is zero");
                result.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            songDto.FileName = guid;
            await _songUploadingService.InsertAsync(songDto);
        }


    }
}
