using Microsoft.AspNetCore.Mvc;
using NotesMVC.Models;
using System.Diagnostics;

namespace NotesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private NotesMVCContext context = new NotesMVCContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateNote()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult AddNoteToDb(Note note)
        {
            note.Timestamp = DateTime.Now;
            context.Notes.Add(note);
            context.SaveChanges();
            return RedirectToAction("GetNotes");
        }

        public IActionResult GetNotes()
        {
            return View(context.Notes.ToList());
        }
    }
}

//Scaffold-DbContext 'Data Source=TROYSPC;Initial Catalog=NotesMVC; Integrated Security=SSPI;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
