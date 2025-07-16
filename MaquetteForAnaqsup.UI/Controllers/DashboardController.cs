using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MaquetteForAnaqsup.UI.Models;
using MaquetteForAnaqsup.UI.ApiServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using MaquetteForAnaqsup.UI.Models.DTO;

namespace MaquetteForAnaqsup.UI.Controllers;

public class DashboardController : Controller
{
    private readonly DashboardsApiService _apiServiceDashboard;
    private readonly ILogger<HomeController> _logger;
    //string codeUniv;

    public DashboardController(ILogger<HomeController> logger, DashboardsApiService apiServiceDashboard)
    {
        _logger = logger;
        _apiServiceDashboard = apiServiceDashboard;
        //this.codeUniv = codeUniv;
    }

    [HttpGet]
    public async Task<IActionResult> IndexSearch()
    {
        DashboardDto dashboardDto = new DashboardDto
        {
            Formations = new List<FormationDto>(),
        };
        return View(dashboardDto);
    }

    [HttpPost]
    public async Task<IActionResult> FilterSearch(string? CodeUniv, string? searchString)
    {
        var lstFormations = await _apiServiceDashboard.FilterSearch(CodeUniv, searchString);
        if (lstFormations == null)
        {
            ModelState.AddModelError("CodeUnivA", "Veuillez sélectionner deux universités valides.");
            DashboardDto dashboardDto = new DashboardDto
            {
                Formations = new List<FormationDto>(),
                UniteEnseignements = new List<UniteEnseignementDto>(),
                ElementConstitutifs = new List<ElementConstitutifDto>(),
            };
            return View(dashboardDto);
        }
        return View("IndexSearch", lstFormations);
    }


    //[HttpGet]
    //public async Task<IActionResult> IndexSearchAdvance()
    //{
    //    var selectListUniv = await _apiServiceDashboard.ListeUniversite();
    //    ViewData["CodeUniv"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite");

    //    var lstDatas = await _apiServiceDashboard.GetAllFormation();

    //    return View(lstDatas);
    //}

    //[HttpPost]
    //public async Task<IActionResult> FilterSearchAdvance(string? CodeUniv, Guid FaculteId, Guid DepartementId)
    //{
    //    var selectListUniv = await _apiServiceDashboard.ListeUniversite();
    //    ViewData["CodeUniv"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite", CodeUniv);

    //    var lstDatas = new DashboardDto();

    //    if (CodeUniv != null & FaculteId == Guid.Empty & DepartementId == Guid.Empty)
    //    {
    //        lstDatas = await _apiServiceDashboard.GetAllFormationByUniv(CodeUniv);
    //    }
    //    else if (CodeUniv != null & FaculteId != Guid.Empty & DepartementId == Guid.Empty)
    //    {
    //        lstDatas = await _apiServiceDashboard.GetAllFormationByFac(CodeUniv, FaculteId);
    //    }
    //    else
    //    {
    //        lstDatas = await _apiServiceDashboard.FilterFormation(CodeUniv, FaculteId, DepartementId);
    //    }

    //    return View("Index", lstDatas);

    //}


    //[HttpPost]
    //public async Task<IActionResult> FilterLstFaculte(string cid)
    //{
    //    //codeUniv = cid;
    //    var lstFacultes = await _apiServiceDashboard.FilterFaculteByCodeUniv(cid);
    //    DashboardDto model = new DashboardDto();

    //    model.ListFacultes = lstFacultes.Facultes.ToList();

    //    return Json(model);
    //}


    //[HttpPost]
    //public async Task<IActionResult> FilterLstDepartement(Guid fid)
    //{
    //    string codeUniv = null;
    //    var lstDepts = await _apiServiceDashboard.FilterDeptByCodeUniv(codeUniv);
    //    DashboardDto model = new DashboardDto();

    //    model.ListDepartements = lstDepts.Departements.Where(x => x.FaculteId == fid).ToList();

    //    return Json(model);
    //}


    //[HttpGet]
    //public async Task<IActionResult> IndexBetweenFormInterne()
    //{
    //    var selectListUniv = await _apiServiceDashboard.ListeUniversite();
    //    var CodeUnivA = "";
    //    var CodeUnivB = "";

    //    ViewData["CodeUniv"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite");

    //    var lstFormations = await _apiServiceDashboard.GetAllFormationBeetwenTwoUniv(CodeUnivA, CodeUnivB);
    //    if(lstFormations == null)
    //    {
    //        ModelState.AddModelError("CodeUnivA", "Veuillez sélectionner deux universités valides.");
    //        DashboardDto dashboardDto = new DashboardDto
    //        {
    //            lstFormationUnivA = new List<FormationDto>(),
    //            lstFormationUnivB = new List<FormationDto>()
    //        };
    //        return View(dashboardDto);
    //    }
    //    return View(lstFormations);
    //}

    //[HttpPost]
    //public async Task<IActionResult> FilterBetweenFormInterne(string? CodeUnivA, string? CodeUnivB, List<string> CodeUnivs)
    //{
    //    var selectListUniv = await _apiServiceDashboard.ListeUniversite();

    //    ViewData["CodeUniv"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite");
    //    ViewData["CodeUnivA"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite", CodeUnivA);
    //    ViewData["CodeUnivB"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite", CodeUnivB);

    //    return View(await _apiServiceDashboard.GetAllFormationBeetwenTwoUniv(CodeUnivA, CodeUnivB));
    //}


    //[HttpGet]
    //public async Task<IActionResult> IndexBetweenUniv()
    //{
    //    var selectListUniv = await _apiServiceDashboard.ListeUniversite();

    //    ViewData["CodeUniv"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite");
    //    ViewData["CodeUnivA"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite");
    //    ViewData["CodeUnivB"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite");

    //    string? CodeUnivA = "";
    //    string? CodeUnivB = "";

    //    var lstFormations = await _apiServiceDashboard.GetAllFormationBeetwenTwoUniv(CodeUnivA, CodeUnivB);
    //    if (lstFormations == null)
    //    {
    //        ModelState.AddModelError("CodeUnivA", "Veuillez sélectionner deux universités valides.");
    //        DashboardDto dashboardDto = new DashboardDto
    //        {
    //            lstFormationUnivA = new List<FormationDto>(),
    //            lstFormationUnivB = new List<FormationDto>()
    //        };
    //        return View(dashboardDto);
    //    }
    //    return View(lstFormations);
    //}

    //[HttpPost]
    //public async Task<IActionResult> IndexBetweenUniv(string? CodeUnivA, string? CodeUnivB, List<string> CodeUnivs)
    //{
    //    var selectListUniv = await _apiServiceDashboard.ListeUniversite();

    //    ViewData["CodeUniv"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite");
    //    ViewData["CodeUnivA"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite", CodeUnivA);
    //    ViewData["CodeUnivB"] = new SelectList(selectListUniv.Universites, "CodeUniv", "NomUniversite", CodeUnivB);

    //    return View(await _apiServiceDashboard.GetAllFormationBeetwenTwoUniv(CodeUnivA, CodeUnivB));
    //}


    [HttpGet]
    public async Task<IActionResult> IndexUeParcour()
    {
        return View(await _apiServiceDashboard.GetAllDataCompleted());
    }
}
