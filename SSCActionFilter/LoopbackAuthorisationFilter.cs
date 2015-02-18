using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace SSCActionFilter
{
    public class LoopbackAuthorisationFilter : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Play nicely with the base class :)
            base.OnAuthorization(actionContext);

            // If the request does not originate from this machine
            if (!System.Web.HttpContext.Current.Request.IsLocal)
            {
                // Create an Unauthorised Access response
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorised Access");
            }
        }
    }
}
