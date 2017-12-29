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
    public class ArticleTrackersController : ApiController
    {
        private SGChallengeContext db = new SGChallengeContext();

        // GET: api/Articles
        public IQueryable<ArticleTracker> GetArticles()
        {
            return db.ArticleTrackers
                .Include(a => a.User)
                .Include(a => a.Pixel)
                .OrderByDescending(a => a.Pixel != null ? a.Pixel.Views : 0);
        }

        // GET: api/Articles/5
        [ResponseType(typeof(ArticleTracker))]
        public async Task<IHttpActionResult> GetArticle(int id)
        {
            ArticleTracker article = await db.ArticleTrackers.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            article.User = await db.Users.FindAsync(article.UserId);
            article.Pixel = await db.Pixels.FindAsync(article.PixelCode);

            return Ok(article);
        }

        // POST: api/Articles
        [ResponseType(typeof(ArticleTracker))]
        public async Task<IHttpActionResult> PostArticle(ArticleTracker tracker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pixel px = new Pixel { Code = GenerateId() };
            db.Pixels.Add(px);

            tracker.PixelCode = px.Code;
            db.ArticleTrackers.Add(tracker);

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tracker.Id }, tracker);
        }

        // DELETE: api/Articles/5
        [ResponseType(typeof(ArticleTracker))]
        public async Task<IHttpActionResult> DeleteArticle(int id)
        {
            ArticleTracker article = await db.ArticleTrackers.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            db.ArticleTrackers.Remove(article);
            await db.SaveChangesAsync();

            return Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleExists(int id)
        {
            return db.ArticleTrackers.Count(e => e.Id == id) > 0;
        }

        private string GenerateId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}