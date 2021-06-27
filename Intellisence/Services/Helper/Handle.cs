using System;

namespace Services.Helper
{
	public class Handle
	{
		public static string ToString(object inputString) => Convert.ToString(inputString) ?? "";
	}
}
