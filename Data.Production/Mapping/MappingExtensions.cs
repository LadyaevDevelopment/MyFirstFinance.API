using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Users;
using ConfirmationCodeEntity = Domain.Entities.ConfirmationCodes.ConfirmationCode;
using ConfirmationCodeModel = Data.Production.Models.ConfirmationCode;
using CountryEntity = Domain.Entities.Countries.Country;
using CountryModel = Data.Production.Models.Country;
using IdentityDocumentEntity = Domain.Entities.Users.IdentityDocument;
using IdentityDocumentModel = Data.Production.Models.IdentityDocument;
using PolicyDocumentEntity = Domain.Entities.PolicyDocuments.PolicyDocument;
using PolicyDocumentModel = Data.Production.Models.PolicyDocument;
using UserEntity = Domain.Entities.Users.User;
using UserModel = Data.Production.Models.User;
using UserResidenceAddressEntity = Domain.Entities.Users.UserResidenceAddress;
using UserResidenceAddressModel = Data.Production.Models.UserResidenceAddress;
using UserTemporaryBanEntity = Domain.Entities.Users.UserTemporaryBan;
using UserTemporaryBanModel = Data.Production.Models.UserTemporaryBan;

namespace Data.Production.Mapping
{
	public static class MappingExtensions
	{
		public static PolicyDocumentEntity ToEntity(this PolicyDocumentModel model)
		{
			return new PolicyDocumentEntity(
				model.Id,
				model.Title,
				model.Path);
		}

		public static PolicyDocumentModel ToModel(this PolicyDocumentEntity entity)
		{
			return new PolicyDocumentModel
			{
				Id = entity.Id,
				Title = entity.Title,
				Path = entity.Path
			};
		}

		public static UserEntity ToEntity(this UserModel model)
		{
			return new UserEntity(
				model.Id,
				model.LastName,
				model.FirstName,
				model.MiddleName,
				model.BirthDate,
				model.PinCode,
				model.PhoneNumber,
				model.Email,
				model.AvatarPath,
				model.IsBlocked,
				RegistrationDate: model.RegistrationDate,
				(UserStatus)model.StatusId)
			{
				UserTemporaryBans = model.UserTemporaryBans.Select(item => item.ToEntity()).ToList(),
			};
		}

		public static UserModel ToModel(this UserEntity entity)
		{
			return new UserModel
			{
				Id = entity.Id,
				LastName = entity.LastName,
				FirstName = entity.FirstName,
				MiddleName = entity.MiddleName,
				BirthDate = entity.BirthDate,
				PinCode = entity.PinCode,
				PhoneNumber = entity.PhoneNumber,
				Email = entity.Email,
				AvatarPath = entity.AvatarPath,
				IsBlocked = entity.IsBlocked,
				RegistrationDate = entity.RegistrationDate,
				StatusId = (int)entity.Status
			};
		}

		public static CountryEntity ToEntity(this CountryModel model)
		{
			return new CountryEntity(
				model.Id,
				model.Name,
				model.Iso2Code,
				model.PhoneNumberCode,
				model.FlagImagePath,
				model.CountryPhoneNumberMasks.Select(item => item.Mask).ToArray());
		}

		public static CountryModel ToModel(this CountryEntity entity)
		{
			return new CountryModel
			{
				Id = entity.Id,
				Name = entity.Name,
				Iso2Code = entity.Iso2Code,
				PhoneNumberCode = entity.PhoneNumberCode,
				FlagImagePath = entity.FlagImageUrl,
				CountryPhoneNumberMasks = entity.PhoneNumberMasks.Select(item => new Models.CountryPhoneNumberMask
				{
					CountryId = entity.Id,
					Mask = item
				}).ToList()
			};
		}

		public static ConfirmationCodeEntity ToEntity(this ConfirmationCodeModel model)
		{
			return new ConfirmationCodeEntity(
				model.Id,
				model.UserId,
				model.Code,
				model.CreationDate,
				(ConfirmationCodeStatus)model.StatusId,
				model.FailedCodeConfirmationAttemptCount);
		}

		public static ConfirmationCodeModel ToModel(this ConfirmationCodeEntity entity)
		{
			return new ConfirmationCodeModel
			{
				Id = entity.Id,
				UserId = entity.UserId,
				Code = entity.Code,
				CreationDate = entity.CreationDate,
				StatusId = (int)entity.Status,
				FailedCodeConfirmationAttemptCount = entity.FailedCodeConfirmationAttemptCount
			};
		}

		public static UserTemporaryBanEntity ToEntity(this UserTemporaryBanModel model)
		{
			return new UserTemporaryBanEntity(
				model.Id,
				model.UserId,
				model.StartDate,
				model.DurationInSeconds);
		}

		public static UserTemporaryBanModel ToModel(this UserTemporaryBanEntity entity)
		{
			return new UserTemporaryBanModel
			{
				Id = entity.Id,
				UserId = entity.UserId,
				StartDate = entity.StartDate,
				DurationInSeconds = entity.DurationInSeconds,
			};
		}

		public static UserResidenceAddressEntity ToEntity(this UserResidenceAddressModel model)
		{
			return new UserResidenceAddressEntity(
				model.Id,
				model.CountryId,
				model.City,
				model.Street,
				model.BuildingNumber,
				model.ApartmentNumber);
		}

		public static UserResidenceAddressModel ToModel(this UserResidenceAddressEntity entity)
		{
			return new UserResidenceAddressModel
			{
				Id = entity.Id,
				CountryId = entity.CountryId,
				City = entity.City,
				Street = entity.Street,
				BuildingNumber = entity.BuildingNumber,
				ApartmentNumber = entity.ApartmentNumber,
			};
		}

		public static IdentityDocumentEntity ToEntity(this IdentityDocumentModel model)
		{
			return new IdentityDocumentEntity(
				model.Id,
				model.UserId,
				model.Skipped,
				model.Path);
		}

		public static IdentityDocumentModel ToModel(this IdentityDocumentEntity entity)
		{
			return new IdentityDocumentModel
			{
				Id = entity.Id,
				UserId = entity.UserId,
				Skipped = entity.Skipped,
				Path = entity.Path,
			};
		}
	}
}
