using BL.Mail.MailTemplates;
using BL.MailTemplates;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mail
{
    public class Mailer
    {       
        private readonly SendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;

        public Mailer(IConfiguration configuration)
        {
            _configuration = configuration;
            _sendGridClient = new SendGridClient(_configuration.GetSection("SendGrid:MailerAPIKey").Value);
        }

        public async Task InviteTeamscan(TeamMember teamMember, Team team, User teamleader, Guid individualScoreId)
        {
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("vincent.hertens@euri.com", "Euricom");
            sendGridMessage.AddTo(teamMember.Email, $"{teamMember.Firstname} {teamMember.Lastname}");

            var mailtemplate = new MailTemplateInviteTeamscan
            {
                Name = $"{teamMember.Firstname} {teamMember.Lastname}",
                TeamleaderName = $"{teamleader.Firstname} {teamleader.Lastname}",
                TeamName = team.Name,
                Url = $"https://stageteamscanstorage.z13.web.core.windows.net/teamscan/{individualScoreId}"
            };

            sendGridMessage.SetTemplateId(mailtemplate.TemplateId);
            sendGridMessage.SetTemplateData(mailtemplate);

            var response = await _sendGridClient.SendEmailAsync(sendGridMessage);
        }

        public async Task RemindTeamscan(TeamMember teamMember, string teamscanName, Team team, User teamleader, Guid individualScoreId)
        {
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("yanu.szapinszky@euri.com", "Euricom");
            sendGridMessage.AddTo(teamMember.Email, $"{teamMember.Firstname} {teamMember.Lastname}");

            var mailtemplate = new MailTemplateReminderTeamscan
            {
                Name = $"{teamMember.Firstname} {teamMember.Lastname}",
                TeamleaderName = $"{teamleader.Firstname} {teamleader.Lastname}",
                TeamscanName = teamscanName,
                TeamName = team.Name,
                Url = $"https://stageteamscanstorage.z13.web.core.windows.net/teamscan/{individualScoreId}"
            };

            sendGridMessage.SetTemplateId(mailtemplate.TemplateId);
            sendGridMessage.SetTemplateData(mailtemplate);

            await _sendGridClient.SendEmailAsync(sendGridMessage);
        }

        public async Task CompletedTeamscan(string teamName, User teamleader, int teamscanId)
        {
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("yanu.szapinszky@euri.com", "Euricom");
            sendGridMessage.AddTo(teamleader.Email, $"{teamleader.Firstname} {teamleader.Lastname}");

            var mailtemplate = new MailTemplateCompletedTeamscan
            {
                TeamName = teamName,
                TeamleaderName = $"{teamleader.Firstname} {teamleader.Lastname}",
                Url = $"http://localhost:3000/scanresults/{teamscanId}"
            };

            sendGridMessage.SetTemplateId(mailtemplate.TemplateId);
            sendGridMessage.SetTemplateData(mailtemplate);

            await _sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}
