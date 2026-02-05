using Microsoft.AspNetCore.Mvc;

namespace Net10_WebApi.Controllers
{
    [Route("api/villa")]
    [ApiController]
    public class VillaController: ControllerBase
    {
        [HttpGet]
        public string GetVillas()
        {
            return "This is the GetVillas method of VillaController.";
        }

        [HttpGet("{id:int}")]
        public string GetVillaById(int id)
        {
            return $"Get VillaID: {id}";
        }
    }
}
