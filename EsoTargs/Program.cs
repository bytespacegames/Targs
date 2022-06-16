using System;
using System.Collections.Generic;
using System.Text;

namespace EsoTargs
{
    class Program
    {
        static int current = 0;
        static int pointerLoc = 0;
        static List<int> vals = new List<int>();
        static string code = "n9 w9";
        static string[] commands = code.Split(" ");

        static bool lineStarted = false;
        static void Main(string[] args)
        {
            for (int i = 0; i < 69420; i++)
            {
                vals.Add(0);
            }
            runArg();
        }
        static void runArg()
        {
            string cmd = (commands[current])[0].ToString();
            string val = (commands[current])[1].ToString();

            switch (cmd)
            {
                case "r":
                    pointerLoc += int.Parse(val);
                    break;
                case "l":
                    pointerLoc -= int.Parse(val);
                    break;
                case "u":
                    vals[pointerLoc] += int.Parse(val);
                    break;
                case "d":
                    vals[pointerLoc] -= int.Parse(val);
                    break;
                case "p":
                    if (lineStarted)
                    {
                        Console.Write("\n");
                    }
                    Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(vals[int.Parse(val)]) }));
                    lineStarted = true;
                    break;
                case "w":
                    Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(vals[int.Parse(val)]) }));
                    lineStarted = true;
                    break;
                case "i":
                    current += 1;

                    if (vals[int.Parse(val)] != 0)
                    {
                        runArg();
                    }
                    break;
                case "n":
                    int i = 0;
                    string s = Console.ReadKey().KeyChar.ToString();
                    try  {
                        i = int.Parse(s);
                    } catch (FormatException)
                    {
                        i = 0;
                    }
                    vals[int.Parse(val)] = i;
                    break;
                case "c":
                    char sc = Console.ReadKey().KeyChar;

                    vals[int.Parse(val)] = (int)sc;

                    break;

            }
            current += 1;
            if (current < commands.Length)
            {
                runArg();
            }
        }
    }
}
