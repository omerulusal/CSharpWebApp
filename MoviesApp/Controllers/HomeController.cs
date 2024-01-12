using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using System.Diagnostics;

namespace MoviesApp.Controllers;

public class HomeController : Controller
{
    public string Index()
    {
        return "Anasayfa";
    }
    public string About()
    {
        return "Hakkýmýzda";
    }
}
