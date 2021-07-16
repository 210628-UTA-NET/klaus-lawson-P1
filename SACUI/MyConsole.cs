using System;
namespace SACUI
{
    public class MyConsole
    {
        public static void WriteNormal(string p_message){
            Console.WriteLine(p_message,Console.ForegroundColor=ConsoleColor.White);
            Console.ResetColor();
        }
        public static void WriteNormalOneLine(string p_message){
            Console.Write(p_message,Console.ForegroundColor=ConsoleColor.White);
            Console.ResetColor();
        }
        public static void WriteError(string p_message){
            Console.WriteLine(p_message,Console.ForegroundColor=ConsoleColor.Red);
            Console.ResetColor();
        }
        public static void WriteSuccess(string p_message){
            Console.WriteLine(p_message,Console.ForegroundColor=ConsoleColor.Green);
            Console.ResetColor();
        }
        public static void WriteTitle(string p_message){
            Console.WriteLine(p_message,Console.ForegroundColor=ConsoleColor.DarkYellow);
            Console.ResetColor();
        }
    }
}