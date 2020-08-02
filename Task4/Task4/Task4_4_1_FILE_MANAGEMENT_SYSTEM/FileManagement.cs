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
        private readonly string directoryPath;
        private string backupdirectoryPath = @"C:\BackupFolder";
        private readonly DirectoryInfo dirInfo,
            backeupDirInfo;
        private readonly DateTime formatProvider;

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
            DateTime _;
            DateTime.TryParse(DateTime.Now.ToString(CultureInfo.CurrentCulture), out _);
            formatProvider = _;

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

                    watcher.NotifyFilter = NotifyFilters.LastWrite
                    | NotifyFilters.FileName | NotifyFilters.DirectoryName
                    | NotifyFilters.Size | NotifyFilters.Attributes;

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
                        backeupDirInfo.CreateSubdirectory(formatProvider.Day + "." + formatProvider.Month + "." + formatProvider.Year);
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
                    Console.WriteLine("The undo changes mode is enabled!");
                    Console.WriteLine("Please enter the date and time to roll back the filles according to the format : '{0}'", formatProvider);
                    Console.Write("The date to roll back is : ");
                    string date = Console.ReadLine();
                    Console.WriteLine("The time to roll back is : ");
                    Console.Write("Hour  : ");
                    int hour = int.Parse(Console.ReadLine());
                    Console.Write("Minute  : ");
                    int minute = int.Parse(Console.ReadLine());
                    Console.Write("Second  : ");
                    int second = int.Parse(Console.ReadLine());

                    RollBack(date, hour, minute, second);
                    Console.WriteLine("Data restored");
                }
            }
        }
        private void OnChanged(object source, FileSystemEventArgs fileArgs)
        {
            DirectoryInfo filesSet = new DirectoryInfo(backeupDirInfo + "\\" + formatProvider.Day + "." + formatProvider.Month + "." + formatProvider.Year + "\\" + formatProvider.Hour + "." + formatProvider.Minute + "." + formatProvider.Second);
            try
            {
                filesSet.Create();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var trackingFiles = dirInfo.GetFiles();

            for (int i = 0; i < trackingFiles.Length; i++)
            {
                trackingFiles[i].CopyTo(filesSet.FullName + "\\" + trackingFiles[i].Name, true);
            }
            Console.WriteLine($"File : {fileArgs.FullPath} {fileArgs.ChangeType}");
        }
        private static void OnOverflow(object source, ErrorEventArgs e)
        {
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
        }
        public void RollBack(string date, int hour, int minute, int second)
        {
            string time = hour.ToString() + "." + minute.ToString() + "." + second.ToString();
            try
            {
                var backDir = backeupDirInfo.GetDirectories();
                for (int i = 0; i < backDir.Length; i++)
                {
                    Console.WriteLine("Check1");
                    if (backDir[i].Name.Equals(date))
                    {
                        Console.WriteLine("Check2");
                        DirectoryInfo filesDate = new DirectoryInfo(backDir[i].FullName);
                        var filesTimeDir = filesDate.GetDirectories();
                        for (int j = 0; j < filesTimeDir.Length; j++)
                        {
                            Console.WriteLine("Check3");
                            if (filesTimeDir[j].Name.Equals(time))
                            {
                                Console.WriteLine("Check4");
                                FileSystem.CopyDirectory(filesTimeDir[i].FullName, dirInfo.FullName, true);
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
            Console.WriteLine("Press any key to exit the programm");
        }
    }
}
