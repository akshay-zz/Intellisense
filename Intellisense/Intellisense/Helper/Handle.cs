using System;

namespace Intellisense.Helper
{
    public class Handle
    {
		public static string ToString(object inputString) => Convert.ToString(inputString) ?? "";
	}
}
