﻿namespace Api.Requests.Registration
{
	public class SpecifyResidenceAddressRequest
	{
		public string CountryId { get; set; } = "";

		public string City { get; set; } = "";

		public string Street { get; set; } = "";

		public string BuildingNumber { get; set; } = "";

		public string ApartmentNumber { get; set; } = "";
	}
}
