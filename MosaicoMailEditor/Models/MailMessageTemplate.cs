using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicoMailEditor.Models
{
    public class MailMessageTemplate
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public string Metadata { get; set; }
        public string Template { get; set; }
    }
}
