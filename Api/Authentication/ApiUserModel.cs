using System.Text.Json.Serialization;

namespace Api.Authentication
{
	public class ApiUserModel
	{
		public int Id { get; set; }

		public bool IsBlocked { get; set; }

		public string Name { get; set; } = "";
	}

	public class ApiUserModel<TEntity>(TEntity entity) : ApiUserModel where TEntity : class
	{
		[JsonIgnore]
		public TEntity Entity { get; set; } = entity;
	}
}