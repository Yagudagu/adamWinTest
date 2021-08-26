using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Net50WindowsDeploymentTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public string GetLoggingDirectory()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Fabrikam"))
            {
                var path = "LoggingDirectoryPath";
                if (key?.GetValue(path)
                    is string configuredPath)
                {
                    return configuredPath;
                }
            }

            var exePath = Process.GetCurrentProcess().MainModule.FileName;
            var folder = Path.GetDirectoryName(exePath);
            return Path.Combine(folder, "Logging");
        }

        public string SomethingWithFastReport()
        {
            FastReport.Code.CSharp.CSharpCodeProvider cSharpCodeProvider = new();
            return cSharpCodeProvider.ToString();
        }
    }
}
