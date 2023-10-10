using Microsoft.AspNetCore.Mvc;

namespace GoodreadsBookAnalysis.Controllers
{
    public class GoodreadsAnalysisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
