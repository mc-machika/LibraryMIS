using Microsoft.AspNetCore.Mvc;

namespace LibraryMIS.Web.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult BookRentalIndex()
        {
            return View();
        }
    }
}
