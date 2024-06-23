namespace Api.Requests.Misc
{
	public class AddressesRequest
	{
		public string CountryIso2Code { get; set; } = "";

		public string SearchQuery { get; set; } = "";
	}
}
