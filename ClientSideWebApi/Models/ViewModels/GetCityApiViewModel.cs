using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientSideWebApi.Models.ViewModels
{
    public class GetCityApiViewModel
    {
        public List<CityWebApi> Cities { get; set; }
        public string DisplayText { get; set; }
        public bool Relations { get; set; }
    }
}