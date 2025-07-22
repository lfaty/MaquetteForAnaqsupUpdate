using MaquetteForAnaqsup.UI.ApiServices;
using MaquetteForAnaqsup.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using NuGet.Common;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;

namespace MaquetteForAnaqsup.UI.Controllers
{
    public class DataDashboardsController : Controller
    {
        private readonly DataDashboardsApiService _apiServiceDataProcessing;

        public DataDashboardsController(DataDashboardsApiService apiServiceDataProcessing)
        {
            _apiServiceDataProcessing = apiServiceDataProcessing;
        }

        public async Task<IActionResult> Index()
        {
            var viewData = await _apiServiceDataProcessing.GetDropdownStatData();

            ViewData["CodeUniversite"] = new SelectList(viewData.DataUniversites, "CodeUniversite", "LibelleUniversite");
            //ViewData["Departement"] = new SelectList(viewData.DataDepartements, "Departement", "Departement");
            ViewData["Grade"] = new SelectList(viewData.DataGrades, "Grade", "Grade");
            ViewData["Niveau"] = new SelectList(viewData.DataNiveaus, "Niveau", "Niveau");
            ViewData["Semestre"] = new SelectList(viewData.DataSemestres, "Semestre", "Semestre");
            //ViewData["Abreviation"] = new SelectList(viewData.DataNiveaus, "Abreviation", "LibelleFormation");
            //ViewData["LibelleParcour"] = new SelectList(viewData.DataNiveaus, "LibelleParcour", "LibelleParcour");
            
            return View(await _apiServiceDataProcessing.GetAllData());
        }

        public async Task<IActionResult> GetStatComparaisonData()
        {
            var viewData = await _apiServiceDataProcessing.GetDropdownStatData();
            ViewData["CodeUniversite"] = new SelectList(viewData.DataUniversites, "CodeUniversite", "LibelleUniversite");
            ViewData["Grade"] = new SelectList(viewData.DataGrades, "Grade", "Grade");
            ViewData["Niveau"] = new SelectList(viewData.DataNiveaus, "Niveau", "Niveau");
            ViewData["Semestre"] = new SelectList(viewData.DataSemestres, "Semestre", "Semestre");

            //return View(await _apiServiceDataProcessing.GetStatComparaisonData());
            return View(await _apiServiceDataProcessing.GetAllData());
        }

        [HttpPost]
        public async Task<IActionResult> FilterParametre(string submitButton, List<string>? codeUnivs, string? grade, int? niveau, int? semestre)
        {
            if (codeUnivs == null || codeUnivs.Count == 0)
            {
                codeUnivs = null;
            }
            if (grade == null || grade.Contains("Grade"))
            {
                grade = null;
            }
            if (niveau == null || niveau == 0)
            {
                niveau = 0;
            }
            if (semestre == null || semestre == 0)
            {
                semestre = 0;
            }
            DataParameterDto dataParameter = new DataParameterDto
            {
                CodeUnivs = codeUnivs,
                Grade = grade,
                Niveau = niveau ?? 0,
                Semestre = semestre ?? 0
            };
            var viewData = await _apiServiceDataProcessing.GetDropdownStatData();
            ViewData["CodeUniversite"] = new SelectList(viewData.DataUniversites, "CodeUniversite", "LibelleUniversite", codeUnivs);
            ViewData["Grade"] = new SelectList(viewData.DataGrades, "Grade", "Grade", grade);
            ViewData["Niveau"] = new SelectList(viewData.DataNiveaus, "Niveau", "Niveau", niveau);
            ViewData["Semestre"] = new SelectList(viewData.DataSemestres, "Semestre", "Semestre", semestre);

            switch (submitButton)
            {
                case "Commun":
                    return View("GetStatComparaisonData", await _apiServiceDataProcessing.GetStatDataCommune(dataParameter));
                case "Different":
                    return View("GetStatComparaisonData", await _apiServiceDataProcessing.GetStatDataDifferente(dataParameter));
                default:
                    return View(await _apiServiceDataProcessing.GetAllData());
            }
        }


        public async Task<IActionResult> IndexSearch()
        {
            return View(await _apiServiceDataProcessing.GetAllStatDataSearch());
        }

        [HttpPost]
        public async Task<IActionResult> FilterByKeyWord(string? searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                ModelState.AddModelError("searchString", "La recherche est vide.");
                return View(await _apiServiceDataProcessing.GetAllStatDataSearch());
            }
            if (searchString?.Length < 3)
            {
                ModelState.AddModelError("searchString", "La recherche doit contenir au moins 3 caractères.");
                return View(await _apiServiceDataProcessing.GetAllStatDataSearch());
            }
            
            return View("IndexSearch", await _apiServiceDataProcessing.GetFilterDataSearch(searchString));
        }

        //public async Task<IActionResult> IndexFormationDifference()
        //{
        //    var viewData = await _apiServiceDataProcessing.GetDropdownStatData();

        //    ViewData["CodeUniversite"] = new SelectList(viewData.DataUniversites, "CodeUniversite", "LibelleUniversite");
        //    ViewData["Grade"] = new SelectList(viewData.DataGrades, "Grade", "Grade");
        //    ViewData["Niveau"] = new SelectList(viewData.DataNiveaus, "Niveau", "Niveau");
        //    ViewData["Semestre"] = new SelectList(viewData.DataSemestres, "Semestre", "Semestre");

        //    return View(await _apiServiceDataProcessing.GetAllData());
        //}




        public async Task<IActionResult> IndexBetweenFormInterne()
        {
            return View(await _apiServiceDataProcessing.GetAllData());
        }

        [HttpPost]
        public async Task<IActionResult> FilterSearch(string? codeUniv, string? dept, string? grade, string? formation, int? niveau, int? semestre, string? parcour)
        {
            var lstDatas = await _apiServiceDataProcessing.GetFilterInterneDeptData(codeUniv, dept, grade, formation, niveau, semestre, parcour);

            DataDashboardDto model = new DataDashboardDto();

            var viewData = await _apiServiceDataProcessing.GetDropdownStatData();
            ViewData["CodeUniversite"] = new SelectList(viewData.DataUniversites, "CodeUniversite", "LibelleUniversite", codeUniv);
            ViewData["dept"] = new SelectList(model.ListDepartements, "Departement", "Departement", dept);

            return View("Index", lstDatas);
        }


        [HttpPost]
        public async Task<IActionResult> FilterLstDept(string cid)
        {
            //codeUniv = cid;
            var lstDepartements = await _apiServiceDataProcessing.GetDropdownStatData();
            DataDashboardDto model = new DataDashboardDto();

            model.ListDepartements = lstDepartements.DataDepartements.Where(x => x.CodeUniversite == cid).ToList();

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterLstForm(string did, string cid)
        {
            //codeUniv = cid;
            var lstDepartements = await _apiServiceDataProcessing.GetDropdownStatData();
            DataDashboardDto model = new DataDashboardDto();

            model.ListFormations = lstDepartements.DataFormations.Where(x => x.Departement == did & x.CodeUniversite == cid).ToList();

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterLstGrade(string gid, string did, string cid)
        {
            //codeUniv = cid;
            var lstDepartements = await _apiServiceDataProcessing.GetDropdownStatData();
            DataDashboardDto model = new DataDashboardDto();
            if(gid.Contains("Selectionner "))
            {
                model.ListFormations = lstDepartements.DataFormations.Where(x => x.Departement == did & x.CodeUniversite == cid).ToList();
            }
            model.ListFormations = lstDepartements.DataFormations.Where(x => x.Grade == gid & x.Departement == did & x.CodeUniversite == cid).ToList();

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterLstNiveau(int nid, string fid, string gid, string did, string cid)
        {
            //codeUniv = cid;
            var lstDepartements = await _apiServiceDataProcessing.GetDropdownStatData();
            DataDashboardDto model = new DataDashboardDto();
            if (gid.Contains("Selectionner "))
            {
                model.ListParcours = lstDepartements.DataParcours.Where(x => x.Grade == gid & x.Departement == did & x.CodeUniversite == cid).ToList();
            }
            model.ListParcours = lstDepartements.DataParcours.Where(x => x.Niveau == nid & x.Abreviation == fid & x.Grade == gid & x.Departement == did & x.CodeUniversite == cid).ToList();

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterLstParcour(int nid, string fid, string gid, string did, string cid)
        {
            //codeUniv = cid;
            var lstDepartements = await _apiServiceDataProcessing.GetDropdownStatData();
            DataDashboardDto model = new DataDashboardDto();
            if (gid.Contains("Selectionner "))
            {
                model.ListParcours = lstDepartements.DataParcours.Where(x => x.Grade == gid & x.Departement == did & x.CodeUniversite == cid).ToList();
            }
            model.ListParcours = lstDepartements.DataParcours.Where(x => x.Niveau == nid & x.Abreviation == fid & x.Grade == gid & x.Departement == did & x.CodeUniversite == cid).ToList();

            return Json(model);
        }
    }
}
