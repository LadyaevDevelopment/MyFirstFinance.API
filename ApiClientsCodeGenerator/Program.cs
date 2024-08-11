using Api.Communication;
using SpaceApp.Dev.ApiToMobile;
using SpaceApp.Dev.ApiToMobile.Converters.Android;
using SpaceApp.Dev.ApiToMobile.Settings;
using System.Diagnostics;

var outputDirectory = "output";
if (Directory.Exists(outputDirectory))
{
	try
	{
		Directory.Delete(outputDirectory, true);
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Невозможно очистить директорию {outputDirectory}: {ex}");
	}
}
new CodeGenerator().Generate(new GeneratorSettings
{
	Assembly = typeof(OperationStatus).Assembly,
	OutputDirectory = outputDirectory,
	AndroidPackage = new AndroidPackage("ladyaev.development.myfirstfinance.core.api"),
	ApiClientMethodTypes = ApiClientMethodType.Asynchronous,
	PropertiesNamingPolicy = ApiNamingPolicy.CamelCase,
	EnumSerializationStrategy = EnumSerializationStrategy.CamelCase,
	DateSerializationStrategy = DateSerializationStrategy.Iso8601
});

Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory(), outputDirectory, "Android", "Kotlin"));