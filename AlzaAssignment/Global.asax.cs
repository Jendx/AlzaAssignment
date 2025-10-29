using System.Web.Http;

namespace AlzaAssignment;

    /// <summary>
    /// Alza Api for managing products  
    /// </summary>
    public class AlzaProductApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application entry
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration
                .UseRoutes()
                .UseSwagger();
        }
    }