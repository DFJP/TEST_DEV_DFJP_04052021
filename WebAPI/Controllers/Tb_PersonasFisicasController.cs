using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Tb_PersonasFisicasController : ApiController
    {
        private TOKAEntities db = new TOKAEntities();

        // GET: api/Tb_PersonasFisicas
        public IQueryable<Tb_PersonasFisicas> GetTb_PersonasFisicas()
        {
            return db.Tb_PersonasFisicas;
        }

        // GET: api/Tb_PersonasFisicas/5
        [ResponseType(typeof(Tb_PersonasFisicas))]
        public IHttpActionResult GetTb_PersonasFisicas(int id)
        {
            Tb_PersonasFisicas tb_PersonasFisicas = db.Tb_PersonasFisicas.Find(id);
            if (tb_PersonasFisicas == null)
            {
                return NotFound();
            }

            return Ok(tb_PersonasFisicas);
        }

        // PUT: api/Tb_PersonasFisicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTb_PersonasFisicas(int id, Tb_PersonasFisicas tb_PersonasFisicas)
        {
            ErrorMensaje personas = new ErrorMensaje();

            try
            {
                using (var db = new TOKAEntities())
                {
                    personas = db.Database.SqlQuery<ErrorMensaje>("exec sp_ActualizarPersonaFisica " +
                        "@IdPersonaFisica, " +
                        "@Nombre, " +
                        "@ApellidoPaterno, " +
                        "@ApellidoMaterno, " +
                        "@RFC, " +
                        "@FechaNacimiento, " +
                        "@UsuarioAgrega ",
                        new SqlParameter("@IdPersonaFisica", id),
                        new SqlParameter("@Nombre", tb_PersonasFisicas.Nombre),
                        new SqlParameter("@ApellidoPaterno", tb_PersonasFisicas.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno", tb_PersonasFisicas.ApellidoMaterno),
                        new SqlParameter("@RFC", tb_PersonasFisicas.RFC),
                        new SqlParameter("@FechaNacimiento", tb_PersonasFisicas.FechaNacimiento),
                        new SqlParameter("@UsuarioAgrega", tb_PersonasFisicas.UsuarioAgrega)).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Ok(personas);
        }

        // POST: api/Tb_PersonasFisicas
        [ResponseType(typeof(Tb_PersonasFisicas))]
        public IHttpActionResult PostTb_PersonasFisicas(Tb_PersonasFisicas tb_PersonasFisicas)
        {
            ErrorMensaje personas = new ErrorMensaje();

            try
            {
                using (var db = new TOKAEntities())
                {
                    personas = db.Database.SqlQuery<ErrorMensaje>("exec sp_AgregarPersonaFisica " +
                        "@Nombre, " +
                        "@ApellidoPaterno, " +
                        "@ApellidoMaterno, " +
                        "@RFC, " +
                        "@FechaNacimiento, " +
                        "@UsuarioAgrega ",
                        new SqlParameter("@Nombre", tb_PersonasFisicas.Nombre),
                        new SqlParameter("@ApellidoPaterno", tb_PersonasFisicas.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno", tb_PersonasFisicas.ApellidoMaterno),
                        new SqlParameter("@RFC", tb_PersonasFisicas.RFC),
                        new SqlParameter("@FechaNacimiento", tb_PersonasFisicas.FechaNacimiento),
                        new SqlParameter("@UsuarioAgrega", tb_PersonasFisicas.UsuarioAgrega)).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Ok(personas);
        }

        // DELETE: api/Tb_PersonasFisicas/5
        [ResponseType(typeof(Tb_PersonasFisicas))]
        public IHttpActionResult DeleteTb_PersonasFisicas(int id)
        {
            ErrorMensaje personas = new ErrorMensaje();

            try
            {
                using (var db = new TOKAEntities())
                {
                    personas = db.Database.SqlQuery<ErrorMensaje>("exec sp_EliminarPersonaFisica " +
                        "@IdPersonaFisica ",
                        new SqlParameter("@IdPersonaFisica", id)).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Ok(personas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tb_PersonasFisicasExists(int id)
        {
            return db.Tb_PersonasFisicas.Count(e => e.IdPersonaFisica == id) > 0;
        }

        private class ErrorMensaje
        {
            public int ERROR { get; set; }
            public string MENSAJEERROR { get; set; }
        }
    }
}