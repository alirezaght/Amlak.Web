using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quantum.Amlak.Web.Models;

namespace Quantum.Amlak.Web.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetRentFiles(string skip = "")
        {
            using (var dbc = new AmlakMainEntities())
            {
                var files = dbc.GetRentApartments("1391/01/01", "1391/05/05");
                return PartialView("Files", files);
            }
        }

        [HttpGet]
        public ActionResult GetFile(string fileName)
        {
            var fullFilePath = Path.Combine(Helper.AmlakFilesFolderPath, fileName);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentType = "text/csv";
            using (var fileStream = System.IO.File.OpenRead(fullFilePath))
            using (var streamReader = new StreamReader(fileStream))
            {
                const int bufferSize = 1 << 10;
                var buffer = new char[bufferSize];
                var count = streamReader.Read(buffer, 0, bufferSize);
                Response.Write(buffer, 0, count);
            }
            Response.End();

            // Not sure what else to do here
            return Content(String.Empty);
        }

    }
}