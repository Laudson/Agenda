using Agenda.Pet.Comum.Contratos;
using Agenda.Pet.Dominio.Comum;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Agenda.Pet.Web.Controllers
{
    public class ServicosController : ApiController
    {
        private AgendaPetContexto db = new AgendaPetContexto();

        // GET: api/Servicos
        public IQueryable<Servicos> GetServico()
        {
            return db.Servico.OrderByDescending(x=> x.Codigo);
        }

        // GET: api/Servicos/5
        [ResponseType(typeof(Servicos))]
        public IHttpActionResult GetServicos(int id)
        {
            Servicos servicos = db.Servico.Find(id);
            if (servicos == null)
            {
                return NotFound();
            }

            return Ok(servicos);
        }

        // PUT: api/Servicos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServicos(int id, Servicos servicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicos.Codigo)
            {
                return BadRequest();
            }

            db.Entry(servicos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicosExists(id))
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

        // POST: api/Servicos
        [ResponseType(typeof(Servicos))]
        public IHttpActionResult PostServicos(Servicos servicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servico.Add(servicos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicos.Codigo }, servicos);
        }

        // DELETE: api/Servicos/5
        [ResponseType(typeof(Servicos))]
        public IHttpActionResult DeleteServicos(int id)
        {
            Servicos servicos = db.Servico.Find(id);
            if (servicos == null)
            {
                return NotFound();
            }

            db.Servico.Remove(servicos);
            db.SaveChanges();

            return Ok(servicos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServicosExists(int id)
        {
            return db.Servico.Count(e => e.Codigo == id) > 0;
        }
    }
}