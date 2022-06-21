using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.API.Src.Controllers
{
    public class InvalidController : Controller
    {
        public IActionResult IndexErrorServer500()
        {
            throw new ServerException(500, "");
        }

        public IActionResult IndexErrorClient404()
        {
            throw new ClientException(404, "Bố bổ cái bàn phím vào đầu mày giờ. Đi chỗ khác chơi.");
        }

        public IActionResult IndexErrorClient401()
        {
            throw new ClientException(401, "REMOVE_ALL_TOKEN");
        }

        public IActionResult IndexErrorClient405()
        {
            throw new ClientException(405, "USER_HAS_NO_PERMISSIONS");
        }
    }
}
