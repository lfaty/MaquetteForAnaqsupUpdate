using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MaquetteForAnaqsup.UI.Models;
using MaquetteForAnaqsup.UI.ApiServices;

namespace MaquetteForAnaqsup.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataDashboardsApiService _apiServiceDataProcessing;

    public HomeController(ILogger<HomeController> logger, DataDashboardsApiService apiServiceDataProcessing)
    {
        _logger = logger;
        _apiServiceDataProcessing = apiServiceDataProcessing;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _apiServiceDataProcessing.GetAllStatData());
    }

    public async Task<IActionResult> GetAllFormation()
    {
        return View(await _apiServiceDataProcessing.GetStatFormation());
    }

    public async Task<IActionResult> GetAllParcour()
    {
        return View(await _apiServiceDataProcessing.GetStatParcour());
    }

    public async Task<IActionResult> GetAllUniteEnseignement()
    {
        return View(await _apiServiceDataProcessing.GetStatUniteEnseignement());
    }

    public async Task<IActionResult> GetAllElementConstitutif()
    {
        return View(await _apiServiceDataProcessing.GetStatElementConstitutif());
    }
}
