using System.Text.Json.Serialization;

namespace Core.Common.Authentication
{
	public class AuthorizedUserModel
	{
		public Guid Id { get; set; }

		public bool IsBlocked { get; set; }

		public string Name { get; set; } = "";
	}

	public class ApiUserModel<TEntity>(TEntity entity) : AuthorizedUserModel where TEntity : class
	{
		[JsonIgnore]
		public TEntity Entity { get; set; } = entity;
	}
}