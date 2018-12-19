using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models; 

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });

        public ViewResult CustomVariable(string id)
        {
            Result result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };
            result.Data["Id"] = id ?? "<no value>";

            return View("Result", result);
        }
    }
}

///using the RouteData.Values to get the elements
//public ViewResult CustomVariable()
//{
//    Result result = new Result
//    {
//        Controller = nameof(HomeController),
//        Action = nameof(CustomVariable)
//    };
//    result.Data["Id"] = RouteData.Values["id"];

//    return View("Result", result);
//}