//var text = File.ReadAllText("Input.txt");

//text = text.Replace("\t\t\tnew Country(", "\t\t\tnew Country(\r\n\t\t\t\tId: Guid.NewGuid(),");

//File.WriteAllText("Output.txt", text);

using Helpers;

await SaveCountries.Process();