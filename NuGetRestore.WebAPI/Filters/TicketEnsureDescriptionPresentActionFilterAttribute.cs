using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGetRestore.WebAPI.Models;

namespace NuGetRestore.WebAPI.Filters
{
    public class TicketEnsureDescriptionPresentActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (context.ActionArguments["ticket"] is Ticket ticket && !ticket.ValidateDescription())
            {
                context.ModelState.AddModelError("Description", "Description is required.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
