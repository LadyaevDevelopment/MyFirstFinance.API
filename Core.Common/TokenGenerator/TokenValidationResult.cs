namespace Core.Common.TokenGenerator
{
	public class TokenValidationResult(bool isValid, IList<string> extractedValues)
	{
		public bool IsValid { get; set; } = isValid;
		public IList<string> ExtractedValues { get; set; } = extractedValues;
	}
}
