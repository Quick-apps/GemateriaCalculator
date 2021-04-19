﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GemateriaAssignment.FindMatches
{
    public class GemateriaFromTorahCalculator
    {
       
        public IEnumerable<string> GetAllGematrios(int sum)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\torah";
            
            WriteResourceToFile("GemateriaAssignment.TorahText.Torah.numbers.txt", filePath + "\\numbers.txt");
            WriteResourceToFile("GemateriaAssignment.TorahText.Torah.hebrew.txt", filePath + "\\hebrew.txt");

            FindGemateriaMatches gemateriaMatches = new FindGemateriaMatches();

            IEnumerable<string> matches = gemateriaMatches.GetAllInctancesOfGemateriaInFile(filePath, sum);

            return matches;
            
        }

        private void WriteResourceToFile(string resourceName, string filePath)
        {
           
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
        }
    }
}
