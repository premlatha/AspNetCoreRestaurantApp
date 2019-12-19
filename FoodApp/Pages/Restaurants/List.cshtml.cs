using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAppCore;
using FoodAppData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace FoodApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public string Message { get; set; }
        public IRestaurantData restaurantData { get; }
        public IEnumerable<Restaurant> restaurants { get; set; }
       
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        
        }
        public void OnGet()
        {             
            Message = config["Message"];
            restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
