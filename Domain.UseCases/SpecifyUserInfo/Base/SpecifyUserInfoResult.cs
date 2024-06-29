namespace Domain.UseCases.SpecifyUserInfo.Base
{
	public class SpecifyUserInfoResult
	{
		public bool Successful { get; }

		public SpecifyUserInfoData? Data { get; }

		public SpecifyUserInfoError? Error { get; }

		private SpecifyUserInfoResult(bool successful, SpecifyUserInfoData? data, SpecifyUserInfoError? error)
		{
			Successful = successful;
			Data = data;
			Error = error;
		}

		public class Success(SpecifyUserInfoData data) : SpecifyUserInfoResult(true, data, null);

		public class Failure(SpecifyUserInfoError error) : SpecifyUserInfoResult(false, null, error);
	}
}
