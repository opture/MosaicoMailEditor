using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MosaicoMailEditor.Models;

namespace MosaicoMailEditor.Controllers
{
    public class MailTemplateController : ApiController
    {
        private MosaicoContext db = new MosaicoContext();

        // GET: api/MailTemplate
        public IQueryable<MailMessageTemplate> GetMailMessageTemplates()
        {
            return db.MailMessageTemplates;
        }

        // GET: api/MailTemplate/5
        [ResponseType(typeof(MailMessageTemplate))]
        public IHttpActionResult GetMailMessageTemplate(string key)
        {
            MailMessageTemplate mailMessageTemplate = db.MailMessageTemplates.Find(key);
            if (mailMessageTemplate == null)
            {
                return NotFound();
            }

            return Ok(mailMessageTemplate);
        }

        // PUT: api/MailTemplate/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMailMessageTemplate(string key, MailMessageTemplate mailMessageTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != mailMessageTemplate.Key)
            {
                return BadRequest();
            }

            db.Entry(mailMessageTemplate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailMessageTemplateExists(key))
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

        // POST: api/MailTemplate
        [ResponseType(typeof(MailMessageTemplate))]
        public IHttpActionResult PostMailMessageTemplate(MailMessageTemplate mailMessageTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MailMessageTemplates.Add(mailMessageTemplate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MailMessageTemplateExists(mailMessageTemplate.Key))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mailMessageTemplate.Key }, mailMessageTemplate);
        }

        // DELETE: api/MailTemplate/5
        [ResponseType(typeof(MailMessageTemplate))]
        public IHttpActionResult DeleteMailMessageTemplate(string key)
        {
            MailMessageTemplate mailMessageTemplate = db.MailMessageTemplates.Find(key);
            if (mailMessageTemplate == null)
            {
                return NotFound();
            }

            db.MailMessageTemplates.Remove(mailMessageTemplate);
            db.SaveChanges();

            return Ok(mailMessageTemplate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MailMessageTemplateExists(string key)
        {
            return db.MailMessageTemplates.Count(e => e.Key == key) > 0;
        }
    }
}