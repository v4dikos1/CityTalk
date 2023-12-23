using Application.Abstractions;
using Infrastructure.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;


namespace Infrastructure.Services;

/// <summary>
/// Service for sending messages with a confirmation code to the mail
/// </summary>
internal class ConfirmationEmailService(IOptions<EmailOptions> emailOptions) : IEmailService
{
    private readonly EmailOptions _emailOptions = emailOptions.Value;

    public async Task SendEmailAsync(string receiverEmail, string subject, string message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress(_emailOptions.SenderName, _emailOptions.SenderEmail));
        emailMessage.To.Add(new MailboxAddress("", receiverEmail));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = $"Follow this link to confirm your mail: {_emailOptions.ConfirmUrl}{message}"
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_emailOptions.SmtpHost, Convert.ToInt32(_emailOptions.SmtpPort), true);
            await client.AuthenticateAsync(_emailOptions.SmtpUsername, _emailOptions.SmtpServicePassword);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}