using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Receptsida.Models;
using System.Diagnostics;

namespace Receptsida.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("recipe_application");

            var recipeCollection = database.GetCollection<Recipe>("recipes");
            List<Recipe> recipes = recipeCollection.Find(r => true).ToList();

            var ingredientsCollection = database.GetCollection<Ingredients>("ingredientss");
            List<Ingredients> ingredients = ingredientsCollection.Find(i => true).ToList();

            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Recipes = recipes;
            model.Ingredients = ingredients;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
