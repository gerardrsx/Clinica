using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class MedicosController : Controller
    {
        string URL_Api = "https://localhost:44325/";

        // GET: Medicos
        public ActionResult Index()
        {
            var Lista = new List<Medicos>();
            //declare api client 
            HttpClient client = new HttpClient();
            //Initialize api client
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage resp = client.GetAsync(URL_Api + "api/Medicos").Result;
            //This method throws an exception if the HTTP response status is an error code.  
            //var xx = resp.EnsureSuccessStatusCode();
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsAsync<List<Medicos>>().Result;
                Lista = resultado;
            }

            return View(Lista);
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        [HttpPost]
        public ActionResult Create(Medicos medico)
        {
            try
            {
                medico.Operacion = "a";

                //declare api client 
                HttpClient client = new HttpClient();
                //Initialize api client
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = client.PostAsJsonAsync(URL_Api + "api/Medicos", medico).Result;
                //This method throws an exception if the HTTP response status is an error code.  
                //var xx = resp.EnsureSuccessStatusCode();
                if (resp.IsSuccessStatusCode)
                {
                    var resultado = resp.Content.ReadAsAsync<int>().Result;

                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int id)
        {
            var obj = new Medicos();
            //declare api client 
            HttpClient client = new HttpClient();
            //Initialize api client
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage resp = client.GetAsync(URL_Api + "api/Medicos/" + id).Result;
            //This method throws an exception if the HTTP response status is an error code.  
        if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsAsync<Medicos>().Result;
                obj = resultado;
            }

            return View(obj);
        }

        // POST: Medicos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Medicos medico)
        {
            try
            {
                medico.Operacion = "m";

                //declare api client 
                HttpClient client = new HttpClient();
                //Initialize api client
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = client.PostAsJsonAsync(URL_Api + "api/Medicos", medico).Result;
                //This method throws an exception if the HTTP response status is an error code.  
                //var xx = resp.EnsureSuccessStatusCode();
                if (resp.IsSuccessStatusCode)
                {
                    var resultado = resp.Content.ReadAsAsync<int>().Result;

                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

    }
}
