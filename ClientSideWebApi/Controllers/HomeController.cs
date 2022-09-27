using ClientSideWebApi.Models;
using ClientSideWebApi.Models.ViewModels;
using ClientSideWebApi.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClientSideWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string response = null)
        {
            if (response != null)
            {
                ViewBag.Response = response;
            }
            return View();
        }

        public ActionResult GetCityApi(string displaytext, bool relations = false)
        {
            GetCityApiViewModel vm = new GetCityApiViewModel();
            vm.DisplayText = displaytext;
            vm.Relations = relations;
            string json = null;
            if (relations)
            {
                json = WebClientHelper.GetJson("https://cityinfo.buchwaldshave34.dk/api/City?includeRelations=true&UseLazyLoading=false&UseMapster=true&UserName=Daniel_H1PD081122");
            }
            else
            {
                json = WebClientHelper.GetJson("https://cityinfo.buchwaldshave34.dk/api/City?includeRelations=false&UseLazyLoading=false&UseMapster=false&UserName=Daniel_H1PD081122");
            }
            vm.Cities = JSONHelper.Deserialize<List<CityWebApi>>(json);
            return View(vm);
        }

        public ActionResult AddCityWithCountry()
        {
            AddCityWithCountryViewModel vm = new AddCityWithCountryViewModel();
            vm.Countries = JSONHelper.Deserialize<List<Country>>(WebClientHelper.GetJson("https://cityinfo.buchwaldshave34.dk/api/Country?includeRelations=false&UserName=Daniel_H1PD081122"));
            return View(vm);
        }

        public ActionResult UpdateCity()
        {
            UpdateCityViewModel vm = new UpdateCityViewModel();
            vm.Cities = JSONHelper.Deserialize<List<CityWebApi>>(WebClientHelper.GetJson("https://cityinfo.buchwaldshave34.dk/api/City?includeRelations=false&UseLazyLoading=false&UseMapster=false&UserName=Daniel_H1PD081122"));
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddCityWithCountryPOST(string CityName, string CityDescription, int CountryId)
        {
            CityWebApi city = new CityWebApi();
            city.name = CityName;
            city.description = CityDescription;
            city.countryID = CountryId;
            WebClientHelper.UploadJson("https://cityinfo.buchwaldshave34.dk/api/City?UserName=Daniel_H1PD081122", JSONHelper.Serialize(city));
            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetCityData(int CityId)
        {
            string json = WebClientHelper.GetJson($"https://cityinfo.buchwaldshave34.dk/api/City/{CityId}?includeRelations=true&UserName=Daniel_H1PD081122");
            if (json.Contains("404"))
            {
                return Json(new { success = false, responseText = "City not found", jsonstring = json }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                CityWebApi thiscity = JSONHelper.Deserialize<CityWebApi>(json);
                return Json(new { success = true, responseText = "City found", citydata = thiscity }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateCityPOST(int cityid, string CityName, string CityDescription)
        {
            string json = WebClientHelper.GetJson($"https://cityinfo.buchwaldshave34.dk/api/City/{cityid}?includeRelations=true&UserName=Daniel_H1PD081122");
            CityWebApi city = JSONHelper.Deserialize<CityWebApi>(json);

            city.name = CityName;
            city.description = CityDescription;

            string response = WebClientHelper.UploadJson($"https://cityinfo.buchwaldshave34.dk/api/City/{cityid}?UserName=Daniel_H1PD081122", JSONHelper.Serialize(city), "PUT");
            return RedirectToAction("Index", "Home", new { response });
        }

        public PartialViewResult _NavBar()
        {
            return PartialView();
        }
    }
}