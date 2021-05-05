using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebUI.Controllers
{
    //[Authorize]
    public class PersonaFisicaController : Controller
    {
        // GET: PersonaFisica
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44309/api/Tb_PersonasFisicas");
            var list = JsonConvert.DeserializeObject<List<Tb_PersonasFisicas>>(json);
            return View(list);
        }

        // GET: PersonaFisica
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: PersonaFisica
        [HttpPost]
        public async Task<ActionResult> Create(string Nombre, string ApellidoPaterno, string ApellidoMaterno, string RFC, string FechaNacimiento)
        {
            DateTime dateTime = new DateTime();
            dateTime = Convert.ToDateTime(DateTime.ParseExact(FechaNacimiento, "MM/dd/yyyy", CultureInfo.InvariantCulture));

            var persona = new Tb_PersonasFisicas {
                Nombre = Nombre,
                ApellidoPaterno = ApellidoPaterno,
                ApellidoMaterno = ApellidoMaterno,
                RFC = RFC,
                FechaNacimiento = dateTime,
                UsuarioAgrega = 1
            };

            var json = JsonConvert.SerializeObject(persona);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync("https://localhost:44309/api/Tb_PersonasFisicas", httpContent);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44309/api/Tb_PersonasFisicas");
            var list = JsonConvert.DeserializeObject<List<Tb_PersonasFisicas>>(json);
            var person = list.Find(x => x.IdPersonaFisica == id);
            
            return View(person);            
        }

        // POST: PersonaFisica
        [HttpPost]
        public async Task<ActionResult> Edit(int id, string Nombre, string ApellidoPaterno, string ApellidoMaterno, string RFC, string FechaNacimiento)
        {
            DateTime dateTime = new DateTime();
            dateTime = Convert.ToDateTime(DateTime.ParseExact(FechaNacimiento, "MM/dd/yyyy", CultureInfo.InvariantCulture));

            var persona = new Tb_PersonasFisicas
            {
                Nombre = Nombre,
                ApellidoPaterno = ApellidoPaterno,
                ApellidoMaterno = ApellidoMaterno,
                RFC = RFC,
                FechaNacimiento = dateTime,
                UsuarioAgrega = 1
            };

            var json = JsonConvert.SerializeObject(persona);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();

            var response = await httpClient.PutAsync("https://localhost:44309/api/Tb_PersonasFisicas/"+id, httpContent);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync("https://localhost:44309/api/Tb_PersonasFisicas/" + id);

            return RedirectToAction("Index");
        }
    }
}