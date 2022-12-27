using Newtonsoft.Json;
using System.Reflection;
using Test_Api.Models.ResponseModels;
using static Test_Api.Constants.MessageSetting;
namespace Test_Api.Helpers
{
				public class MessageErrorBuilder<T>
				{
								public GenericResponse<T> GetGenericErrorResponse(int statusCode,string controllerName,string methodName,string messageName,string type,Exception ex,string innerExceptionMessage = null)
								{
												GenericResponse<T> response = new GenericResponse<T>();
												GenericResponseData messages = GetMessageList(controllerName, methodName, messageName, type, ex, innerExceptionMessage);

												response.Messages = messages;
												response.StatusCode = statusCode;
												return response;
								}

								public GenericResponseData GetMessageList(string controllerName, string methodName, string messageName, string type, Exception ex, string innerExceptionMessage = null)
								{
												JsonReader reader = new();

												var controller = (ex is not null) ? (ex.InnerException is not null & ex.InnerException.Data["controllerName"] is not null) ? ex.InnerException.Data["controllerName"].ToString() : controllerName : controllerName;

												var method = (ex != null) ? (ex.InnerException != null && ex.InnerException.Data["methodName"] != null) ? ex.InnerException.Data["methodName"].ToString() : methodName : methodName;

												var message = (ex != null) ? (ex.InnerException != null && ex.InnerException.Data["messageName"] != null) ? ex.InnerException.Data["messageName"].ToString() : messageName : messageName;

												var type_ = (ex != null) ? (ex.InnerException != null && ex.InnerException.Data["type"] != null) ? ex.InnerException.Data["type"].ToString() : type : type;

												//var parameters_ = (ex != null) ? (ex.InnerException != null && ex.InnerException.Data["parameters"] != null) ? (string[])ex.InnerException.Data["parameters"] : null : null;

												var AlertMessages = reader.GetGenericErrorList(controller, method, message, (ex != null) ? (innerExceptionMessage != null && innerExceptionMessage != "") ? innerExceptionMessage : ex.Message : innerExceptionMessage, type_);

												//foreach (var alert in AlertMessages)
												//{
												//				if (parameters_ != null)
												//				{
												//								int cont = 1;
												//								foreach (string param in parameters_)
												//								{
												//												alert.Message = alert.Message.Replace($"{{parameter{cont}}}", param);
												//												cont += 1;
												//								}
												//				}
												//}

												GenericResponseData messages = AlertMessages;

												return messages;
								}

								public Exception GetException(string controllerName, string methodName, string messageName, MessageTypes type, HttpStatusCodes statusCode, string[] parameters = null)
								{
												Exception ex = new Exception();
												ex.Data.Add("controllerName", controllerName);
												ex.Data.Add("methodName", methodName);
												ex.Data.Add("message",messageName);
												ex.Data.Add("type", type.ToString());
												ex.Data.Add("statusCode", ((int)statusCode));
												if (parameters is not null)
												{
																ex.Data.Add("parameters", parameters);
												}
												return ex;
								}
				}
}
