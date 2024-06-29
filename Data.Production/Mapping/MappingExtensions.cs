﻿using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Users;
using ConfirmationCodeEntity = Domain.Entities.ConfirmationCodes.ConfirmationCode;
using ConfirmationCodeModel = Data.Production.Models.ConfirmationCode;
using CountryEntity = Domain.Entities.Countries.Country;
using CountryModel = Data.Production.Models.Country;
using PolicyDocumentEntity = Domain.Entities.PolicyDocuments.PolicyDocument;
using PolicyDocumentModel = Data.Production.Models.PolicyDocument;
using UserEntity = Domain.Entities.Users.User;
using UserModel = Data.Production.Models.User;
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
				StatusId = (int)entity.Status
			};
		}

		public static CountryEntity ToEntity(this CountryModel model)
		{
			return new CountryEntity(
				model.Name,
				model.Iso2Code,
				model.PhoneNumberCode,
				model.FlagImagePath,
				model.CountryPhoneNumberMasks.Select(item => item.Mask).ToArray());
		}

		public static CountryModel ToModel(this CountryEntity entity)
		{
			// TODO: Pass Id
			return new CountryModel
			{
				Name = entity.Name,
				Iso2Code = entity.Iso2Code,
				PhoneNumberCode = entity.PhoneNumberCode,
				FlagImagePath = entity.FlagImageUrl,
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
	}
}
