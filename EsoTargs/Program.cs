using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EsoTargs
{
    class Program
    {
        static int current = 0;
        static int pointerLoc = 0;
        static List<int> vals = new List<int>();
        static string code = "hola";
        static string[] commands;

        static string filename = "script";

        static bool lineStarted = false;
        static void Main(string[] args)
        {
            code = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @filename + ".tgs");
            commands = code.Trim().Split(" ");
            for (int i = 0; i < 69420; i++)
            {
                vals.Add(0);
            }
            runArg();
        }
        static void runArg()
        {
            string cmd = (commands[current])[0].ToString().Trim();
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
                    if (val.ToLower().Equals("p"))
                    {
                        Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(vals[pointerLoc]) }));
                        lineStarted = true;
                        break;
                    }
                    Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(vals[int.Parse(val)]) }));
                    lineStarted = true;
                    break;
                case "w":
                    if (val.ToLower().Equals("p"))
                    {
                        Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(vals[pointerLoc]) }));
                        lineStarted = true;
                        break;
                    }
                    Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(vals[int.Parse(val)]) }));
                    lineStarted = true;
                    break;
                case "i":
                    current += 1;

                    if (val.ToLower().Equals("p"))
                    {
                        if (vals[pointerLoc] != 0)
                        {
                            runArg();
                        }
                        break;
                    }

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
                    if (val.ToLower().Equals("p"))
                    {
                        vals[pointerLoc] = i;
                        break;
                    }
                    vals[int.Parse(val)] = i;
                    break;
                case "c":
                    char sc = Console.ReadKey().KeyChar;

                    if (val.ToLower().Equals("p"))
                    {
                        vals[pointerLoc] = (int)sc;
                        break;
                    }

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
