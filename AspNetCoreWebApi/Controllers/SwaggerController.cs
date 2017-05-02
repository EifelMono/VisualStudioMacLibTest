using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    /// <summary>
    /// Swagger controller.
    /// </summary>
    public class SwaggerController: Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AspNetCoreWebApi.Controllers.SwaggerController"/> class.
        /// </summary>
        public SwaggerController()
        {
        }

        /// <summary>
        /// Redirect to Swagger
        /// </summary>
        /// <returns>The root.</returns>
        [HttpGet("/")]
        public ActionResult Root()
        {
            return Redirect("swagger/ui/index.html");
        }
    }
}
