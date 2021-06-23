using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using Sarmady.Orleans.Grains;

namespace Sarmady.Orleans.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IClusterClient _clusterClient;

        public HelloWorldController(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        [HttpGet("/SayHi/{name}")]
        public async Task<IActionResult> SayHi(string name)
        {
            var result = await _clusterClient.GetGrain<ITestGrain>("TestGrain").SayHelloGrainTest(name);

          return  Ok(result);
        }

        [HttpGet("/ClearState")]
        public async Task<IActionResult> ClearState()
        {
            var result = await _clusterClient.GetGrain<ITestGrain>("TestGrain").ClearState();

            return  Ok(result);
        }
    }
}
