using Aladin.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aladin.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExempleController : ControllerBase
    {
        private readonly IExempleService _exempleService;

        public ExempleController(IExempleService exempleService)
        {
            _exempleService = exempleService;
        }
        [HttpGet("getAllExemples")]
        public async Task<Object> getAll()
        {
            return _exempleService.GetMany(x => x.name == "karim");
        }
    }
}
