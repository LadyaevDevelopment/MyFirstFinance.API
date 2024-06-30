using Domain.Entities.Countries;
using System.Text.RegularExpressions;

namespace Core.Common.PhoneNumber
{
	public interface IPhoneNumberValidation
	{
		string? ValidPhoneNumberOrNull(string countryPhoneCode, string phoneNumber, List<Country> countries);

		public class Base : IPhoneNumberValidation
		{
			public string? ValidPhoneNumberOrNull(string countryPhoneCode, string phoneNumber, List<Country> countries)
			{
				var countryByCode = countries.FirstOrDefault(item => item.PhoneNumberCode == countryPhoneCode);
				if (countryByCode is null)
				{
					return null;
				}
				foreach (var mask in countryByCode.PhoneNumberMasks)
				{
					string pattern = MaskToRegex(mask);
					if (Regex.IsMatch(phoneNumber, pattern))
					{
						return countryPhoneCode + " " + phoneNumber;
					}
				}
				return null;
			}

			private static string MaskToRegex(string mask)
			{
				string escapedMask = Regex.Escape(mask);
				string pattern = escapedMask.Replace("\\#", "\\d");
				pattern = "^" + pattern + "$";
				return pattern;
			}
		}
	}
}
