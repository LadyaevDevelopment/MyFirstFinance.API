using System.Text.RegularExpressions;

namespace Core.Common.Email
{
	public partial interface IEmailValidation
	{
		bool IsValid(string email);

		public partial class Base : IEmailValidation
		{
			public bool IsValid(string email)
			{
				return EmailRegex().IsMatch(email);
			}

			[GeneratedRegex("^[0-9a-zA-Z]([.-]?\\w+)*@[0-9a-zA-Z]([.-]?[0-9a-zA-Z])*(\\.[0-9a-zA-Z]{2,4})+$")]
			private static partial Regex EmailRegex();
		}
	}
}
