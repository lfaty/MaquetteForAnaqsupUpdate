using AutoMapper;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaquetteForAnaqsup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        //private readonly IConfiguration _configuration;
        //private readonly IAtomeElementConstitutifsService _serviceAtomeEC;
        //private readonly IParcourUniteEnseignementsService _serviceParcourUE;
        //private readonly INatureUEsService _serviceNatureUE;
        //private readonly IAtomePedagogiquesService _serviceAtomePedagogique;
        //private readonly IDebouchesService _serviceDebouche;
        //private readonly IDepartementsService _serviceDepartement;
        //private readonly IDomainesService _serviceDomaine;
        //private readonly IElementConstitutifsService _serviceElementConstitutif;
        //private readonly IFacultesService _serviceFaculte;
        //private readonly IFormationsService _serviceFormation;
        //private readonly IGradesService _serviceGrade;
        //private readonly IMentionsService _serviceMention;
        //private readonly INiveausService _serviceNiveau;
        //private readonly IParcoursService _serviceParcour;
        //private readonly ISemestresService _serviceSemestre;
        //private readonly ISpecialitesService _serviceSpecialite;
        //private readonly IUniteEnseignementsService _serviceUniteEnseignement;
        //private readonly IUniversitesService _serviceUniversite;
        //private readonly IVillesService _serviceIVille;
        //private readonly IMapper _mapper;

        //public DashboardsController(IConfiguration configuration,
        //    IDatasService serviceData,
        //    IAtomeElementConstitutifsService serviceAtomeEC, 
        //    IParcourUniteEnseignementsService serviceParcourUE,
        //    INatureUEsService serviceNatureUE,
        //    IAtomePedagogiquesService serviceAtomePedagogique, 
        //    IDebouchesService serviceDebouche, 
        //    IDepartementsService serviceDepartement, 
        //    IDomainesService serviceDomaine, 
        //    IElementConstitutifsService serviceElementConstitutif,
        //    IFacultesService serviceFaculte, 
        //    IFormationsService serviceFormation, 
        //    IGradesService serviceGrade, 
        //    IMentionsService serviceMention, 
        //    INiveausService serviceNiveau, 
        //    IParcoursService serviceParcour, 
        //    ISemestresService serviceSemestre, 
        //    ISpecialitesService serviceSpecialite, 
        //    IUniteEnseignementsService serviceUniteEnseignement, 
        //    IUniversitesService serviceUniversite, 
        //    IVillesService serviceIVille, 
        //    IMapper mapper)
        //{
        //    _configuration = configuration;
        //    _serviceAtomeEC = serviceAtomeEC;
        //    _serviceParcourUE = serviceParcourUE;
        //    _serviceNatureUE = serviceNatureUE;
        //    _serviceAtomePedagogique = serviceAtomePedagogique;
        //    _serviceDebouche = serviceDebouche;
        //    _serviceDepartement = serviceDepartement;
        //    _serviceDomaine = serviceDomaine;
        //    _serviceElementConstitutif = serviceElementConstitutif;
        //    _serviceFaculte = serviceFaculte;
        //    _serviceFormation = serviceFormation;
        //    _serviceGrade = serviceGrade;
        //    _serviceMention = serviceMention;
        //    _serviceNiveau = serviceNiveau;
        //    _serviceParcour = serviceParcour;
        //    _serviceSemestre = serviceSemestre;
        //    _serviceSpecialite = serviceSpecialite;
        //    _serviceUniteEnseignement = serviceUniteEnseignement;
        //    _serviceUniversite = serviceUniversite;
        //    _serviceIVille = serviceIVille;
        //    _mapper = mapper;
        //}

        //#region Get All Datas Globales

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllUniversite")]
        //public async Task<ActionResult> GetAllUniversite()
        //{
        //    var lstDatas = await _serviceUniversite.GetAllAsync();
        //    return Ok(_mapper.Map<IEnumerable<UniversiteDto>>(lstDatas));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllFaculte")]
        //public async Task<ActionResult> GetAllFaculte(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceFaculte.GetAllAsync(paramCodeUniv);
        //    return Ok(_mapper.Map<IEnumerable<FaculteDto>>(lstDatas));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllDepartement")]
        //public async Task<ActionResult> GetAllDepartement(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceDepartement.GetAllAsync(paramCodeUniv, d => d.Faculte);
        //    return Ok(_mapper.Map<IEnumerable<DepartementDto>>(lstDatas));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllFormation")]
        //public async Task<ActionResult> GetAllFormation(string? paramCodeUniv)
        //{
        //    var lstFormations = await _serviceFormation.GetAllAsync(paramCodeUniv, d => d.Departement, g=>g.Grade);
        //    return Ok(_mapper.Map<IEnumerable<FormationDto>>(lstFormations.Take(count: 5).ToList()));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllParcour")]
        //public async Task<ActionResult> GetAllParcour(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceParcour.GetAllAsync(paramCodeUniv, d => d.Formation);
        //    var filterData = lstDatas.Take(10).ToList();
        //    return Ok(_mapper.Map<IEnumerable<ParcourDto>>(filterData));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllGrade")]
        //public async Task<ActionResult> GetAllGrade(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceGrade.GetAllAsync(paramCodeUniv);
        //    return Ok(_mapper.Map<IEnumerable<GradeDto>>(lstDatas));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllNiveau")]
        //public async Task<ActionResult> GetAllNiveau(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceNiveau.GetAllAsync(paramCodeUniv);
        //    return Ok(_mapper.Map<IEnumerable<NiveauDto>>(lstDatas));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllSemestre")]
        //public async Task<ActionResult> GetAllSemestre(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceSemestre.GetAllAsync(paramCodeUniv);
        //    return Ok(_mapper.Map<IEnumerable<SemestreDto>>(lstDatas));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllUniteEnseignement")]
        //public async Task<ActionResult> GetAllUniteEnseignement(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceUniteEnseignement.GetAllAsync(paramCodeUniv);
        //    var filterData = lstDatas.Take(10).ToList();
        //    return Ok(_mapper.Map<IEnumerable<UniteEnseignementDto>>(filterData));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllElementConstitutif")]
        //public async Task<ActionResult> GetAllElementConstitutif(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceElementConstitutif.GetAllAsync(paramCodeUniv);
        //    var filterData = lstDatas.Take(10).ToList();
        //    return Ok(_mapper.Map<IEnumerable<ElementConstitutifDto>>(filterData));
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllAtomePedagogique")]
        //public async Task<ActionResult> GetAllAtomePedagogique(string? paramCodeUniv)
        //{
        //    var lstDatas = await _serviceAtomePedagogique.GetAllAsync(paramCodeUniv);
        //    return Ok(_mapper.Map<IEnumerable<AtomePedagogiqueDto>>(lstDatas));
        //}

        //#endregion


        //#region Data Processing

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllData")]
        //public async Task<ActionResult> GetAllData()
        //{
        //    var lstUniversites = await _serviceUniversite.GetAllAsync();
        //    var lstFormations = await _serviceFormation.GetAllAsync();
        //    var lstParcours = await _serviceParcour.GetAllAsync();
        //    var lstUniteEnseignements = await _serviceUniteEnseignement.GetAllAsync();
        //    var lstElementConstitutifs = await _serviceElementConstitutif.GetAllAsync();
        //    //var lstFacultes = await _serviceFaculte.GetAllAsync();
        //    //var lstDepartements = await _serviceDepartement.GetAllAsync();
        //    //var lstDomaines = await _serviceDomaine.GetAllAsync();
        //    //var lstMentions = await _serviceMention.GetAllAsync();
        //    //var lstSpecialites = await _serviceSpecialite.GetAllAsync();
        //    //var lstAtomePedagogiques = await _serviceAtomePedagogique.GetAllAsync();
        //    //var lstParcourUEs = await _serviceParcourUE.GetAllAsync();
        //    //var lstAtomeECs = await _serviceAtomeEC.GetAllAsync();

        //    DashboardDto model = new DashboardDto();

        //    // Calculate Totals
        //    model.TotalUnivs = lstUniversites.Count();
        //    model.TotalForms = lstFormations.Count();
        //    model.TotalParcours = lstParcours.Count();
        //    model.TotalUEs = lstUniteEnseignements.Count();
        //    model.TotalECs = lstElementConstitutifs.Count();
        //    //model.TotalFacs = lstFacultes.Count();
        //    //model.TotalDepts = lstDepartements.Count();
        //    //model.TotalDomaines = lstDomaines.Count();
        //    //model.TotalMentions = lstMentions.Count();
        //    //model.TotalSpecialites = lstSpecialites.Count();
        //    //model.TotalAPs = lstAtomePedagogiques.Count();

            
        //    return Ok(model);
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetFilterDataByCodeUniv")]
        //public async Task<ActionResult> GetFilterDataByCodeUniv(string? paramCodeUniv)
        //{
        //    var lstUniversites = await _serviceUniversite.GetAllAsync(paramCodeUniv);
        //    var lstFacultes = await _serviceFaculte.GetAllAsync(paramCodeUniv);
        //    var lstDepartements = await _serviceDepartement.GetAllAsync(paramCodeUniv, d => d.Faculte);
        //    var lstDomaines = await _serviceDomaine.GetAllAsync(paramCodeUniv);
        //    var lstMentions = await _serviceMention.GetAllAsync(paramCodeUniv, d => d.Domaine);
        //    var lstSpecialites = await _serviceSpecialite.GetAllAsync(paramCodeUniv, d => d.Mention);
        //    var lstFormations = await _serviceFormation.GetAllAsync(paramCodeUniv, d => d.Departement);
        //    var lstParcours = await _serviceParcour.GetAllAsync(paramCodeUniv);
        //    var lstUniteEnseignements = await _serviceUniteEnseignement.GetAllAsync(paramCodeUniv);
        //    var lstElementConstitutifs = await _serviceElementConstitutif.GetAllAsync(paramCodeUniv, d => d.UniteEnseignement);
        //    var lstAtomePedagogiques = await _serviceAtomePedagogique.GetAllAsync(paramCodeUniv);
        //    var lstParcourUEs = await _serviceParcourUE.GetAllAsync(paramCodeUniv, d => d.UniteEnseignement, d => d.Parcour);
        //    var lstAtomeECs = await _serviceAtomeEC.GetAllAsync(paramCodeUniv, d => d.AtomePedagogique, d => d.ElementConstitutif);

        //    DashboardDto model = new DashboardDto();
        //    // Calculate Totals
        //    model.TotalUnivs = lstUniversites.Count();
        //    model.TotalFacs = lstFacultes.Count();
        //    model.TotalDepts = lstDepartements.Count();
        //    model.TotalDomaines = lstDomaines.Count();
        //    model.TotalMentions = lstMentions.Count();
        //    model.TotalSpecialites = lstSpecialites.Count();
        //    model.TotalForms = lstFormations.Count();
        //    model.TotalParcours = lstParcours.Count();
        //    model.TotalUEs = lstUniteEnseignements.Count();
        //    model.TotalECs = lstElementConstitutifs.Count();
        //    model.TotalAPs = lstAtomePedagogiques.Count();

        //    //Afficher Data
        //    model.Universites = _mapper.Map<IEnumerable<UniversiteDto>>(lstUniversites);
        //    model.Facultes = _mapper.Map<IEnumerable<FaculteDto>>(lstFacultes);
        //    model.Departements = _mapper.Map<IEnumerable<DepartementDto>>(lstDepartements);
        //    model.Domaines = _mapper.Map<IEnumerable<DomaineDto>>(lstDomaines);
        //    model.Mentions = _mapper.Map<IEnumerable<MentionDto>>(lstMentions);
        //    model.Specialites = _mapper.Map<IEnumerable<SpecialiteDto>>(lstSpecialites);
        //    model.Formations = _mapper.Map<IEnumerable<FormationDto>>(lstFormations);
        //    model.Parcours = _mapper.Map<IEnumerable<ParcourDto>>(lstParcours);
        //    model.UniteEnseignements = _mapper.Map<IEnumerable<UniteEnseignementDto>>(lstUniteEnseignements);
        //    model.ElementConstitutifs = _mapper.Map<IEnumerable<ElementConstitutifDto>>(lstElementConstitutifs);
        //    model.AtomePedagogiques = _mapper.Map<IEnumerable<AtomePedagogiqueDto>>(lstAtomePedagogiques);
        //    model.ParcourUniteEnseignements = _mapper.Map<IEnumerable<ParcourUniteEnseignementDto>>(lstParcourUEs.Take(100).ToList());
        //    model.AtomeElementConstitutifs = _mapper.Map<IEnumerable<AtomeElementConstitutifDto>>(lstAtomeECs.Take(100).ToList());

        //    return Ok(model);
        //}


        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllDataCompleted")]
        //public async Task<ActionResult> GetAllDataCompleted()
        //{
        //    DashboardDto model = new DashboardDto();
        //    var lstAtomeECs = await _serviceAtomeEC.GetAllDataAsync();
        //    model.AtomeElementConstitutifs = _mapper.Map<IEnumerable<AtomeElementConstitutifDto>>(lstAtomeECs);
           
        //    return Ok(model);
        //}

        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllFormationByUniv")]
        //public async Task<ActionResult> GetAllFormationByUniv(string? paramCodeUniv)
        //{
        //    var lstUniversites = await _serviceUniversite.GetAllAsync(paramCodeUniv);
        //    var lstFacultes = await _serviceFaculte.GetAllAsync(paramCodeUniv);
        //    var lstDepartements = await _serviceDepartement.GetAllAsync(paramCodeUniv, d => d.Faculte);
        //    var lstDomaines = await _serviceDomaine.GetAllAsync(paramCodeUniv);
        //    var lstMentions = await _serviceMention.GetAllAsync(paramCodeUniv, d => d.Domaine);
        //    var lstSpecialites = await _serviceSpecialite.GetAllAsync(paramCodeUniv, d => d.Mention);
        //    var lstFormations = await _serviceFormation.GetAllAsync(paramCodeUniv, d => d.Departement);
        //    var lstParcours = await _serviceParcour.GetAllAsync(paramCodeUniv);
        //    var lstUniteEnseignements = await _serviceUniteEnseignement.GetAllAsync(paramCodeUniv);
        //    var lstElementConstitutifs = await _serviceElementConstitutif.GetAllAsync(paramCodeUniv, d => d.UniteEnseignement);
        //    var lstAtomePedagogiques = await _serviceAtomePedagogique.GetAllAsync(paramCodeUniv);
            
        //    DashboardDto model = new DashboardDto();
        //    model.Formations = _mapper.Map<IEnumerable<FormationDto>>(lstFormations);

        //    // Calculate Totals
        //    model.TotalUnivs = lstUniversites.Count();
        //    model.TotalFacs = lstFacultes.Count();
        //    model.TotalDepts = lstDepartements.Count();
        //    model.TotalDomaines = lstDomaines.Count();
        //    model.TotalMentions = lstMentions.Count();
        //    model.TotalSpecialites = lstSpecialites.Count();
        //    model.TotalForms = lstFormations.Count();
        //    model.TotalParcours = lstParcours.Count();
        //    model.TotalUEs = lstUniteEnseignements.Count();
        //    model.TotalECs = lstElementConstitutifs.Count();
        //    model.TotalAPs = lstAtomePedagogiques.Count();

        //    return Ok(model);
        //}

        //[HttpGet]
        //[Route("GetAllFormationByFac")]
        //public async Task<ActionResult> GetAllFormationByFac(string? paramCodeUniv, Guid? paramIdFaculte)
        //{
        //    var lstUniversites = await _serviceUniversite.GetAllAsync(paramCodeUniv);
        //    var lstFacultes = await _serviceFaculte.GetAllAsync(paramCodeUniv);
        //    var lstDepartements = await _serviceDepartement.GetAllAsync(paramCodeUniv, d => d.Faculte);
        //    var lstDomaines = await _serviceDomaine.GetAllAsync(paramCodeUniv);
        //    var lstMentions = await _serviceMention.GetAllAsync(paramCodeUniv, d => d.Domaine);
        //    var lstSpecialites = await _serviceSpecialite.GetAllAsync(paramCodeUniv, d => d.Mention);
        //    var lstFormations = await _serviceFormation.GetAllAsync(paramCodeUniv, d => d.Departement);
        //    var lstParcours = await _serviceParcour.GetAllAsync(paramCodeUniv);
        //    var lstUniteEnseignements = await _serviceUniteEnseignement.GetAllAsync(paramCodeUniv);
        //    var lstElementConstitutifs = await _serviceElementConstitutif.GetAllAsync(paramCodeUniv, d => d.UniteEnseignement);
        //    var lstAtomePedagogiques = await _serviceAtomePedagogique.GetAllAsync(paramCodeUniv);
            
        //    //var lstAtomeParcours = await _serviceAtomeParcour.GetAllAsync(paramCodeUniv, a => a.AtomePedagogique, p => p.Parcour);
        //    //var lstUeParcours = await _serviceUeParcour.GetAllAsync(paramCodeUniv, u => u.UniteEnseignement, p => p.Parcour);

        //    DashboardDto model = new DashboardDto();
        //    model.Formations = _mapper.Map<IEnumerable<FormationDto>>(lstFormations.Where(x => x.Departement.FaculteId == paramIdFaculte));

        //    // Calculate Totals
        //    model.TotalUnivs = lstUniversites.Count();
        //    model.TotalDomaines = lstDomaines.Count();
        //    model.TotalMentions = lstMentions.Count();
        //    model.TotalSpecialites = lstSpecialites.Count();
        //    model.TotalFacs = lstFacultes.Where(x => x.Id == paramIdFaculte).Count();
        //    model.TotalDepts = lstDepartements.Where(x => x.FaculteId == paramIdFaculte).Count();
        //    model.TotalForms = lstFormations.Where(x => x.Departement.FaculteId == paramIdFaculte).Count();
        //    model.TotalParcours = lstParcours.Where(x => x.Formation.Departement.FaculteId == paramIdFaculte).Count();
            
        //    //model.TotalUEs = lstUniteEnseignements.Count(ue => ue.UeParcours.Any(up => up.Parcour.Formation.Departement.FaculteId == paramIdFaculte));
        //    //model.TotalECs = lstElementConstitutifs.Count(x => x.UniteEnseignement.UeParcours.Any(p => p.Parcour.Formation.Departement.FaculteId == paramIdFaculte));
        //    //model.TotalAPs = lstAtomePedagogiques.Count(x => x.AtomeParcours.Any(p => p.Parcour.Formation.Departement.FaculteId == paramIdFaculte));

        //    return Ok(model);
        //}


        //[HttpGet]
        //[Route("FilterFormation")]
        //public async Task<ActionResult> FilterFormation(string? paramCodeUniv, Guid? paramIdFaculte, Guid? paramIdDept)
        //{
        //    var lstUniversites = await _serviceUniversite.GetAllAsync(paramCodeUniv);
        //    var lstFacultes = await _serviceFaculte.GetAllAsync(paramCodeUniv);
        //    var lstDepartements = await _serviceDepartement.GetAllAsync(paramCodeUniv, d => d.Faculte);
        //    var lstDomaines = await _serviceDomaine.GetAllAsync(paramCodeUniv);
        //    var lstMentions = await _serviceMention.GetAllAsync(paramCodeUniv, d => d.Domaine);
        //    var lstSpecialites = await _serviceSpecialite.GetAllAsync(paramCodeUniv, d => d.Mention);
        //    var lstFormations = await _serviceFormation.GetAllAsync(paramCodeUniv, d => d.Departement);
        //    var lstParcours = await _serviceParcour.GetAllAsync(paramCodeUniv);
        //    var lstUniteEnseignements = await _serviceUniteEnseignement.GetAllAsync(paramCodeUniv);
        //    var lstElementConstitutifs = await _serviceElementConstitutif.GetAllAsync(paramCodeUniv, d => d.UniteEnseignement);
        //    var lstAtomePedagogiques = await _serviceAtomePedagogique.GetAllAsync(paramCodeUniv);

        //    //var lstAtomeParcours = await _serviceAtomeParcour.GetAllAsync(paramCodeUniv, a => a.AtomePedagogique, p => p.Parcour);
        //    //var lstUeParcours = await _serviceUeParcour.GetAllAsync(paramCodeUniv, u => u.UniteEnseignement, p => p.Parcour);

        //    DashboardDto model = new DashboardDto();
        //    model.Formations = _mapper.Map<IEnumerable<FormationDto>>(lstFormations.Where(x => x.Departement.FaculteId == paramIdFaculte));

        //    // Calculate Totals
        //    model.TotalUnivs = lstUniversites.Count();
        //    model.TotalDomaines = lstDomaines.Count();
        //    model.TotalMentions = lstMentions.Count();
        //    model.TotalSpecialites = lstSpecialites.Count();
        //    model.TotalFacs = lstFacultes.Where(x => x.Id == paramIdFaculte).Count();
        //    model.TotalDepts = lstDepartements.Where(x => x.FaculteId == paramIdFaculte).Count();
        //    model.TotalForms = lstFormations.Where(x => x.Departement.Id == paramIdDept).Count();
        //    model.TotalParcours = lstParcours.Where(x => x.Formation.DepartementId == paramIdDept).Count();

        //    //model.TotalUEs = lstUniteEnseignements.Count(ue => ue.UeParcours.Any(up => up.Parcour.Formation.DepartementId == paramIdDept));
        //    //model.TotalECs = lstElementConstitutifs.Count(x => x.UniteEnseignement.UeParcours.Any(p => p.Parcour.Formation.Departement.FaculteId == paramIdFaculte));
        //    //model.TotalAPs = lstAtomePedagogiques.Count(x => x.AtomeParcours.Any(p => p.Parcour.Formation.DepartementId == paramIdDept));

        //    return Ok(model);
        //}

        //[HttpGet]
        //[Route("FilterSearch")]
        //public async Task<ActionResult> FilterSearch(string? paramCodeUniv, string? keyword)
        //{
        //    // Recherche filterParam dans Formation, UE, EC
        //    var lstFormations = await _serviceFormation.GetAllAsync(paramCodeUniv, d => d.Departement);
        //    var lstUniteEnseignements = await _serviceUniteEnseignement.GetAllAsync(paramCodeUniv);
        //    var lstElementConstitutifs = await _serviceElementConstitutif.GetAllAsync(paramCodeUniv, d => d.UniteEnseignement);

        //    // Recherche par mot clé dans le nom ou la description
        //    lstFormations = lstFormations.Where(p => p.CodeFormation.Normalize(NormalizationForm.FormD).Contains(keyword.Normalize(NormalizationForm.FormD), StringComparison.OrdinalIgnoreCase) ||
        //                                      p.LibelleFormation.Normalize(NormalizationForm.FormD).Contains(keyword.Normalize(NormalizationForm.FormD), StringComparison.OrdinalIgnoreCase)).ToList();

        //    lstUniteEnseignements = lstUniteEnseignements.Where(p => p.CodeUE.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
        //                                      p.LibelleUE.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        //    lstElementConstitutifs = lstElementConstitutifs.Where(p => p.CodeEC.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
        //                                      p.LibelleEC.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        //    // Affichage des résultats
        //    DashboardDto model = new DashboardDto();
        //    model.Formations = _mapper.Map<IEnumerable<FormationDto>>(lstFormations);
        //    model.UniteEnseignements = _mapper.Map<IEnumerable<UniteEnseignementDto>>(lstUniteEnseignements);
        //    model.ElementConstitutifs = _mapper.Map<IEnumerable<ElementConstitutifDto>>(lstElementConstitutifs);

        //    if (model.Formations.Count() > 0)
        //    {
        //        var groups =
        //            model.Formations.GroupBy(x => x.CodeUniv).Select(g => new
        //            {
        //                CodeUniv = g.Key,
        //                Total = g.Count()
        //            });
        //        // Print results
        //        foreach (var item in groups)
        //        {
        //            model.UnivForms.Add(item.CodeUniv);
        //            model.nbreForm.Add(item.Total);
        //        }
        //    }

        //    if (model.UniteEnseignements.Count() > 0)
        //    {
        //        var groups =
        //            model.UniteEnseignements.GroupBy(x => x.CodeUniv).Select(g => new
        //            {
        //                CodeUniv = g.Key,
        //                Total = g.Count()
        //            });
        //        // Print results
        //        foreach (var item in groups)
        //        {
        //            model.UnivUEs.Add(item.CodeUniv);
        //            model.nbreUE.Add(item.Total);
        //        }
        //    }
        //    if (model.ElementConstitutifs.Count() > 0)
        //    {
        //        var groups =
        //            model.ElementConstitutifs.GroupBy(x => x.CodeUniv).Select(g => new
        //            {
        //                CodeUniv = g.Key,
        //                Total = g.Count()
        //            });
        //        // Print results
        //        foreach (var item in groups)
        //        {
        //            model.UnivECs.Add(item.CodeUniv);
        //            model.nbreEC.Add(item.Total);
        //        }
        //    }

        //    return Ok(model);
        //}


        //// GET: api/All
        ////[HttpGet]
        ////[Route("GetAllFormationEnCommun")]
        ////public async Task<ActionResult> GetAllFormationEnCommun(string? paramCodeUniv, string? paramForm)
        ////{
        ////    paramCodeUniv = "UASZ";
        ////    paramForm = "Economie et Gestion";

        ////    if (string.IsNullOrEmpty(paramCodeUniv1) || string.IsNullOrEmpty(paramCodeUniv2))
        ////    {
        ////        return BadRequest("Les codes des universités ne peuvent pas être vides.");
        ////    }

        ////    DashboardDto model = new DashboardDto();

        ////    var lstFormationA = await _serviceFormation.GetAllAsync(paramCodeUniv, d => d.Departement);
        ////    var lstFormationB = await _serviceFormation.GetAllAsync(paramCodeUniv2, d => d.Departement);

        ////    var selectCodeFormA = lstFormationA.Select(x => x.CodeFormation).ToList();
        ////    var selectCodeFormB = lstFormationB.Select(x => x.CodeFormation).ToList();

        ////    //Recuperer les identitques pour le compte de A
        ////    var queryA = lstFormationA.Where(item => selectCodeFormB.Contains(item.CodeFormation)).ToList();
        ////    model.lstFormationUnivA = _mapper.Map<IEnumerable<FormationDto>>(queryA);

        ////    //Recuperer les identitques pour le compte de B
        ////    var queryB = lstFormationB.Where(item => selectCodeFormA.Contains(item.CodeFormation)).ToList();
        ////    model.lstFormationUnivB = _mapper.Map<IEnumerable<FormationDto>>(queryB);

        ////    //Total des formations en communs
        ////    if (model.lstFormationUnivA.Count() == model.lstFormationUnivB.Count())
        ////    {
        ////        model.TotalEnCommuns = model.lstFormationUnivA.Count();
        ////    }

        ////    return Ok(model);
        ////}


        //// GET: api/All
        //[HttpGet]
        //[Route("GetAllFormationBeetwenTwoUniv")]
        //public async Task<ActionResult> GetAllFormationBeetwenTwoUniv(string? paramCodeUniv1, string? paramCodeUniv2)
        //{
        //    if (string.IsNullOrEmpty(paramCodeUniv1) || string.IsNullOrEmpty(paramCodeUniv2))
        //    {
        //        return BadRequest("Les codes des universités ne peuvent pas être vides.");
        //    }

        //    DashboardDto model = new DashboardDto();

        //    var lstFormationA = await _serviceFormation.GetAllAsync(paramCodeUniv1, d => d.Departement);
        //    var lstFormationB = await _serviceFormation.GetAllAsync(paramCodeUniv2, d => d.Departement);

        //    var selectCodeFormA = lstFormationA.Select(x => x.CodeFormation).ToList();
        //    var selectCodeFormB = lstFormationB.Select(x => x.CodeFormation).ToList();

        //    //Recuperer les identitques pour le compte de A
        //    var queryA = lstFormationA.Where(item => selectCodeFormB.Contains(item.CodeFormation)).ToList();
        //    model.lstFormationUnivA = _mapper.Map<IEnumerable<FormationDto>>(queryA);

        //    //Recuperer les identitques pour le compte de B
        //    var queryB = lstFormationB.Where(item => selectCodeFormA.Contains(item.CodeFormation)).ToList();
        //    model.lstFormationUnivB = _mapper.Map<IEnumerable<FormationDto>>(queryB);

        //    //Total des formations en communs
        //    if (model.lstFormationUnivA.Count() == model.lstFormationUnivB.Count())
        //    {
        //        model.TotalEnCommuns = model.lstFormationUnivA.Count();
        //    }

        //    return Ok(model);
        //}

        //#endregion
    }
}
