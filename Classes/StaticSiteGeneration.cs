using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace SGFDevsUI.Classes
{
    public class StaticSiteGeneration
    {
        public static IList<string> GetFiles(string[] exclusions)
        {
            IEnumerable<string> directory;
            IList<string> normalizedExclusions = new List<string>();

            exclusions.ToList().ForEach(FE => normalizedExclusions.Add(FE.ToLower()));

            try
            {
                directory = Directory.EnumerateFiles("Pages", "*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                // haxors to get the pages directory from the publish folder... gotta be a better way
                Console.WriteLine(e);
                directory = Directory.EnumerateFiles("../../../../Pages", "*", SearchOption.AllDirectories);
            }

            return directory.Where(W => normalizedExclusions.Where(W2 => W.ToLower().Contains(W2)).Count() == 0).ToList();
        }

        public static KeyValuePair<bool, string> VerifyLocations(string[] locations, bool create = true)
        {
            KeyValuePair<bool, string> status = new KeyValuePair<bool, string>(true, string.Empty);

            for (int i = 0; i < locations.Length; i++)
            {
                if (!Directory.Exists(locations[i]))
                {
                    if (create) Directory.CreateDirectory(locations[i]);
                    else
                    {
                        status = new KeyValuePair<bool, string>(false, locations[i] + ": Does not exist and flagged to not create");
                        i = locations.Length;
                    }
                }
            }

            return status;
        }

        public static bool CopyDirectory(string source, string destination)
        {
            var status = true;

            try
            {
                foreach (string dir in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                {
                    var newDir = destination + dir.Substring(source.Length);

                    if (!Directory.Exists(newDir))
                        Directory.CreateDirectory(newDir);
                }

                foreach (string file in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
                {
                    File.Copy(file, destination + file.Substring(source.Length), true);
                }
            }
            catch (Exception ex)
            {
                var i = ex;

                status = false;
            }

            return status;
        }

        public static string PrepForDownload(string siteSaveLocation, string filename)
        {
            var file = string.Empty;

            if (filename.ToLower() != "index")
            {
                var newDir = Path.Combine(siteSaveLocation, filename);

                if (!Directory.Exists(newDir))
                    Directory.CreateDirectory(newDir);

                file = Path.Combine(newDir, "index.html");
            }
            else
                file = siteSaveLocation + filename.ToLower() + ".html";

            return file;
        }
    }
}