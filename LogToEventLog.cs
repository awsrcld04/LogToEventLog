using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace LogToEventLog
{
    class LTELMain
    {
        static void funcLogToEventLog(string strAppName, string strEventMsg, int intEventType)
        {
            //[DebugLine] Console.WriteLine(strAppName);
            //[DebugLine] Console.WriteLine(strEventMsg);
            //[DebugLine] Console.WriteLine(intEventType.ToString());

            string sLog;

            sLog = "Application";

            if (!EventLog.SourceExists(strAppName))
                EventLog.CreateEventSource(strAppName, sLog);

            //EventLog.WriteEntry(strAppName, strEventMsg);
            EventLog.WriteEntry(strAppName, strEventMsg, EventLogEntryType.Information, intEventType);

        } // LogToEventLog

        static void funcPrintProgramSyntax()
        {
            Console.WriteLine("LogToEventLog v1.0 (c) 2012 SystemsAdminPro.com");
            Console.WriteLine();
            Console.WriteLine("Parameter syntax: [requires two parameters]");
            Console.WriteLine();
            Console.WriteLine("Specify the application name or the name that you");
            Console.WriteLine("want to show up in the Event Log for the first parameter:");
            Console.WriteLine();
            Console.WriteLine("For example:");
            Console.WriteLine("-MyApplication        to use to specify the application name");
            Console.WriteLine();
            Console.WriteLine("Use one of the following as parameters for the Event ID:");
            Console.WriteLine("-9900                 to specify that the program was called; the end of execution may not be known");
            Console.WriteLine("-9901                 to specify the start of the program");
            Console.WriteLine("-9902                 to specify the end of the program");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("LogToEventLog -MyApplication -9900");
            Console.WriteLine("LogToEventLog -MyApplication -9901");
            Console.WriteLine("LogToEventLog -MyApplication -9902");
        }

        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("Parameters must be specified to run LogToEventLog.");
                Console.WriteLine("Run LogToEventLog -? to get the parameter syntax.");
            }
            else
            {
                if (args[0] == "-?")
                {
                    funcPrintProgramSyntax();
                }
                else
                {
                    // Output current date & time
                    // Console.WriteLine(DateTime.Now);
                    string strEvtLogAppName = "";
                    string strEvtLogAppEvtID = "";
                    string strEvtLogAppEvtMsg = "";
                    int intEvtLogAppEvtID = 0;
                    bool bEventLogged = false;

                    if (args.Length == 1)
                    {
                        Console.WriteLine("Only one parameter specified.");
                        Console.WriteLine("Run LogToEventLog -? to get the parameter syntax.");
                    }
                    else
                    {
                        strEvtLogAppName = args[0].Substring(1);
                        //[DebugLine] Console.WriteLine(strEvtLogAppName);

                        strEvtLogAppEvtID = args[1].Substring(1);
                        //[DebugLine] Console.WriteLine(strEvtLogAppEvtID);

                        bool bValidEventID = false;

                        try
                        {
                            intEvtLogAppEvtID = Int32.Parse(strEvtLogAppEvtID);
                            //[DebugLine] Console.WriteLine(intEvtLogAppEvtID.ToString());
                            bValidEventID = true;
                        }
                        catch
                        {
                            bValidEventID = false;
                            Console.WriteLine("No event was logged. Check parameters.");
                            Console.WriteLine("Run LogToEventLog -? to get the parameter syntax.");
                        }

                        if (bValidEventID)
                        {

                            if (strEvtLogAppEvtID == "9900")
                            {
                                strEvtLogAppEvtMsg = strEvtLogAppName + " was called.";
                                funcLogToEventLog(strEvtLogAppName, strEvtLogAppEvtMsg, intEvtLogAppEvtID);
                                bEventLogged = true;
                            }

                            if (strEvtLogAppEvtID == "9901")
                            {
                                strEvtLogAppEvtMsg = strEvtLogAppName + " started.";
                                funcLogToEventLog(strEvtLogAppName, strEvtLogAppEvtMsg, intEvtLogAppEvtID);
                                bEventLogged = true;
                            }

                            if (strEvtLogAppEvtID == "9902")
                            {
                                strEvtLogAppEvtMsg = strEvtLogAppName + " ended.";
                                funcLogToEventLog(strEvtLogAppName, strEvtLogAppEvtMsg, intEvtLogAppEvtID);
                                bEventLogged = true;
                            }

                            if (!bEventLogged)
                            {
                                Console.WriteLine("No event was logged. Check parameters.");
                                Console.WriteLine("Run LogToEventLog -? to get the parameter syntax.");
                            }
                        }

                    } //third if else
                } //second if else
            } //first if else

        } // Main

    }
}
