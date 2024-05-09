using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Receptsida.Models;

namespace Receptsida.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("recipe_application");
            var collection = database.GetCollection<Ingredients>("ingredientss");

            List<Ingredients> ingredients = collection.Find(i => true).ToList();

            return View(ingredients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ingredients ingredients)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("recipe_application");
            var collection = database.GetCollection<Ingredients>("ingredientss");
            collection.InsertOne(ingredients);

            return Redirect("/Ingredients");

        }
        public IActionResult Show(string Id)
        {
            ObjectId ingredientsId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("recipe_application");
            var collection = database.GetCollection<Ingredients>("ingredientss");

           Ingredients ingredients = collection.Find(i => i.Id == ingredientsId).FirstOrDefault();

            return View(ingredients);
        }

        public IActionResult Edit(string Id)
        {
            ObjectId ingredientsId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("recipe_application");
            var collection = database.GetCollection<Ingredients>("ingredientss");

            Ingredients ingredients = collection.Find(i => i.Id == ingredientsId).FirstOrDefault();

            return View(ingredients);
        }

        [HttpPost]
        public IActionResult Edit(string Id, Ingredients ingredients)
        {
            ObjectId ingredientsId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("recipe_application");
            var collection = database.GetCollection<Ingredients>("ingredientss");

            ingredients.Id = ingredientsId;
            collection.ReplaceOne(i => i.Id == ingredientsId, ingredients);

            return Redirect("/Ingredients");
        }

        [HttpPost]
        public IActionResult Delete(string Id)
        {
            ObjectId ingredientsId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("recipe_application");
            var collection = database.GetCollection<Ingredients>("ingredientss");

            collection.DeleteOne(i => i.Id == ingredientsId);

            return Redirect("/Ingredients");
        }
    }
}
