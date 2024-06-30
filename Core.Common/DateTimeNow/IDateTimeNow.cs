namespace Core.Common.DateTimeNow
{
	public interface IDateTimeNow
	{
		DateTime Now { get; }

		public class Base : IDateTimeNow
		{
			public DateTime Now => DateTime.Now;
		}
	}
}
