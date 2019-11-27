using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Start_Up
{
    static class ExceptionHelper
    {
        public static void ExceptionAndLineNumber(Exception ex, string problemClass)
        {
            int lineNumber;
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            lineNumber = Convert.ToInt32(ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')));
            Console.WriteLine(trace.GetFrame(0).GetMethod().ReflectedType.FullName);
            Console.WriteLine(ex.Message + " Problem line = " + lineNumber + " Problem class = " + problemClass);
        }
    }
}
