using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationApiPor.Context;
using WebApplicationApiPor.Models;

namespace WebApplicationApiPor.ApiControllers
{
    public class ApiProController : ApiController
    {
        private Model1 _dbContext;
        
        public ApiProController()
        {
            _dbContext = new Model1();
        }

        [Route("api/Products")]
        public IEnumerable<Product> GetProduct()
        {
            // var data = _dbContext.Games.ToList();
            return _dbContext.Products.ToList();
        }


        [Route("api/Product/{id}")]
        public Product GetProduct(int id)
        {
            var data = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }
        [Route("api/AddProduct")]
        [HttpPost]
        public Product AddGames(Product game)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbContext.Products.Add(game);
            _dbContext.SaveChanges();

            return game;
        }
        [Route("api/UpdateProduct/{id}")]
        [HttpPut]
        public Product UpdateGames(Product game)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var existingGame = _dbContext.Products.FirstOrDefault(x => x.Id == game.Id);
            if (existingGame == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            existingGame.Name = game.Name;
            existingGame.Description = game.Description;
            existingGame.Price = game.Price;
            existingGame.PriceTotal = game.PriceTotal;

            _dbContext.SaveChanges();
            return existingGame;
        }
        [Route("api/DeleteProduct/{id}")]
        [HttpDelete]
        public void DeleteGames(int id)
        {
            var game = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (game == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbContext.Products.Remove(game);
            _dbContext.SaveChanges();
        }
    }
}
