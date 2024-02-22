using Microsoft.AspNetCore.Identity.UI.Services;

namespace Bulky.Utility
{
	public class EmailSender : IEmailSender
	{
		// Serves as a placeholder implementation of the IEmailSender interface.
		// Intentionally provides no email sending functionality at this time.
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			// TODO: Implement actual email sending logic here. 

			return Task.CompletedTask; // Indicates successful placeholder operation
		}
	}
}
