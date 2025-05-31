using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationAPI.Context;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Web_Api
{
    public class GameApiController : ApiController
    {
        private Model1 _dbContext;
        public GameApiController()
        {
           this. _dbContext = new Model1();
        }
        public IEnumerable<Game> GetGames()
        {
           // var data = _dbContext.Games.ToList();
            return _dbContext.Games.ToList();
        }


        [Route("api/GameApi/{id}")]
        public Game GetGames(int id)
        {
           var data = _dbContext.Games.FirstOrDefault(x => x.Id == id);

            if (data == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);

            return data;
        }


        //data Entry 
        [Route("api/AddGame")]
        [HttpPost]
        public Game AddGames(Game game)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return game;
        }

        //[Route("api/AddGame")]
        //[HttpPost]
        //public IHttpActionResult AddGames(Game game)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState); // Return 400 if model state is invalid

        //    _dbContext.Games.Add(game);
        //    _dbContext.SaveChanges();

        //    return Ok(game); // Return 200 with the created game
        //}


        [Route("api/UpdateGame/{id}")]
        [HttpPut]
        public void UpdateGames(int id, Game game)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var data = _dbContext.Games.FirstOrDefault(x => x.Id == id);

            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            data.Title = game.Title;
            data.Price = game.Price;
            data.Quantity = game.Quantity;

            _dbContext.SaveChanges();
        }


        [Route("api/RemoveGame/{id}")]
        [HttpDelete]
        public void RemoveGames(int id)
        {
            var data = _dbContext.Games.FirstOrDefault(x => x.Id == id);
            if (data == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbContext.Games.Remove(data);
            _dbContext.SaveChanges();
        }
    }
}
