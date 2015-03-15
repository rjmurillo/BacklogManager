using System.Data.Entity;
using System.Web;
using System.Web.Http;
using BacklogManager.DAL;
using BacklogManager.Migrations;
using TodoSPA;

namespace BacklogManager
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
