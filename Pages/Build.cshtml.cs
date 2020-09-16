using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using SGFDevsUI.Classes;

namespace SGFDevsUI.Pages
{
    public class Build : PageModel
    {
        private IHostingEnvironment _hostingEnvironment;
        
        [BindProperty]
        public String BaseURL { get; set; }
        [BindProperty]
        public string SiteSaveLocation { get; set; }
        [BindProperty]
        public String Root { get; set; }
        [BindProperty]
        public string Exclusions { get; set; }

        public string Messages { get; set; }

        public String[] FilesDownloaded { get; set; }

        public Build(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            Exclusions = "_,cshtml.cs,Partials,GenerateStaticSite,Build";
            SiteSaveLocation = _hostingEnvironment.ContentRootPath + Path.DirectorySeparatorChar + "static" + Path.DirectorySeparatorChar;
            Root = _hostingEnvironment.WebRootPath;
        }
        
        public void OnGet()
        {
            
        }
        
        public IActionResult OnPost()
        {
            IList<string> filesDld = new List<String>();

            using (var client = new WebClient())
            {
                //verify locations and build folders
                var status = StaticSiteGeneration.VerifyLocations(new[] { SiteSaveLocation, Root });

                if (!status.Key) return Page();

                if (!StaticSiteGeneration.CopyDirectory(Root, SiteSaveLocation)) return Page();

                var files = StaticSiteGeneration.GetFiles(Exclusions.Split(","));
                
                foreach (var f in files)
                {
                    var file = f.Split("Pages")[1].Replace("/", "").Replace(@"\", "").Replace(".cshtml", "");
                    var url = BaseURL + file + "?horse_build=true";
                    var saveLocationFolder = SiteSaveLocation + file;
                    var saveLocationIndex = saveLocationFolder + "/index.html";

                    try
                    {
                        var save = StaticSiteGeneration.PrepForDownload(SiteSaveLocation, file);
                        client.DownloadFile(url, save);
                        filesDld.Add(file);
                    }
                    catch (Exception ex)
                    {
                        var i = ex;
                    }
                }
            }

            return Page();
        }
    }
}