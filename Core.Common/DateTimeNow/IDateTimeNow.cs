namespace Core.Common.DateTimeNow
{
    public interface IDateTimeNow
	{
        DateTimeOffset Now { get; }

		public class Base : IDateTimeNow
		{
			public DateTimeOffset Now => DateTimeOffset.Now;
		}
	}
}
