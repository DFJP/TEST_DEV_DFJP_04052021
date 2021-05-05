using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebUI.Controllers
{
    [Authorize]
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
    }
}