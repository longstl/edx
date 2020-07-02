using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class CountryDTO
    {
        public Country Country { get; set; }
        public List<City> listCities { get; set; }
    }
}
