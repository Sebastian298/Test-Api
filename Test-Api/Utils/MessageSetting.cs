namespace Test_Api.Constants
{
				public class MessageSetting
				{
								public enum MessageTypes
								{
												danger,
												warning,
												success,
												info,
												primary,
												secondary,
												dark,
												light
								}

								public enum HttpStatusCodes
								{
												Ok = 200,
												BadRequest = 400,
												Unauthorized = 401,
												Forbidden = 403,
												NotFound = 404,
												InternalServerError=500
								}
				}
}
