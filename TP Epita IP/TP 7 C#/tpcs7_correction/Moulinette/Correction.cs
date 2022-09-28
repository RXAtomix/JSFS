using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Moulinette
{
    class Correction
    {
        private string name;
        private string folder;
        private string stdout;
        private string stderr;

        public Correction(string folderName) {
            this.name = new DirectoryInfo(folderName).Name;     //get last folder name
            this.folder = folderName;
        }

        public bool init() {
            try
            {
                StreamReader stdoutFile = new StreamReader(folder + "/stdout.txt");
                StreamReader stderrFile = new StreamReader(folder + "/stderr.txt");

                this.stdout = stdoutFile.ReadToEnd();
                this.stderr = stderrFile.ReadToEnd();
                this.stdout = this.stdout.Replace("\r\n", "\n");
                this.stderr = this.stderr.Replace("\r\n", "\n");
                stdoutFile.Close();
                stderrFile.Close();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public string getName() {
            return this.name;
        }

        public string getStdout() {
            return this.stdout;
        }

        public string getStderr() {
            return this.stderr;
        }
    }
}
