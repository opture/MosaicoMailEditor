using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MosaicoMailEditor.Models;

namespace MosaicoMailEditor.Controllers
{
    public class MailTemplateAPIController : ApiController
    {
        private MosaicoContext _db = new MosaicoContext();
        public MailMessageTemplate Get(string id )
        {
            return _db.MailMessageTemplates.Where(_m => _m.Key == id).FirstOrDefault();
        }

        public MailMessageTemplate Post(MailMessageTemplate reqTemplate)
        {
            MailMessageTemplate template = _db.MailMessageTemplates.Find(reqTemplate.Key);
            if (template == null) {
                _db.MailMessageTemplates.Add(reqTemplate);
            } else {
                template.Html = reqTemplate.Html;
                template.Metadata = reqTemplate.Metadata;
                template.Name = reqTemplate.Name;
                template.Template = reqTemplate.Template;
            }


            _db.SaveChanges();
            return reqTemplate;
        }


    }
}

