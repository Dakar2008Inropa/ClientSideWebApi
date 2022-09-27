using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientSideWebApi.Models
{
    public class CityWebApi
    {
        public List<CityLanguage> cityLanguages { get; set; }
        public int countryID { get; set; }
        public Country country { get; set; }
        public int numberOfPointsOfInterest { get; set; }
        public List<PointsOfInterest> pointsOfInterest { get; set; }
        public int cityId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class CityLanguage
    {
        public int languageId { get; set; }
        public string languageName { get; set; }
    }

    public class Country
    {
        public int countryID { get; set; }
        public string countryName { get; set; }
    }

    public class PointsOfInterest
    {
        public int pointOfInterestId { get; set; }
        public int cityId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}