using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Web.Http;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Http.Description;
using RestAPIPlanningActivities.Models;


namespace RestAPIPlanningActivities.Controllers
{
    public class UsuariosRestController : ApiController 
    {
        #region atributos
        private MyDbContext db = new MyDbContext();
       
        //private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        #endregion
        #region constructores
        public UsuariosRestController() 
        {
        }

        public UsuariosRestController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                //aqui en GetUserManager 
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        #endregion
       
         
        public IQueryable<UsuariosDTO> Get()
        {
            //db.Database.Connection.Open();
            //return db.Usuarios;
            db.Database.Connection.Open();

            var usuarios = from u in db.AspNetUsers
                           select new UsuariosDTO()
                           {

                               email = u.Email,
                               emailConfirmed = u.EmailConfirmed,
                               nombre = u.Nombre,
                               apellidos = u.Apellidos,
                           };

            return usuarios;
            
        }

        
        // GET: api/UsuariosRest/5
        [ResponseType(typeof(AspNetUsers))]
        public async Task<IHttpActionResult> GetUsuarios(long id)
        {
            db.Database.Connection.Open();
            AspNetUsers usuarios = await db.AspNetUsers.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();

            }

            return Ok(usuarios);
            
        }

        // PUT: api/UsuariosRest/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuarios(string id, AspNetUsers usuarios)
        {
            db.Database.Connection.Open();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Id)
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
        
        [ResponseType(typeof(AspNetUsers))]
        public async Task<IdentityUser> PostUsuarios(RegisterViewModel model)
        {
            db.Database.Connection.Open();

            IdentityUser user = new IdentityUser
            {
                UserName = model.Nombre,
                Email = model.Email
            };

            //llamar al objeto UserManager
            var User = new ApplicationUser { UserName = model.Email, Email = model.Email };
            /*
            UserManager userManager = new UserManager<IUserStore<User>
            IdentityResult result = await userManager.CreateAsync(user, userModel.Password); //var result
            */
            
        }
        
        // DELETE: api/UsuariosRest/5
        [ResponseType(typeof(AspNetUsers))]
        public async Task<IHttpActionResult> DeleteUsuarios(string id)
        {
            db.Database.Connection.Open();
            AspNetUsers usuarios = await db.AspNetUsers.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(usuarios);
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

        private bool UsuariosExists(string id)
        {
            db.Database.Connection.Open();
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
            
        }

        //envio token de confirmacion 
        /*
        private async Task<string> SendEmailConfirmationTokenAsync(string userID, string subject)
        {

            db.Database.Connection.Open();
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);
            var callbackUrl = string.Format("/Account/ConfirmEmail?userId={0}&code={1}", userID, code);
            
            //var callbackUrl = Url.Action("ConfirmEmail", "Account",
            //   new { userId = userID, code = code }, protocol: Request.Url.Scheme);
            //await UserManager.SendEmailAsync(userID, subject,
            //   "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            //return callbackUrl;
            
            return callbackUrl;
            
        }
        */
    }
}