using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	public static class Error
	{
		public enum ErrorType
		{
			None,
			Warning,
			Error
		};
		public delegate void ErrorHandler(ErrorType et, string em);


		public static string CurrentErr = "";
		public static ErrorType CurrentErrType = ErrorType.None;


		/// <summary>
		/// Called every time an error occurs
		/// </summary>
		public static ErrorHandler ErrorEvent = new ErrorHandler((_, _) => {});


		/// <summary>
		/// Remembers the error and invokes the event
		/// </summary>
		public static void EmitError(ErrorType errType, string errMess)
		{
			CurrentErr = errMess;
			CurrentErrType = errType;
			ErrorEvent.Invoke(errType, errMess);
		}
	}
}
