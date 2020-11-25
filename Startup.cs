using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(DFar.AzureFunctionTwilioPOC.Startup))]

namespace DFar.AzureFunctionTwilioPOC
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            VerifyEnvVariable("TWILIO_ACCOUNT_SID");
            VerifyEnvVariable("TWILIO_AUTH_TOKEN");
            VerifyEnvVariable("FROM_PHONE_NUMBER");
            VerifyEnvVariable("TO_PHONE_NUMBER");
        }

        private static void VerifyEnvVariable(string key)
        {
            var webHookUrl = Environment.GetEnvironmentVariable(key);
            if (string.IsNullOrWhiteSpace(webHookUrl))
            {
                throw new Exception($"'{key}' environment variable not found.");
            }
        }
    }
}