using Microsoft.AspNetCore.Mvc;

namespace LibraryMIS.Web.Controllers
{
	public class ReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
