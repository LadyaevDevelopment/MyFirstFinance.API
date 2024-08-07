﻿using Api.Communication;
using Api.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Api.Versioning
{
	public class ApiVersionErrorProvider : IErrorResponseProvider
	{
		public IActionResult CreateResponse(ErrorResponseContext context)
		{
			return new JsonResult(new SimpleResponseWrapper<EmptyResponse>(OperationStatus.UnsupportedApiVersion));
		}
	}
}
