using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Registration
{
	public class SpecifyIdentityDocumentRequest
	{
        [Required]
        public byte[] DocumentBytes { get; set; } = [];
	}
}
