using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Troschuetz.Random.Generators;

namespace Common
{
	public static partial class Helpers
	{
		private static readonly AbstractGenerator RandomGenerator = new StandardGenerator();

		public static string? CleanPhone(string phone)
		{
			if (phone == null)
			{
				return null;
			}
			phone = new string(phone.Where(char.IsDigit).ToArray());
			if (phone.Length < 10 || phone.StartsWith("+"))
			{
				return phone;
			}
			if (phone.Length == 10)
			{
				phone = "7" + phone;
			}
			else if (phone.StartsWith("8"))
			{
				phone = "7" + phone.Substring(1);
			}
			return '+' + phone;
		}

		public static string GenerateRandomString(int length = 32, string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789")
		{
			var builder = new StringBuilder();
			for (var i = 0; i < length; ++i)
			{
				builder.Append(alphabet[RandomGenerator.Next(0, alphabet.Length - 1)]);
			}
			return builder.ToString();
		}

		public static string GenerateRandomString(int minLength, int maxLength, string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789")
		{
			return GenerateRandomString(RandomGenerator.Next(minLength, maxLength), alphabet);
		}

		public static int GenerateRandomInt(int minValue, int maxValue)
		{
			return RandomGenerator.Next(minValue, maxValue + 1);
		}

		public static int GenerateRandomInt(int digitsCount)
		{
			digitsCount = Math.Clamp(digitsCount, 2, 9);
			var min = int.Parse("1" + new string(Enumerable.Repeat('0', digitsCount - 1).ToArray()));
			var max = min * 10 - 1;
			return GenerateRandomInt(min, max);
		}

		public static string? GetPasswordHash(string s)
		{
			if (s == null)
			{
				return null;
			}
			var hash = SHA512.HashData(Encoding.Unicode.GetBytes(s));
			return string.Concat(hash.Select(item => item.ToString("x2")));
		}

		public static bool IsEmailValid(string email)
		{
			return email != null && EmailRegex().IsMatch(email);
		}

		[GeneratedRegex("^[0-9a-zA-Z]([.-]?\\w+)*@[0-9a-zA-Z]([.-]?[0-9a-zA-Z])*(\\.[0-9a-zA-Z]{2,4})+$")]
		private static partial Regex EmailRegex();
	}
}
