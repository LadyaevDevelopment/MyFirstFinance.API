namespace Core.Common.FileService
{
	public interface IFileService
	{
		Task<SaveFileResult> SavedFile(byte[] fileData, string directoryPath);

		public class Base : IFileService
		{
			private static readonly System.Random random = new();

			public async Task<SaveFileResult> SavedFile(byte[] fileData, string directoryPath)
			{
				try
				{
					if (!Directory.Exists(directoryPath))
					{
						Directory.CreateDirectory(directoryPath);
					}

					string uniqueFileName = UniqueFileName();
					string filePath = Path.Combine(directoryPath, uniqueFileName);

					await File.WriteAllBytesAsync(filePath, fileData);
					return new SaveFileResult.Success(new SavedFile(filePath));
				}
				catch (Exception ex)
				{
					return new SaveFileResult.Failure(ex);
				}
			}

			private static string UniqueFileName()
			{
				const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
				const int length = 16;
				char[] stringChars = new char[length];

				for (int i = 0; i < length; i++)
				{
					stringChars[i] = chars[random.Next(chars.Length)];
				}

				return new string(stringChars);
			}
		}
	}
}
