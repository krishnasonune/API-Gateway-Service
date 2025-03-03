using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies : ControllerBase
    {
        [HttpGet]
        [Route("movies")]
        public async Task<IActionResult> GetMovies()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "mock.json");
            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            var sr = new StreamReader(fs);
            var data = await sr.ReadToEndAsync()!;
            fs.Close();
            sr.Close();
            return Ok(data);
        }

        [HttpPost]
        [Route("addmovies/{name}")]
        public async Task<IActionResult> AddMovies([FromRoute] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Movie name cannot be empty");
            }
            return Ok("Movie Added to the database");
        }
    }
}
