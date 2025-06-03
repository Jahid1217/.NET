using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationAPI.Context;
using WebApplicationAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationAPI.Controllers
{
    public class GamesController : Controller
    {
        private HttpClient _httpClient;
        private Model1 db;
        public GamesController()
        {
           this. db = new Model1();
            this._httpClient = new HttpClient();
        }

         

        // GET: Games
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"http://localhost:51105/api/GameApi");
                var responseTask = client.GetAsync("GameApi");
                responseTask.Wait();
                if (responseTask.Result.IsSuccessStatusCode) 
                {
                    var readTask = responseTask.Result.Content.ReadAsAsync<IEnumerable<Game>>().Result;
                    return View(readTask);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new List<Game>());
                }
            }
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            _httpClient.BaseAddress = new Uri(@"http://localhost:51105/api/GameAp");
            var response = _httpClient.GetAsync("GameApi/" + id.ToString());
                response.Wait();
            if (response.Result.IsSuccessStatusCode) {
                var data = response.Result.Content.ReadAsAsync<Game>().Result;
                return View(data);
            }
            return HttpNotFound();

        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Price,Quantity")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            _httpClient.BaseAddress = new Uri(@"http://localhost:51105/api/GameApi");
            var response = _httpClient.GetAsync("GameApi/" + id.ToString());
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var data = response.Result.Content.ReadAsAsync<Game>().Result;
                return View(data);
            }
            return HttpNotFound();
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Price,Quantity")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            _httpClient.BaseAddress = new Uri(@"http://localhost:51105/api/GameApi");
            var response = _httpClient.GetAsync("GameApi/" + id.ToString());
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var data = response.Result.Content.ReadAsAsync<Game>().Result;
                return View(data);
            }
            return HttpNotFound();
        }

        // POST: Games/Delete/5
        [HttpPost,]
        [ValidateAntiForgeryToken]
            public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                _httpClient.BaseAddress = new Uri(@"http://localhost:51105/api/RemoveGame");
                var response = await _httpClient.DeleteAsync("RemoveGame/" +id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Game>();
                    return View(data);
                }

                return HttpNotFound();
            }
            catch (Exception ex)
            {
                // Optional: log the error
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
