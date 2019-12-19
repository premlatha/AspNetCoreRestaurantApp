using FoodAppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodAppData
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
          {
             new Restaurant { Id=1,Name="India Foodie",Location="Schaumburg",Cuisine=CuisineType.Indian},
             new Restaurant { Id=2,Name="Chipotle",Location="Palatine",Cuisine=CuisineType.Mexican},
             new Restaurant { Id=3,Name="Pizzaria",Location="Chicago",Cuisine=CuisineType.Italian},
             new Restaurant { Id=4,Name="Olive Garden",Location="Schaumburg",Cuisine=CuisineType.Italian}
          };
        }
    
        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
