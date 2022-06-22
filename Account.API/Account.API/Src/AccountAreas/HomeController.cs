using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.API.Src.AccountAreas
{
    [Route("v1/api/[Controller]/[Action]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<string> Index()
        {
            throw new ClientException(400, "NO_DATA");
            var res = "Nam Test";
            return res;
        }
    }
}
