namespace Api.Communication
{
	public class ResponseWrapper<TResponse, TError> where TResponse : class where TError : class
	{
		public OperationStatus Status { get; set; }

		public TResponse? ResponseData { get; set; }

		public TError? Error { get; set; }

		public string? ErrorMessage { get; set; }

		public ResponseWrapper(OperationStatus status)
		{
			Status = status;
		}

		public ResponseWrapper(TResponse response)
		{
			Status = OperationStatus.Success;
			ResponseData = response;
		}

		public ResponseWrapper(OperationStatus status, TError? error, string? errorMessage)
		{
			Status = status;
			Error = error;
			ErrorMessage = errorMessage;
		}
	}

	public class ResponseWrapper<TResponse> : ResponseWrapper<TResponse, object> where TResponse : class
	{
		public ResponseWrapper(OperationStatus status) : base(status)
		{

		}

		public ResponseWrapper(TResponse response) : base(response)
		{

		}

		public ResponseWrapper(OperationStatus status, string? errorMessage) : base(status, null, errorMessage)
		{

		}
	}
}
