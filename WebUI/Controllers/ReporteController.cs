using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using WebUI.Objects;

namespace WebUI.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public async Task<ActionResult> Index()
        {
            var usuario = new Usuario
            {
                Username = "ucand0021",
                Password = "yNDVARG80sr@dDPc2yCT!"
            };

            var json = JsonConvert.SerializeObject(usuario);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://api.toka.com.mx/candidato/api/login/authenticate", httpContent);
            var result = response.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<Token>(result);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Data);
            json = await httpClient.GetStringAsync("https://api.toka.com.mx/candidato/api/customers");
            var data = JsonConvert.DeserializeObject<Datos>(json).Data.AsEnumerable(); ;
            return View(data);
        }
    }   
}