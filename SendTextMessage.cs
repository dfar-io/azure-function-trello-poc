using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DFar.AzureFunctionTwilioPOC
{
    public static class SendTextMessage
    {
        [FunctionName("SendTextMessage")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "text")] HttpRequest req,
            ILogger log)
        {
            // Find your Account Sid and Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            var fromPhoneNumber = Environment.GetEnvironmentVariable("FROM_PHONE_NUMBER");
            var toPhoneNumbers = Environment.GetEnvironmentVariable("TO_PHONE_NUMBER").Split(";");

            TwilioClient.Init(accountSid, authToken);

            foreach (var toPhoneNumber in toPhoneNumbers)
            {
                MessageResource.Create(
                    body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                    from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(toPhoneNumber)
                );
            }

            return new OkResult();
        }
    }
}
