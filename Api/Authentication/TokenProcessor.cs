using Common;
using Domain.Entities.Users;
using Domain.Repository;
using System.Security.Cryptography;
using Tools.ConfirmationCodes;

namespace Api.Authentication
{
	public class TokenProcessor(IUserRepository userRepository)
	{
		private static readonly ConfirmationCodesGenerator generator;

		private const string VerificationKey = "123asdewq1312";

		static TokenProcessor()
		{
			generator = new ConfirmationCodesGenerator(
				new AesCryptoServiceProvider(),
				"Frh!zp0IqSz2KxkV",
				"KOcg!Eo*",
				60L * 60 * 24 * 365,
				null);
		}

		public static string GetToken(Guid id)
		{
			return generator.Generate(Helpers.GenerateRandomString(32, 64), id.ToString(),
				DateTime.Now.Ticks.ToString(), Helpers.GenerateRandomString(32, 64), VerificationKey,
				Helpers.GenerateRandomString(32, 64));
		}

		public async Task<ApiUserModel?> UserByToken(string token)
		{
			try
			{
				if (string.IsNullOrEmpty(token))
				{
					return null;
				}
				var result = generator.Validate(token);
				if (!result.IsValid || result.ExtractedValues == null || result.ExtractedValues.Count < 6)
				{
					return null;
				}
				if (Guid.TryParse(result.ExtractedValues[1], out var userId))
				{
					var user = await userRepository.EntityById(userId);
                    if (user is null)
                    {
						return null;
                    }
                    ApiUserModel<User> model = new(user)
					{
						Name = user.Email,
					};
					return model;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}
	}
}