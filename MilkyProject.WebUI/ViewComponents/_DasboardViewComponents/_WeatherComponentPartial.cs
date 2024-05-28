using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MilkyProject.WebUI.ViewComponents._DasboardViewComponents
{
    public class _WeatherComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string api = "c0aa9012f2ef4ace1b890177b2cfb22e";

            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Istanbul,TR&units=metric&mode=xml&lang=tr&appid=" + api;
            XDocument document = XDocument.Load(connection);
            //ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //ViewBag.city = document.Descendants("city").ElementAt(0).Attribute("name").Value;
            //ViewBag.status = document.Descendants("weather").ElementAt(0).Attribute("value").Value;

            ViewBag.temperature = "10";
            ViewBag.city = "İstanbul";
            ViewBag.status = "güneşli";
            return View();
        }
    }
}
