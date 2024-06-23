using Domain.Entities.PolicyDocuments;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class PolicyDocumentModel(string title, string url)
	{
		[Required]
		public string Title { get; set; } = title;

		[Required]
		public string Url { get; set; } = url;

		public static PolicyDocumentModel FromEntity(PolicyDocument entity)
		{
			return new(title: entity.Title, url: entity.Url);
		}
	}
}
