using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Services
{
    public class EmailSender : IEmailSender
    {

        // .....



        private readonly MailJetSettings _mailJetSettings;

        public EmailSender(IOptions<MailJetSettings> mailJetSettings)
        {
            _mailJetSettings = mailJetSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient(_mailJetSettings.PublicKey,
                _mailJetSettings.PrivateKey)
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
                 new JObject {
                      {
                       "From",
                           new JObject {
                                {"Email", _mailJetSettings.Email},
                                {"Name", "Appli Taxi"}
                           }
                      }, {
                       "To",
                           new JArray {
                                new JObject {
                                     {
                                      "Email",
                                      email
                                     }, {
                                      "Name",
                                      "Bonjour"
                                     }
                                }
                           }
                      },
                     {
                         "Subject",
                        subject
                     }, {
                        "TextPart",
                        "My first Mailjet email => =>"
                     }, {
                        "HTMLPart",
                        htmlMessage
                     }, {
                        "CustomID",
                        "AppGettingStartedTest"
                     }
                 }
             });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
