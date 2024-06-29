namespace Domain.Services.DateTimeNow
{
	public abstract class DateTimeNow
	{
		public abstract DateTime Now { get; }

		public class Base : DateTimeNow
		{
			public override DateTime Now => DateTime.Now;
		}
	}
}
