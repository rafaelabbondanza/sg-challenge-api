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
using SGChallenge.Models;

namespace SGChallenge.Controllers
{
    public class PxController : ApiController
    {
        private SGChallengeContext db = new SGChallengeContext();

        // GET: api/Pixels
        public IQueryable<Pixel> GetPixels()
        {
            return db.Pixels;
        }

        // GET: api/Pixels/5
        [ResponseType(typeof(Pixel))]
        public async Task<IHttpActionResult> GetPixelView(string id)
        {
            Pixel pixel = await db.Pixels.FindAsync(id);
            if (pixel == null)
            {
                return NotFound();
            }

            pixel.Views++;

          

            return Ok(pixel);
        }

        // PUT: api/Pixels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPixel(string id, Pixel pixel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pixel.Code)
            {
                return BadRequest();
            }

            db.Entry(pixel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PixelExists(id))
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PixelExists(string id)
        {
            return db.Pixels.Count(e => e.Code == id) > 0;
        }
    }
}