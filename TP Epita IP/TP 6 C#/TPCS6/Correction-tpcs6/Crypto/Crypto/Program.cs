using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Rotn("chasseur", 12));
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(Rotn("hruejfkk", -i));
            }
            Console.WriteLine(Rotn("abCz18", 3));
            Console.WriteLine(Rotn("deF ;c41", -3));
            Console.WriteLine(Rotn("ACaC1", 101));
            Console.WriteLine(VigenereEncode("AB xza ,;48ACk", "Un petit post-scriptum pour vouS"));
            Console.WriteLine(VigenereDecode("AB xza ,;48ACk", "Quatoorze ;z"));
            Console.Read();
        }

        static string Rotn(string msg, int n)
        {
            string ret = "";
            for (int i = 0; i < msg.Length; i++)
            {
                int tmp;
                if (char.IsLower(msg[i]))
                {
                    tmp = (msg[i] - 'a' + n) % 26;
                    if (tmp < 0)
                        tmp += 26;
                    tmp += 'a';
                }
                else if (char.IsUpper(msg[i]))
                {
                    tmp = (msg[i] - 'A' + n) % 26;
                    if (tmp < 0)
                        tmp += 26;
                    tmp += 'A';
                }
                else if (char.IsDigit(msg[i]))
                {
                    tmp = (msg[i] - '0' + n) % 10;
                    if (tmp < 0)
                        tmp += 10;
                    tmp += '0';
                }
                else
                    tmp = msg[i];
                ret += (char)tmp;
            }
            return ret;
        }

        static string VigenereEncode(string msg, string key)
        {
            string ret = "";
            int keypos = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (char.IsLetter(msg[i]))
                {
                    int tmp;
                    if (char.IsUpper(msg[i]))
                        tmp = 'A';
                    else
                        tmp = 'a';
                    while (!char.IsLetter(key[keypos % key.Length]))
                        keypos++;
                    int keychar = char.ToUpper(key[keypos++ % key.Length]) - 'A';
                    int x = msg[i] - tmp + keychar;
                    ret += (char)(x % 26 + tmp);
                }
                else
                    ret += msg[i];
            }
            return ret;
        }

        static string VigenereDecode(string msg, string key)
        {
            string ret = "";
            int keypos = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (char.IsLetter(msg[i]))
                {
                    int tmp;
                    if (char.IsUpper(msg[i]))
                        tmp = 'A';
                    else
                        tmp = 'a';
                    while (!char.IsLetter(key[keypos % key.Length]))
                        keypos++;
                    int keychar = char.ToUpper(key[keypos++ % key.Length]) - 'A';
                    int x = (msg[i] - tmp - keychar) % 26;
                    if (x < 0)
                        x += 26;
                    ret += (char)(x + tmp);
                }
                else
                    ret += msg[i];
            }
            return ret;
        }
    }
}
