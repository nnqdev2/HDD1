using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HDD.Web.Attributes
{
    //public class ValidateModelStateAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        if (!context.ModelState.IsValid)
    //        {
    //            context.Result = new ViewResult("Index");
    //        }
    //    }
    //}
    //public class ValidateModelStateAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        if (context.HttpContext.Request.Method == "POST" && !context.ModelState.IsValid)
    //            context.Result = new BadRequestObjectResult(context.ModelState);
    //    }
    //}
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Method == "POST" && !context.ModelState.IsValid)
                context.Result = new ViewResult();
        }
    }
}
