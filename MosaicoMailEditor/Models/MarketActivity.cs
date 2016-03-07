using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosaicoMailEditor.Models
{
    public class MarketActivity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public List<string> Whitelist {get;set;} //Contains specific mails to send to.
        public List<string> Blacklist { get; set; } //Contains specific mails NOT to send to.
        public virtual ICollection<MailMessageTemplate> MailMessages { get; set; }
    }
    public class MarketMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Preamble { get; set; }
        public string Message { get; set; }
        public DateTimeOffset PublishDateTime { get; set; }
        public MarketActivity MarketActivity { get; set; }
        public int? MarketActivityId { get; set; }
    }
}
