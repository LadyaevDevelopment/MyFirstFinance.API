namespace Api.Communication
{
	public enum OperationStatus
	{
		Success = 1,
		Failed = 2,
		Forbidden = 3,
		InvalidRequest = 4,
		NotFound = 5,
		UnsupportedApiVersion = 6,
		TooManyRequests = 7,
	}
}
