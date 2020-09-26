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
    public class LivroController : Controller
    {
        // GET: LivroController
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/livros", DataFormat.Json);
            var response = client.Get<List<Livro>>(request);
            return View(response.Data);
        }

        // GET: LivroController/Details/5
        public ActionResult Details(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/livros/" + id, DataFormat.Json);
            var response = client.Get<Livro>(request);
            return View(response.Data);
        }

        // GET: LivroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LivroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LivroResponse livro)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient();
                var request = new RestRequest("http://localhost:50560/api/livros", DataFormat.Json);
                request.AddJsonBody(livro);
                var response = client.Post<Livro>(request);

                return Redirect("/livro/index");
            }
            return BadRequest();
        }

        // GET: LivroController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/livros/" + id, DataFormat.Json);
            var response = client.Get<Livro>(request);

            return View(response.Data);
        }

        // POST: LivroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Livro livro)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("http://localhost:50560/api/livros/" + id, DataFormat.Json);
                request.AddJsonBody(livro);

                var response = client.Put<Livro>(request);
                return Redirect("/livro/index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LivroController/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:50560/api/livros/" + id, DataFormat.Json);
            var response = client.Get<Livro>(request);

            return View(response.Data);
        }

        // POST: LivroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("http://localhost:50560/api/livros/" + id, DataFormat.Json);
                var response = client.Delete<Livro>(request);

                return Redirect("/livro");
            }
            catch
            {
                return View();
            }
        }
    }
}
