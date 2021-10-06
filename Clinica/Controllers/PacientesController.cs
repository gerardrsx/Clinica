using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using Clinica.Models;

namespace Clinica.Controllers
{
    public class PacientesController : Controller
    {
        string URL_Api = "https://localhost:44325/";

        // GET: Pacientes
        public ActionResult Index()
        {
            var Lista = new List<Pacientes>();
            //declare api client 
            HttpClient client = new HttpClient();
            //Initialize api client
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage resp = client.GetAsync(URL_Api + "api/Pacientes").Result;
            //This method throws an exception if the HTTP response status is an error code.  
            //var xx = resp.EnsureSuccessStatusCode();
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsAsync<List<Pacientes>>().Result;
                Lista = resultado;
            }
            
            return View(Lista);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        public  ActionResult Create(Pacientes paciente)
        {
            try
            {
                paciente.Operacion = "a";

                //declare api client 
                HttpClient client = new HttpClient();
                //Initialize api client
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = client.PostAsJsonAsync(URL_Api+"api/Pacientes", paciente).Result;
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

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int id)
        {
            var obj = new Pacientes();
            //declare api client 
            HttpClient client = new HttpClient();
            //Initialize api client
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage resp = client.GetAsync(URL_Api + "api/Pacientes/"+id).Result;
            //This method throws an exception if the HTTP response status is an error code.  
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsAsync<Pacientes>().Result;
                obj = resultado;
            }

            return View(obj);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pacientes paciente)
        {
            try
            {
                  paciente.Operacion = "m";

                    //declare api client 
                    HttpClient client = new HttpClient();
                    //Initialize api client
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage resp = client.PostAsJsonAsync(URL_Api + "api/Pacientes", paciente).Result;
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
