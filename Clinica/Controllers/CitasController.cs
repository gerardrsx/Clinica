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
    public class CitasController : Controller
    {
        string URL_Api = "https://localhost:44325/";

        // GET: Citas
        public ActionResult Index()
        {
            var Lista = new List<Citas>();
            //declare api client 
            HttpClient client = new HttpClient();
            //Initialize api client
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage resp = client.GetAsync(URL_Api + "api/Citas").Result;
            //This method throws an exception if the HTTP response status is an error code.  
            //var xx = resp.EnsureSuccessStatusCode();
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsAsync<List<Citas>>().Result;
                Lista = resultado;
            }

            return View(Lista);
        }

        // GET: Citas/Details/5
        public ActionResult Details(int id)
        {
           

            return View();
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.Pacientes = ToSelectListPacientes(ObtenerPacientes());

            ViewBag.Medicos = ToSelectListMedicos(ObtenerMedicos());



            return View();
        }

        private SelectList ToSelectListPacientes(List<Pacientes> Lista)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in Lista)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.Nombres + " " + item.Apellidos,
                    Value = item.IdPaciente.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        private SelectList ToSelectListMedicos(List<Medicos> Lista)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in Lista)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.Nombres + " " + item.Apellidos,
                    Value = item.IdMedico.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        // POST: Citas/Create
        [HttpPost]
        public ActionResult Create(Citas cita)
        {
            try
            {
                cita.Operacion = "a";
                cita.FechaDiagnostico = null;

                //declare api client 
                HttpClient client = new HttpClient();
                //Initialize api client
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = client.PostAsJsonAsync(URL_Api + "api/Citas", cita).Result;
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
                ViewBag.Pacientes = ObtenerPacientes();
                ViewBag.Medicos = ObtenerMedicos();
                return View();
            }
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Pacientes = ToSelectListPacientes(ObtenerPacientes());

            ViewBag.Medicos = ToSelectListMedicos(ObtenerMedicos());

            var obj = new Citas();
            //declare api client 
            HttpClient client = new HttpClient();
            //Initialize api client
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage resp = client.GetAsync(URL_Api + "api/Citas/"+ id).Result;
            //This method throws an exception if the HTTP response status is an error code.  
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsAsync<Citas>().Result;
                obj = resultado;
            }

            return View(obj);

       
        }

        // POST: Citas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Citas cita)
        {
            try
            {
                cita.Operacion = "m";

                //declare api client 
                HttpClient client = new HttpClient();
                //Initialize api client
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = client.PostAsJsonAsync(URL_Api + "api/Citas", cita).Result;
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
                ViewBag.Pacientes = ObtenerPacientes();
                ViewBag.Medicos = ObtenerMedicos();
                return View();
            }
        }

        private List<Medicos> ObtenerMedicos() 
        {

            var ListaMedicos = new List<Medicos>();
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
                ListaMedicos = resultado;
            }

            return ListaMedicos;
        }

        private List<Pacientes> ObtenerPacientes()
        {

            var ListaPacientes = new List<Pacientes>();
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
                ListaPacientes = resultado;
            }

            return ListaPacientes;
        }

    }
}
