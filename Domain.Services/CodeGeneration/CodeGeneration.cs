using Common;

namespace Domain.Services.CodeGeneration
{
	public abstract class CodeGeneration
	{
		public abstract string DigitalCode(int digitCount);

		public class Base : CodeGeneration
		{
			public override string DigitalCode(int digitCount)
			{
				return Helpers.GenerateRandomString(digitCount, "0123456789");
			}
		}
	}
}
