using MassTransit;
using MassTransitPract.Models;
using MassTransitPract.RefitAPIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Runtime.CompilerServices;

namespace MassTransitPract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Image : ControllerBase
    {
        private readonly IRequestClient<ByteArrayPart> _saveImageClient;
        private readonly IRequestClient<DeleteImageRequest> _deleteImageClient;
        public Image(IRequestClient<ByteArrayPart> saveImageClient, IRequestClient<DeleteImageRequest> deleteImageClient)
        {
            _saveImageClient = saveImageClient;
            _deleteImageClient = deleteImageClient;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveImage(IFormFile file)
        {
            var str = new MemoryStream();
            file.OpenReadStream().CopyTo(str);
            var res = (await _saveImageClient.GetResponse<MyResponse<string>>(new ByteArrayPart(str.ToArray(), file.FileName, file.ContentType))).Message;
            if (res.IsSuccessful)
                return Ok(res.Result);
            return BadRequest(res.ErrorMessage);
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            var res = (await _deleteImageClient.GetResponse<MyResponse<string>>(new DeleteImageRequest(fileName))).Message;
            if (res.IsSuccessful)
                return Ok();
            return BadRequest(res.ErrorMessage);
        }
    }
}
