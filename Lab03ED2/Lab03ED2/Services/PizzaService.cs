using Lab03ED2.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03ED2.Services
{
    public class PizzaService
    {
        private readonly IMongoCollection<Pizza> _pizza;

        public PizzaService(IPizzaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pizza = database.GetCollection<Pizza>(settings.PizzaCollectionName);
        }

        public List<Pizza> Get() =>
            _pizza.Find(pizza => true).ToList();

        public Pizza Get(string id) =>
            _pizza.Find<Pizza>(pizza => pizza.Id == id).FirstOrDefault();

        public Pizza Create(Pizza pizza)
        {
            _pizza.InsertOne(pizza);
            return pizza;
        }

        public void Update(string id, Pizza pizzaIn) =>
            _pizza.ReplaceOne(pizza => pizza.Id == id, pizzaIn);

        public void Remove(Pizza pizzaIn) =>
            _pizza.DeleteOne(pizza => pizza.Id == pizzaIn.Id);

        public void Remove(string id) =>
            _pizza.DeleteOne(pizza => pizza.Id == id);
    }
}
