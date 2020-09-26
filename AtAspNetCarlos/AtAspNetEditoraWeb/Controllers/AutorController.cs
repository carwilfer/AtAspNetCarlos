using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AtAspNetEditoraWeb.Controllers
{
    public class AutorController : Controller
    {
        // GET: AutorController
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/autor", DataFormat.Json);
            var response = client.Get<List<Autor>>(request);
            return View(response.Data);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/autor/" + id, DataFormat.Json);
            var response = client.Get<Autor>(request);
            return View(response.Data);
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient();

                var request = new RestRequest("http://localhost:50560/api/autor", DataFormat.Json);
                request.AddJsonBody(autor);
                var response = client.Post<Autor>(request);
                return Redirect("/autor/index");
            }
            return BadRequest();
        }

        // GET: AutorController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/autor/" + id, DataFormat.Json);
            var response = client.Get<AutorResponse>(request);

            return View(response.Data);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Autor autor)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("http://localhost:50560/api/autor/" + id, DataFormat.Json);
                request.AddJsonBody(autor);
                var response = client.Put<Autor>(request);

                return Redirect("/autor/index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/autor/" + id, DataFormat.Json);
            var response = client.Get<Autor>(request);

            return View(response.Data);
        }

        // POST: AutorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Autor autor)
        {
            try
            {
                var client = new RestClient();

                var request = new RestRequest("http://localhost:50560/api/autor/" + id, DataFormat.Json);
                var response = client.Delete<Autor>(request);

                return Redirect("/autor");
            }
            catch
            {
                return View();
            }
        }
    }
}
