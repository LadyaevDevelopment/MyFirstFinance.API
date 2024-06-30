using System.Text;
using Troschuetz.Random.Generators;

namespace Core.Common.Random
{
	public interface IRandom
	{
		private const string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";

		string RandomString(int length, string alphabet = Alphabet);

		string RandomString(int minLength, int maxLength, string alphabet = Alphabet);

		int RandomInt(int minValue, int maxValue);

		int RandomInt(int digitsCount);

		public class Base : IRandom
		{
			private static readonly AbstractGenerator RandomGenerator = new StandardGenerator();

			public string RandomString(int length, string alphabet = Alphabet)
			{
				var builder = new StringBuilder();
				for (var i = 0; i < length; ++i)
				{
					builder.Append(alphabet[RandomGenerator.Next(0, alphabet.Length - 1)]);
				}
				return builder.ToString();
			}

			public string RandomString(int minLength, int maxLength, string alphabet = Alphabet)
			{
				return RandomString(RandomGenerator.Next(minLength, maxLength), alphabet);
			}

			public int RandomInt(int minValue, int maxValue)
			{
				return RandomGenerator.Next(minValue, maxValue + 1);
			}

			public int RandomInt(int digitsCount)
			{
				digitsCount = Math.Clamp(digitsCount, 2, 9);
				var min = int.Parse("1" + new string(Enumerable.Repeat('0', digitsCount - 1).ToArray()));
				var max = min * 10 - 1;
				return RandomInt(min, max);
			}
		}
	}
}
