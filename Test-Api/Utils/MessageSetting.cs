namespace Test_Api.Utils
{
				public class MessageSetting
				{
								enum MessageTypes
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

								enum HttpStatusCodes
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
