using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Marvelseries : ControllerBase
    {
        [HttpGet]
        [Route("series")]
        public async Task<IActionResult> GetSeries()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "mockseries.json");
            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            var sr = new StreamReader(fs);
            var data = await sr.ReadToEndAsync()!;
            fs.Close();
            sr.Close();
            return Ok(data);
        }

        [HttpPost]
        [Route("addseries/{name}")]
        public async Task<IActionResult> AddSeries([FromRoute] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("series name cannot be null or empty");
            }
            return Ok("Series Added to the database");
        }
    }
}
