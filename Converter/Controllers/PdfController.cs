using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Converter.Controllers
{
    public class PdfController : Controller
    {
       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }       

        [HttpPost]
        public FileResult HtmltoPDF()
        {
           
            string fileName = HttpContext.Request.Form["fileName"];
            string url = HttpContext.Request.Form["pageUrl"];
            string page_sizeX = HttpContext.Request.Form["sizeX"];
            string page_sizeY = HttpContext.Request.Form["sizeY"];
            string page_format = HttpContext.Request.Form["pageFormat"];
            string page_orientation = HttpContext.Request.Form["pageOrientation"];
            string script = "printpdf.js";
            string cmd = ("phantomjs.exe " + script);            
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "phantomjs.exe";
            process.StartInfo.WorkingDirectory = @"E:\eVeliko\Work\Project_PDF_Converter\PDF_PhantomJS\Converter\Converter\bin\Debug\netcoreapp1.1";            
            process.StartInfo.Arguments = string.Format("{0} {1} {2} {3} {4} {5} {6} ", script, url, fileName, page_sizeX, page_sizeY, page_format, page_orientation);
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
            var result = process.ExitCode;
            var path = string.Format(@"E:\eVeliko\Work\Project_PDF_Converter\PDF_PhantomJS\Converter\Converter\bin\Debug\netcoreapp1.1\{0}", fileName);
            return PhysicalFile(path, "application/pdf");          
           
        }        

    }
}