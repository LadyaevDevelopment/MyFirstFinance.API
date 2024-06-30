using Core.Common.Random;
using Core.Common.TokenGenerator;
using Domain.Entities.Users;
using Domain.Repository;

namespace Core.Common.Authentication
{
	public interface ITokenProcessor
	{
		string TokenById(Guid id);

		Task<AuthorizedUserModel?> UserByToken(string token);

		public class Base(IUserRepository userRepository, IRandom random, ITokenGenerator tokenGenerator) : ITokenProcessor
		{
			private const string VerificationKey = "123asdewq1312";

			public string TokenById(Guid id)
			{
				return tokenGenerator.Token(random.RandomString(32, 64), id.ToString(),
					DateTime.Now.Ticks.ToString(), random.RandomString(32, 64), VerificationKey,
					random.RandomString(32, 64));
			}

			public async Task<AuthorizedUserModel?> UserByToken(string token)
			{
				try
				{
					if (string.IsNullOrEmpty(token))
					{
						return null;
					}
					var result = tokenGenerator.Validate(token);
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
							Id = user.Id,
							IsBlocked = user.IsBlocked
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
}