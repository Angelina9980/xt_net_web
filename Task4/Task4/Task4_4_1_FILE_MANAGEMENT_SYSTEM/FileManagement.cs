using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.FileIO;

namespace Task4_4_1_FILE_MANAGEMENT_SYSTEM
{
    public class FileManagement : IDisposable
    {
        public string directoryPath;
        public string backupdirectoryPath = @"C:\BackupFolder";
        public DirectoryInfo dirInfo,
            backeupDirInfo;

        public FileManagement(string possibleDirectoryPath)
        {
            if (!Directory.Exists(possibleDirectoryPath))
            {
                throw new DirectoryNotFoundException(possibleDirectoryPath);
            }
            directoryPath = possibleDirectoryPath;

            dirInfo = new DirectoryInfo(directoryPath);
            backeupDirInfo = new DirectoryInfo(backupdirectoryPath);

            if (!Directory.Exists(backupdirectoryPath))
            {
                try
                {
                    Directory.CreateDirectory(backupdirectoryPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            FileActions();
        }

        private void FileActions()
        {
            Console.Clear();
            Console.WriteLine("Please select the desired mode :");
            Console.WriteLine("T - tracking mode");
            Console.WriteLine("U - undo changes mode");
            Console.Write("Your choice is : ");
            var keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.T)
            {
                Console.Clear();
                Console.WriteLine("The tracking mode is enabled!");

                using (FileSystemWatcher watcher = new FileSystemWatcher(dirInfo.FullName))
                {
                    watcher.IncludeSubdirectories = true;
                    watcher.Path = directoryPath;

                    watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName
                    | NotifyFilters.Size | NotifyFilters.Attributes | NotifyFilters.CreationTime;

                    //tracking only txt files
                    watcher.Filter = "*.txt";

                    watcher.Changed += OnChanged;
                    watcher.Created += OnChanged;
                    watcher.Deleted += OnChanged;
                    watcher.Renamed += OnChanged;
                    watcher.Error += OnOverflow;

                    watcher.EnableRaisingEvents = true;

                    try
                    {
                        backeupDirInfo.CreateSubdirectory(DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine("Press 'enter' to out the tracking.");
                    var keyChoice = Console.ReadKey();
                    while (keyChoice.Key != ConsoleKey.Enter) ;
                }
            }
            if (keyInfo.Key == ConsoleKey.U)
            {
                Console.Clear();

                if (Directory.GetDirectories(backupdirectoryPath).Length + Directory.GetFiles(backupdirectoryPath).Length <= 0)
                {
                    Console.WriteLine("There have been no changes yet");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The undo changes mode is enabled!");
                    Console.WriteLine("Please enter the date and time to roll back the filles according to the format : '{0}'", DateTime.Now.Date);
                    Console.Write("The date to roll back is : ");
                    string date = Console.ReadLine();
                    int hour = 0,
                        minute = 0,
                        second = 0;
                    Console.WriteLine("The time to roll back is : ");
                    try
                    {
                        Console.Write("Hour  : ");
                        hour = int.Parse(Console.ReadLine());
                        Console.Write("Minute  : ");
                        minute = int.Parse(Console.ReadLine());
                        Console.Write("Second  : ");
                        second = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    string time = hour.ToString() + "." + minute.ToString() + "." + second.ToString();
                    RollBack(date, time);
                }
            }
        }
        private void OnChanged(object source, FileSystemEventArgs fileArgs)
        {
            DirectoryInfo filesSet = new DirectoryInfo(backeupDirInfo + "\\" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year +
                "\\" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second);
            try
            {
                filesSet.Create();
                FileSystem.CopyDirectory(dirInfo.FullName, filesSet + "\\", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"File : {fileArgs.FullPath} {fileArgs.ChangeType}");
        }
        private static void OnOverflow(object source, ErrorEventArgs e)
        {
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
        }
        public void RollBack(string date, string time)
        {
            try
            {
                var backDir = backeupDirInfo.GetDirectories();

                for (int i = 0; i < backDir.Length; i++)
                {
                    if (backDir[i].Name.Equals(date))
                    {
                        DirectoryInfo filesDate = new DirectoryInfo(backDir[i].FullName);
                        var filesTimeDir = filesDate.GetDirectories();

                        for (int j = 0; j < filesTimeDir.Length; j++)
                        {
                            if (filesTimeDir[j].Name.Equals(time))
                            {
                                FileSystem.CopyDirectory(filesTimeDir[j].FullName, dirInfo.FullName, true);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Dispose()
        {
            Console.WriteLine("Press any key to exit the program");
        }
    }
}
