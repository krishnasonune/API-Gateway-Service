using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Marveltrailers : ControllerBase
    {
        [HttpGet]
        [Route("trailers")]
        public async Task<IActionResult> Gettrailers()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "mocktrailers.json");
            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            var sr = new StreamReader(fs);
            var data = await sr.ReadToEndAsync()!;
            fs.Close();
            sr.Close();
            return Ok(data);
        }

        [HttpPost]
        [Route("addtrailers/{name}")]
        public async Task<IActionResult> Addtrailers([FromRoute] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("trailer name cannot be null or empty");
            }
            return Ok("trailer added to the database");
        }
    }
}
