using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mail.MailTemplates
{
    public class MailTemplateReminderTeamscan
    {
        public string TemplateId { get; } = "d-542a8cf73cb94f99b6784c5e5634a148";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teamscanName")]
        public string TeamscanName { get; set; }

        [JsonProperty("teamname")]
        public string TeamName { get; set; }

        [JsonProperty("teamleaderName")]
        public string TeamleaderName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
