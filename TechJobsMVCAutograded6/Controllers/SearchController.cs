using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        return View();
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
    //POST:
   
    public IActionResult Results(string searchType, string searchTerm)
    {
        List<Job> jobs;
        if(searchTerm == "all"|| searchTerm == "" || searchTerm == null)
        {
            jobs = JobData.FindAll();
            ViewBag.title = "All Jobs";
        }
        else
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.title = $"{searchTerm}";
        }
        ViewBag.columns = ListController.ColumnChoices;
        ViewBag.jobs = jobs;
        return View("Index");
    }
}

