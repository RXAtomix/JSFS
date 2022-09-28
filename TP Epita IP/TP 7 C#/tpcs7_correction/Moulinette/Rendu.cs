using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Moulinette
{
    class Rendu
    {
        private string folder;
        private List<Exo> listExo;

        public Rendu(string folderName) {
            this.folder = folderName;
            this.listExo = new List<Exo>();
        }

        public bool init() { 
            try{
                DirectoryInfo dInfo = new DirectoryInfo(this.folder);
                DirectoryInfo[] subdirs = dInfo.GetDirectories();

                for (int i = 0; i < subdirs.Length; ++i) {
                    if (Directory.Exists(folder + "/" + subdirs[i].Name)){
                        Exo exo = new Exo(folder + "/" + subdirs[i].Name);
                        listExo.Add(exo);
                    }
                }
            }
            catch{
                return false;
            }

            return listExo.Count > 0;
        }

        private Exo searchExo(string name) {
            for (int i = 0; i < listExo.Count; ++i) {
                if (listExo[i].getName() == name)
                    return listExo[i];
            }
            return null;
        }

        public int runCorrection(List<Correction> listCorrection) {
            int success = 0;
            for (int i = 0; i < listCorrection.Count; ++i){
                Exo exo = searchExo(listCorrection[i].getName());
                if (exo != null){
                    if (exo.execute()){
                        if (exo.getStdout() == listCorrection[i].getStdout() && exo.getStderr() == listCorrection[i].getStderr()){
                            Console.WriteLine(listCorrection[i].getName() + ": OK");
                            ++success;
                        }
                        else
                            Console.WriteLine(listCorrection[i].getName() + ": FAIL");
                    }
                    else {
                        Console.WriteLine(listCorrection[i].getName() + ": error execute()!");
                    }
                }
                else {
                    Console.WriteLine(listCorrection[i].getName() + ": not found!");
                }
            }
            return success;
        }

        public string getFolder() {
            return this.folder;
        }
    }
}
