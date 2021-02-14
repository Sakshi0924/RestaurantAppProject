using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantAppMVCProject.Models;

namespace RestaurantAppMVCProject.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            var restaurant = new List<Restaurant>
            {
                new Restaurant(){Id=1,Name="PlainPizza",Cusine=CusineType.French},
                new Restaurant(){Id=2,Name="Burger",Cusine=CusineType.None},
                new Restaurant(){Id=3,Name="Pasta",Cusine=CusineType.Italian},
                new Restaurant(){Id=4,Name="Biryani",Cusine=CusineType.Indian}
            };
            
            
            
            return View(restaurant);
        }

        public ActionResult Details(int id)
        {
            var restaurant = new List<Restaurant>
            {
                new Restaurant(){Id=1,Name="PlainPizza",Cusine=CusineType.French},
                new Restaurant(){Id=2,Name="Burger",Cusine=CusineType.None},
                new Restaurant(){Id=3,Name="Pasta",Cusine=CusineType.Italian},
                new Restaurant(){Id=4,Name="Biryani",Cusine=CusineType.Indian}
            };
            Restaurant reqdRestaurant = null;
            foreach (var item in restaurant)
            {
                if (item.Id == id)
                {
                    reqdRestaurant = item;
                }
                else
                {
                }
            }

            return View(reqdRestaurant);
        }

        public ActionResult Image()
        {
            
            return View();
        }
       
    }
}