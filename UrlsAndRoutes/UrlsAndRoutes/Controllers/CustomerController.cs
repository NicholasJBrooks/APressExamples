using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models; 

namespace UrlsAndRoutes.Controllers
{
    // sets this to the entire controller allow for the proper controller name and the action name to be in the url
    // [Route("app/[controller]/actions/[action]/{id?}")]
  
    // You can also have custom constraints withthe attribute system as bwlow. 
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomerController : Controller
    {
        // Defines the entire route for this action so that the controller name is not needed in the Url.
        // This will also turn off the default routing so you will not be able to reach this action with customer/Index
        // [Route("myroute")]

        // Allowing the route to now be customer/MyAction
        // [Route("[controller]/MyAction")]

      
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });

        public ViewResult List(string id)
        {
            Result result = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            };

            result.Data["Id"] = id ?? "<no value>";
            result.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", result); 
        }
    }


}
