using Api.Authentication;
using Api.Communication.Converter;
using Api.Middleware;
using Api.SwaggerOptions.OperationFilters;
using Api.SwaggerOptions.SchemaFilters;
using Api.Versioning;
using Core.DI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyFirstFinance", Version = "v1" });
	options.OperationFilter<AddRequiredAuthTokenParameter>();
	options.SchemaFilter<EnumSchemaFilter>();
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = @"Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				},
				Scheme = "oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header,
			},
			new List<string>()
		}
	});
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
	options.SerializerSettings.ContractResolver = new DefaultContractResolver
	{
		NamingStrategy = new CamelCaseNamingStrategy()
	};
	options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
	options.SerializerSettings.Converters.Add(new DateTimeConverter());
	options.SerializerSettings.Converters.Add(new DateOnlyConverter());
	options.SerializerSettings.Converters.Add(new StringEnumConverter());
}).ConfigureApiBehaviorOptions(options =>
{
	options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddApiVersioning(options =>
{
	options.ApiVersionReader = new UrlSegmentApiVersionReader();
	options.ErrorResponses = new ApiVersionErrorProvider();
	options.DefaultApiVersion = new ApiVersion(1, 0);
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
	setup.GroupNameFormat = "'v'VVV";
	setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddAuthentication(DefaultApiAuthenticationOptions.DefaultScheme).AddDefaultApiAuthentication();

builder.Services.AddAuthorization();

ServiceRegistration.Register(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
