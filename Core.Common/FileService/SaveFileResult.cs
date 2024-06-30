namespace Core.Common.FileService
{
	public class SaveFileResult
	{
		public bool Successful { get; set; }

		public SavedFile? Data { get; set; }

		public Exception? Error { get; set; }

		private SaveFileResult(bool successful, SavedFile? data, Exception? error)
		{
			Successful = successful;
			Data = data;
			Error = error;
		}

		public class Success(SavedFile data) : SaveFileResult(true, data, null);

		public class Failure(Exception error) : SaveFileResult(false, null, error);
	}
}
