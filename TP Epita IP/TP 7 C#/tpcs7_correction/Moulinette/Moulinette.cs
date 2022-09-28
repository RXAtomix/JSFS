using System;
using System.Collections.Generic;

using System.IO;

namespace Moulinette
{
    class Moulinette
    {
        List<Correction> listCorrection;
        List<Rendu> listRendu;

        public Moulinette()
        {
            listCorrection = new List<Correction>();
            listRendu = new List<Rendu>();
        }

        public bool init()
        {
            try
            {
                Console.WriteLine("#---#");
                DirectoryInfo dInfo = new DirectoryInfo("correction");
                DirectoryInfo[] subdirs = dInfo.GetDirectories();

                for (int i = 0; i < subdirs.Length; ++i)
                {
                    Correction correction = new Correction("correction/" + subdirs[i].Name);
                    if (correction.init())
                    {
                        listCorrection.Add(correction);
                    }
                }
                Console.WriteLine(listCorrection.Count + " correction found!");

                dInfo = new DirectoryInfo("rendu");
                subdirs = dInfo.GetDirectories();
                for (int i = 0; i < subdirs.Length; ++i)
                {
                    Rendu rendu = new Rendu("rendu/" + subdirs[i].Name);
                    if (rendu.init())
                        listRendu.Add(rendu);
                }
                Console.WriteLine(listRendu.Count + " rendu found!");
            }
            catch
            {
                return false;
            }
            return listCorrection.Count > 0 && listRendu.Count > 0;
        }

        public void execute()
        {
            for (int i = 0; i < listRendu.Count; ++i)
            {
                Console.WriteLine("#---#");
                Console.WriteLine(listRendu[i].getFolder());
                int success = listRendu[i].runCorrection(listCorrection);
                int pourcentage = (success * 100) / listCorrection.Count;
                Console.WriteLine("Grade: " + pourcentage.ToString() + "% (" + success + "/" + listCorrection.Count + ")");
            }
        }
    }
}
