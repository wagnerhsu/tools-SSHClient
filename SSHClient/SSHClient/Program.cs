﻿using System;
using System.Collections.Generic;
using SSHClient.Modules;
using SSHClient.Auth;

namespace SSHClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //using github.com/h4wkst3r dictionary technique to build an argument list
                Dictionary<string, string> argDict = ParseTheArguments(args);

                // print help if no arguments are supplieds
                if ((args.Length > 0 && argDict.Count == 0) || argDict.ContainsKey("h"))
                {
                    Help Help = new Help();
                    return;
                }

                // this handles inspecting the arguments, selecting the right modules and executing them
                ArgumentLogic ArgumentLogic = new ArgumentLogic();
                ArgumentLogic.AuthenticationType(argDict);
            }
            catch (NullReferenceException ex)
            {

            }
        } // end main

        // ParseTheArguments
        public static Dictionary<string, string> ParseTheArguments(string[] args)
        {
            try
            {
                Dictionary<string, string> ret = new Dictionary<string, string>();
                if (args.Length % 2 == 0 || args.Length % 3 == 0 && args.Length > 0)
                {
                    for (int i = 0; i < args.Length; i = i + 2)
                    {
                        ret.Add(args[i].Substring(1, args[i].Length - 1).ToLower(), args[i + 1]);

                    }
                }

                return ret;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("\n[!] You specified duplicate switches. Check your command again.\n");
                return null;
            }
        } // end ParseTheArguments
    }
}