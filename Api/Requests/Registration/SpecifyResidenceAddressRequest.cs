using System.ComponentModel.DataAnnotations;

namespace Api.Requests.Registration
{
	public class SpecifyResidenceAddressRequest
	{
        [Required]
        public string CountryId { get; set; } = "";

        [Required]
        public string City { get; set; } = "";

        [Required]
        public string Street { get; set; } = "";

        [Required]
        public string BuildingNumber { get; set; } = "";

        [Required]
        public string ApartmentNumber { get; set; } = "";
	}
}
