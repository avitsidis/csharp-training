using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ContosoConsultancy.Rest.Filters
{
    public class SlowResultFilter : ActionFilterAttribute
    {
        private readonly int millisSecondsDelay;

        public SlowResultFilter(int millisSecondsDelay)
        {
            this.millisSecondsDelay = millisSecondsDelay;
        }
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.Delay(millisSecondsDelay).ContinueWith((t) => base.OnActionExecutingAsync(actionContext, cancellationToken));
        }
    }
}