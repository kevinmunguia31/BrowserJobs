using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
/* using MvcBrowserJobs.Models; */

namespace MvcBrowserJobs.Controllers;

public class JobsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}