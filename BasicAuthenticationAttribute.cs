using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AllInOneWithAuthentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
        //AuthorizationFilterAttribute is filter method specify the authorization method
    {
        public override void OnAuthorization(HttpActionContext actionContext)
            //Void that doesn't return a value
            //Override that replace the variable that is already defined 
        {
            if (actionContext.Request.Headers.Authorization == null)
                //Headers is basically the HTTP response or request that contain info related to authorization, cache control, response time
            {
                //Return the value in header that it is unauthorized
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            else
            {
                // get the header parameter
                string auth_String = actionContext.Request.Headers.Authorization.Parameter;
                //Now convert the value in string through Encoding
                string original_String = Encoding.UTF8.GetString(Convert.FromBase64String(auth_String));

                // Gets username and password  
                // [0] and [1] indicates the place where to store
                // We use split there that return the new array
                string usrename = original_String.Split(':')[0];
                string password = original_String.Split(':')[1];
                // Validate username and password  shows that the username and password is as we're looking for
                //if not return unauthorized
                if (!webapi_security.ValidateUsers(usrename, password))
                {
                    // returns unauthorized error  
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            // if yes return the responses
            base.OnAuthorization(actionContext);
        }

    }
}