using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.gargoylesoftware.htmlunit;
using ikvm.extensions;
using NHtmlUnit.Html;
using BrowserVersion = NHtmlUnit.BrowserVersion;

namespace NHtmlUnit_SampleMVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //You can change the BrowserVersion or leave as blank to default
            NHtmlUnit.WebClient driver = new NHtmlUnit.WebClient(BrowserVersion.CHROME);

            driver.Options.JavaScriptEnabled = true; //In case you dont need the Javascript you can disable it
            driver.Options.ThrowExceptionOnScriptError = false; //Just in case, so that it wont crash the code
            driver.Options.ActiveXNative = true;  //To make it more browser like (IE Active X)  
            driver.Options.CssEnabled = true; //Unless you dont need to render the portion of a file
            
            //Optional: If the site needs authentication
            DefaultCredentialsProvider credentialsProvider = (DefaultCredentialsProvider)driver.CredentialsProvider;
            credentialsProvider.addCredentials("aerobatic", "aerobatic");

            //Webpage you are going
            HtmlPage page = driver.GetHtmlPage("https://auth-demo.aerobatic.io/protected-standard/");
            //No Direct implementation for HTML
            
            ViewBag.Site = page.AsXml().replaceFirst("<\\?xml version=\"1.0\" encoding=\"(.+)\"\\?>", "<!DOCTYPE html>");
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}