using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Registration
{
	public class SpecifyNameRequest
	{
		[Required]
		public string FirstName { get; set; } = "";

		[Required]
		public string LastName { get; set; } = "";

		public string? MiddleName { get; set; }
	}
}
