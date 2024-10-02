using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class trailer : ControllerBase
    {
        [HttpGet]
        [Route("trailers")]
        public async Task<IActionResult> GetSeries()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "mocktrailers.json");
            var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            var sr = new StreamReader(fs);
            var data = await sr.ReadToEndAsync()!;
            fs.Close();
            sr.Close();
            return Ok(data);
        }
    }
}
