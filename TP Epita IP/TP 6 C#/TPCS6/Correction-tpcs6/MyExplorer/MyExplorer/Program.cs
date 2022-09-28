using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("PS1: ");
                string[] entries = Console.ReadLine().Split(' '); //Add error checking for bonus.
                if (entries.Length == 0)
                    Console.Error.WriteLine("Wrong command line");
                if (entries[0] == "ls")
                    MiniLs();
                else if (entries[0] == "cd")
                {
                    if (entries.Length != 2)
                        Console.Error.WriteLine("Wrong command line");
                    MiniCd(entries[1]);
                }
                else if (entries[0] == "cat")
                {
                    if (entries.Length == 2)
                        MiniCat(entries[1]);
                    else if (entries.Length == 3)
                        MiniCat(entries[1], entries[2]);
                    else
                        Console.Error.WriteLine("Wrong command line");
                }
                else if (entries[0] == "get")
                {
                    if (entries.Length == 3)
                        Console.WriteLine(GetValue(entries[1], entries[2]));
                    else if (entries.Length == 4)
                    {
                        int tmp;
                        if (Int32.TryParse(entries[3], out tmp))
                            Console.WriteLine(GetValue(entries[1], entries[2], tmp));
                        else
                            Console.Error.WriteLine("Wrong command line");
                    }
                    else
                        Console.Error.WriteLine("Wrong command line");
                }
                else if (entries[0] == "change")
                {
                    if (entries.Length != 5)
                        Console.Error.WriteLine("Wrong command line");
                    else
                        ChangeValue(entries[1], entries[2], entries[3], entries[4]);
                }
                else
                    Console.Error.WriteLine("Wrong command line");
            }
        }

        static void MiniCat(string InputFile)
        {
            using (StreamReader sr = new StreamReader(InputFile))
            {
                while (!sr.EndOfStream)
                    Console.WriteLine(sr.ReadLine());
            }
        }

        static void MiniCat(string InputFile, string OutputFile)
        {
            using (StreamReader sr = new StreamReader(InputFile))
            {
                using (StreamWriter sw = new StreamWriter(OutputFile))
                {
                    while (!sr.EndOfStream)
                        sw.WriteLine(sr.ReadLine());
                }
            }
        }

        static string GetValue(string InputFile, string key)
        {
            using (StreamReader sr = new StreamReader(InputFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] array = line.Split(':');
                    if (array.Length != 2)
                    {
                        Console.Error.WriteLine("Wrong line");
                        return "";
                    }
                    if (array[0].Trim() == key)
                        return array[1].Trim();
                }
            }
            Console.Error.WriteLine("Key not found");
            return "";
        }

        static void MiniLs()
        {
            string[] ls = Directory.GetFileSystemEntries(Directory.GetCurrentDirectory());
            for (int i = 0; i < ls.Length; i++)
            {
                string[] str = ls[i].Split('/');
                Console.WriteLine(str[str.Length - 1]);
            }
        }

        static void MiniCd(string foldername)
        {
            try
            {
                Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "/" + foldername);
            }
            catch
            {
                Console.Error.WriteLine("{0} doesn't exist or isn't a folder", foldername);
            }
        }

        static string GetValue(string InputFile, string key, int position)
        {
            using (StreamReader sr = new StreamReader(InputFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] array = line.Split(':');
                    if (array[0].Trim() == key)
                    {
                        string[] values = array[1].Split(',');
                        if (position >= values.Length)
                        {
                            Console.Error.WriteLine("Wrong position");
                            return "";
                        }
                        return values[position].Trim();
                    }
                }
            }
            return "Not Found";
        }

        static void ChangeValue(string InputFile, string key, string OldValue, string NewValue)
        {
            using (StreamWriter sw = new StreamWriter("tmpfile.acdc"))
            {
                using (StreamReader sr = new StreamReader(InputFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] array = line.Split(':');
                        string newline = line;
                        if (array[0].Trim() == key)
                        {
                            newline = line.Replace(OldValue, NewValue);
                            if (newline == line)
                                Console.Error.WriteLine("Old Value not found");
                        }
                        sw.WriteLine(newline);
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(InputFile))
            {
                using (StreamReader sr = new StreamReader("tmpfile.acdc"))
                {
                    while (!sr.EndOfStream)
                        sw.WriteLine(sr.ReadLine());
                }
            }
            File.Delete("tmpfile.acdc");
        }
    }
}
