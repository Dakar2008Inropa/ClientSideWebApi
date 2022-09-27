using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientSideWebApi.Models.ViewModels
{
    public class AddCityWithCountryViewModel
    {
        public List<Country> Countries { get; set; }
        [Required(ErrorMessage = "Du skal indtaste navn på by")]
        [Display(Name = "By")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Du skal beskrive byen")]
        [Display(Name = "Beskrivelse")]
        public string CityDescription { get; set; }
        public int CountryId { get; set; }
    }
}