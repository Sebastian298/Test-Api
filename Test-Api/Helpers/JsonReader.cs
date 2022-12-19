using Newtonsoft.Json.Linq;
using System.Text;

namespace Test_Api.Helpers
{
				public class JsonReader
				{
								public string[] GetLanguages()
								{
												string pathFile = Directory.GetCurrentDirectory();
												IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(pathFile).AddJsonFile("appsettings.json").Build();
												string[] languages = configuration["Localization"].Split(';');
												return (languages.Length>0) ? languages : new string[] { "es" };
								}

								public string GetArrayFromJson(string jsonFile,string controllerName,string endpointName,string dataType)
								{
												var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFile.ToString());
												var json = JObject.Parse(File.ReadAllText(root, Encoding.Latin1));
												string array = json[controllerName][endpointName][dataType].ToString();
												return array;
								}
				}
}
