using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mail.MailTemplates
{
    public class MailTemplateCompletedTeamscan
    {
        public string TemplateId { get; } = "d-3760bdea619141e8b17c23478523fe00";

        [JsonProperty("teamname")]
        public string TeamName { get; set; }

        [JsonProperty("teamleaderName")]
        public string TeamleaderName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
