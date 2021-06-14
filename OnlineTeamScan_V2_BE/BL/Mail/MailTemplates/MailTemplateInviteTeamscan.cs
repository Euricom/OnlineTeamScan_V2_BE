﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MailTemplates
{
    public class MailTemplateInviteTeamscan
    {
        public string TemplateId { get; } = "d-c10c9f285107407599dcecdf97529824";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teamname")]
        public string TeamName { get; set; }

        [JsonProperty("teamleaderName")]
        public string TeamleaderName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
