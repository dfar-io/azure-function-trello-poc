# azure-function-twilio-poc
POC of using Azure Functions and twilio for sending text messages

## Getting Started

1. Sign up for a Twilio Account if you haven't already.
1. Get the Account SID and Auth Token.
1. Set the TWILIO_ACCOUNT_SID and TWILIO_AUTH_TOKEN environment variables.
1. [Purchase a phone number](https://www.twilio.com/docs/sms/quickstart/csharp-dotnet-core#get-a-phone-number) and set FROM_PHONE_NUMBER.
1. Set TO_PHONE_NUMBER as the desired receipients (separated by semi-colons).
1. Run, and POST to http://localhost:7071/text