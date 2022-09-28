using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.IO;


namespace Moulinette
{
    class Exo
    {
        private string name;
        private string folder;
        private string stdout;
        private string stderr;

        public Exo(string folderName) {
            this.name = new DirectoryInfo(folderName).Name;
            this.folder = folderName;
        }

        public bool execute() {
            ProcessStartInfo pStart = new ProcessStartInfo();

            pStart.FileName = this.folder + "/exo.exe" ;
            pStart.UseShellExecute = false;
            pStart.RedirectStandardOutput = true;
            pStart.RedirectStandardError = true;

            try{
                Process p = Process.Start(pStart);
                this.stdout = p.StandardOutput.ReadToEnd();
                this.stdout = this.stdout.Replace("\r\n", "\n");
                this.stderr = p.StandardError.ReadToEnd();
                this.stderr = this.stderr.Replace("\r\n", "\n");
            }
            catch (System.Exception) {
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
