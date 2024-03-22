
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace lan2.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        public ActionResult<IEnumerable<string>> Index()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }
    }
}
