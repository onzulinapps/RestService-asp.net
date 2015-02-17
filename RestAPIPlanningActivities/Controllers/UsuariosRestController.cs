using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestAPIPlanningActivities.Models;

namespace RestAPIPlanningActivities.Controllers
{
    public class UsuariosRestController : ApiController
    {
        private MyDbContext db = new MyDbContext();

       
        
        public IQueryable<UsuariosDTO> Get()
        {
            //return db.Usuarios;
            var usuarios = from u in db.Usuarios
                        select new UsuariosDTO()
                        {
                            id = u.id,
                            email = u.email,
                            nombre = u.nombre,
                            apellidos = u.apellidos
                        };
            
            return usuarios;
        }

        
        // GET: api/UsuariosRest/5
        [ResponseType(typeof(Usuarios))]
        public async Task<IHttpActionResult> GetUsuarios(long id)
        {
            Usuarios usuarios = await db.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/UsuariosRest/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuarios(long id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.id)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UsuariosRest
        [ResponseType(typeof(Usuarios))]
        public async Task<IHttpActionResult> PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //intentare poner la fecha de ese momento siempre que añada un usuario 
            usuarios.created_at = DateTime.Now;
            usuarios.updated_at = DateTime.Now;
            db.Usuarios.Add(usuarios);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.id }, usuarios);
        }

        // DELETE: api/UsuariosRest/5
        [ResponseType(typeof(Usuarios))]
        public async Task<IHttpActionResult> DeleteUsuarios(long id)
        {
            Usuarios usuarios = await db.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            await db.SaveChangesAsync();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(long id)
        {
            return db.Usuarios.Count(e => e.id == id) > 0;
        }
    }
}