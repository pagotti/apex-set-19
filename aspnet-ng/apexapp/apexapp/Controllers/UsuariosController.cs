using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apexapp.Models;
using apexapp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apexapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            var dao = new UsuariosDAO();       
            return dao.RetornarUsuarios();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "Get")]
        public Usuario Get(int id)
        {
            var dao = new UsuariosDAO();
            var usuarios = dao.RetornarUsuarios();
            return usuarios.Find(x => x.Id == id);
        }

        // POST: api/Usuarios
        [HttpPost]
        public void Post([FromBody] Usuario value)
        {
            var dao = new UsuariosDAO();
            dao.AdicionarUsuario(value);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario value)
        {
            var dao = new UsuariosDAO();
            dao.AlterarUsuario(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dao = new UsuariosDAO();
            dao.ExcluirUsuario(id);
        }
    }
}
