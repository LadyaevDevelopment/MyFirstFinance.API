using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Registration
{
	public class SpecifyEmailRequest
	{
		[Required]
		public string Email { get; set; } = "";
	}
}
