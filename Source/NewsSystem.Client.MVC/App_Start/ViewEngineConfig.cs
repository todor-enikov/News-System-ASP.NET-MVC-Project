using System.Web.Mvc;

namespace NewsSystem.Client.MVC.App_Start
{
    public class ViewEngineConfig
    {
        public static void RegisterViewEngine(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}