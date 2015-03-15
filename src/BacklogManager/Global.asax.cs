using System.Data.Entity;
using System.Web;
using System.Web.Http;
using BacklogManager.DAL;
using TodoSPA;

namespace BacklogManager
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new BacklogDatabaseInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
