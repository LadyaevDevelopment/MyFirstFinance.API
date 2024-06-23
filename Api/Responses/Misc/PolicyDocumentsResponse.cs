using Api.Models;
using SpaceApp.Dev.ApiToMobile.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Responses.Misc
{
	public class PolicyDocumentsResponse(List<PolicyDocumentModel> documents)
	{
		[Required]
		[GenericArgumentsNotNull]
		public List<PolicyDocumentModel> Documents { get; set; } = documents;
	}
}
