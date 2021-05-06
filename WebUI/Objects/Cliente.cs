using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Objects
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public DateTime FechaRegistroEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public string Sucursal { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int IdViaje { get; set; }
    }

    public class Datos
    {
        public List<Cliente> Data { get; set; }
    }

    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Token
    {
        public string Data { get; set; }
    }
}