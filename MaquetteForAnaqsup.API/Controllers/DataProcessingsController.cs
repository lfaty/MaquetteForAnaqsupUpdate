using AutoMapper;
using MaquetteForAnaqsup.API.Models.DTO;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;
using Newtonsoft.Json.Linq;
using Porter2Stemmer;
using System.Data;
using System.Text.RegularExpressions;

namespace MaquetteForAnaqsup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataProcessingsController : ControllerBase
    {
        private readonly IDatasService _serviceData;
        private readonly IMapper _mapper;

        public DataProcessingsController(IDatasService serviceData, IMapper mapper)
        {
            _serviceData = serviceData;
            _mapper = mapper;
        }

        #region Data Generique
        // GET: api/All
        [HttpGet]
        [Route("GetAllData")]
        public async Task<ActionResult> GetAllData()
        {
            DataDashboardDto model = new DataDashboardDto();
            var allData = await _serviceData.GetAllAsync();
            model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(allData.Take(500).ToList());
            model.LibelleViewData = "Liste des données";

            model.DataUniversites = await _serviceData.GetStatUniversiteAsync();
            model.DataDepartements = await _serviceData.GetStatDepartementAsync();
            model.DataGrades = await _serviceData.GetStatGradeAsync();
            model.DataFormations = await _serviceData.GetStatFormationAsync();
            model.DataNiveaus = await _serviceData.GetStatNiveauAsync();
            model.DataParcours = await _serviceData.GetStatParcourAsync();
            model.DataSemestres = await _serviceData.GetStatSemestreAsync();

            // Get Stemmed Tokens En Communs 
            if (model.ImportDatas.Count() > 0)
            {
                var groups = model.ImportDatas.GroupBy(x => CleanningText(x.LibelleLongEC)).Select(g => new { LibelleLongEC = g.Key, Total = g.Count() });
                // Print results
                //foreach (var item in groups.Where(x => x.Total > 2))
                foreach (var item in groups.Where(x => x.Total > 2))
                {
                    model.StemmedTokens.Add(item.LibelleLongEC);
                    model.FrequencyTokens.Add(item.Total);
                }
            }
            return Ok(model);
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatUniversiteAsync")]
        public async Task<ActionResult> GetStatUniversiteAsync()
        {
            var allData = await _serviceData.GetStatUniversiteAsync();

            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatDepartementAsync")]
        public async Task<ActionResult> GetStatDepartementAsync()
        {
            var allData = await _serviceData.GetStatDepartementAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatGradeAsync")]
        public async Task<ActionResult> GetStatGradeAsync()
        {
            var allData = await _serviceData.GetStatGradeAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatNiveauAsync")]
        public async Task<ActionResult> GetStatNiveauAsync()
        {
            var allData = await _serviceData.GetStatNiveauAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatSemestreAsync")]
        public async Task<ActionResult> GetStatSemestreAsync()
        {
            var allData = await _serviceData.GetStatSemestreAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatFormationAsync")]
        public async Task<ActionResult> GetStatFormationAsync()
        {
            var allData = await _serviceData.GetStatFormationAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatParcourAsync")]
        public async Task<ActionResult> GetStatParcourAsync()
        {
            var allData = await _serviceData.GetStatParcourAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatUniteEnseignementAsync")]
        public async Task<ActionResult> GetStatUniteEnseignementAsync()
        {
            var allData = await _serviceData.GetStatUniteEnseignementAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatElementConstitutifAsync")]
        public async Task<ActionResult> GetStatElementConstitutifAsync()
        {
            var allData = await _serviceData.GetStatElementConstitutifAsync();
            return Ok(allData.Take(500).ToList());
        }

        // GET: api/All
        [HttpGet]
        [Route("GetDropdown")]
        public async Task<ActionResult> GetDropdown()
        {
            DataDashboardDto model = new DataDashboardDto();
            var allData = await _serviceData.GetAllAsync();

            model.DataUniversites = await _serviceData.GetStatUniversiteAsync();
            model.DataDepartements = await _serviceData.GetStatDepartementAsync();
            model.DataGrades = await _serviceData.GetStatGradeAsync();
            model.DataFormations = await _serviceData.GetStatFormationAsync();
            model.DataNiveaus = await _serviceData.GetStatNiveauAsync();
            model.DataParcours = await _serviceData.GetStatParcourAsync();
            model.DataSemestres = await _serviceData.GetStatSemestreAsync();

            return Ok(model);
        }
        #endregion

        #region Data Sciences
        
        // GET: api/All
        [HttpGet]
        [Route("GetAllStatData")]
        public async Task<ActionResult> GetAllStatData()
        {
            var allDataForm = await _serviceData.GetStatFormationAsync();
            var allDataParcour = await _serviceData.GetStatParcourAsync();
            var allDataUE = await _serviceData.GetStatUniteEnseignementAsync();
            var allDataEC = await _serviceData.GetStatElementConstitutifAsync();

            // Affichage des résultats
            DataDashboardDto model = new DataDashboardDto();
            //var allData = ;
            model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(await _serviceData.GetAllAsync());

            model.TotalForms = allDataForm.Count();
            model.TotalParcours = allDataParcour.Count();
            model.TotalUEs = allDataUE.Count();
            model.TotalECs = allDataEC.Count();

            // Get the total Formation by universitie
            if (allDataForm.Count() > 0)
            {
                var groups = allDataForm.GroupBy(x => x.CodeUniversite).Select(g => new { CodeUniversite = g.Key, Total = g.Count() });
                // Print results
                foreach (var item in groups)
                {
                    model.UnivForms.Add(item.CodeUniversite);
                    model.nbreForm.Add(item.Total);
                }
            }

            // Get the total Parcour by universitie
            if (allDataParcour.Count() > 0)
            {
                var groups = allDataParcour.GroupBy(x => x.CodeUniversite).Select(g => new { CodeUniversite = g.Key, Total = g.Count() });
                // Print results
                foreach (var item in groups)
                {
                    model.UnivParcours.Add(item.CodeUniversite);
                    model.nbreParcour.Add(item.Total);
                }
            }

            // Get the total UE by universitie
            if (allDataUE.Count() > 0)
            {
                var groups = allDataUE.GroupBy(x => x.CodeUniversite).Select(g => new { CodeUniversite = g.Key, Total = g.Count() });
                // Print results
                foreach (var item in groups)
                {
                    model.UnivUEs.Add(item.CodeUniversite);
                    model.nbreUE.Add(item.Total);
                }
            }

            // Get the total EC by universitie
            if (allDataEC.Count() > 0)
            {
                var groups =
                    allDataEC.GroupBy(x => x.CodeUniversite).Select(g => new
                    {
                        CodeUniversite = g.Key,
                        Total = g.Count()
                    });
                // Print results
                foreach (var item in groups)
                {
                    model.UnivECs.Add(item.CodeUniversite);
                    model.nbreEC.Add(item.Total);
                }
            }

            return Ok(model);
        }

        // GET: api/All
        [HttpGet]
        [Route("GetFilterData")]
        public async Task<ActionResult> GetFilterData(string? paramCodeUniv, string? paramDept, string? paramGrade, string? paramFormation, int? paramNiveau, int? paramSemestre, string? paramParcour)
        {
            DataDashboardDto model = new DataDashboardDto();

            var allData = await _serviceData.GetFilterDataAsync(paramCodeUniv, paramDept, paramGrade, paramFormation, paramNiveau, paramSemestre, paramParcour);
            model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(allData);

            return Ok(model);
        }

        // GET: api/All
        [HttpGet]
        [Route("GetStatComparaisonData")]
        public async Task<ActionResult> GetStatComparaisonData()
        {
            DataDashboardDto model = new DataDashboardDto();
            var allData = await _serviceData.GetStatComparaisonAsync();
            model.LstDataStatComparaisons = allData.Take(500).ToList();
            return Ok(model);
        }

        // GET: api/All
        [HttpPost]
        [Route("GetStatDataCommune")]
        public async Task<ActionResult> GetStatDataCommune([FromBody] DataParameterDto dataParameter)
        {
            var allData = await _serviceData.GetFormationCommuneAsync(dataParameter);
            if (allData == null) return NotFound();

            DataDashboardDto model = new DataDashboardDto();
            model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(allData);
            model.LibelleViewData = "Données en communs";

            // Get Stemmed Tokens En Communs 
            if (model.ImportDatas.Count() > 0)
            {
                var groups = model.ImportDatas.GroupBy(x => CleanningText(x.LibelleLongEC)).Select(g => new { LibelleLongEC = g.Key, Total = g.Count() });
                // Print results
                //foreach (var item in groups.Where(x => x.Total > 2))
                foreach (var item in groups)
                {
                    model.StemmedTokens.Add(item.LibelleLongEC);
                    model.FrequencyTokens.Add(item.Total);
                }
            }
            return Ok(model);
        }

        // GET: api/All
        [HttpPost]
        [Route("GetStatDataDifferente")]
        public async Task<ActionResult> GetStatDataDifferente([FromBody] DataParameterDto dataParameter)
        {
            var allData = await _serviceData.GetFormationDifferenceAsync(dataParameter);
            if (allData == null) return NotFound();

            DataDashboardDto model = new DataDashboardDto();
            model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(allData);
            model.LibelleViewData = "Données différentes";

            // Get Stemmed Tokens En Communs 
            if (model.ImportDatas.Count() > 0)
            {
                var groups = model.ImportDatas.GroupBy(x => CleanningText(x.LibelleLongEC)).Select(g => new { LibelleLongEC = g.Key, Total = g.Count() });
                // Print results
                //foreach (var item in groups.Where(x => x.Total > 2))
                foreach (var item in groups)
                {
                    model.StemmedTokens.Add(item.LibelleLongEC);
                    model.FrequencyTokens.Add(item.Total);
                }
            }

            return Ok(model);
        }


        // GET: api/All
        [HttpGet]
        [Route("GetAllStatDataSearch")]
        public async Task<ActionResult> GetAllStatDataSearch()
        {
            DataDashboardDto model = new DataDashboardDto();
            var allData = await _serviceData.GetAllAsync();
            model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(allData.Take(500).ToList());
            model.LibelleViewData = "Répartition des EC par Université";

            var allDataEC = await _serviceData.GetStatElementConstitutifAsync();
            model.TotalECs = allDataEC.Count();

            // Get the total EC by universitie
            if (allDataEC.Count() > 0)
            {
                var groups =
                    allDataEC.GroupBy(x => x.CodeUniversite).Select(g => new
                    {
                        CodeUniversite = g.Key,
                        Total = g.Count()
                    });
                // Print results
                foreach (var item in groups)
                {
                    model.UnivECs.Add(item.CodeUniversite);
                    model.nbreEC.Add(item.Total);
                }
            }

            return Ok(model);
        }

        // GET: api/All
        [HttpGet]
        [Route("GetFilterDataSearch")]
        public async Task<ActionResult> GetFilterDataSearch(string? paramLibelleEC)
        {
            DataDashboardDto model = new DataDashboardDto();

            var allData = await _serviceData.GetStatECSearch(paramLibelleEC);
            if (allData == null) return NotFound();
            model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(allData);
            model.LibelleViewData = "Répartition "+ paramLibelleEC + " par Université";

            // Get Stemmed Tokens En Communs 
            if (model.ImportDatas.Count() > 0)
            {
                var groups = model.ImportDatas.GroupBy(x => x.CodeUniversite).Select(g => new { CodeUniversite = g.Key, Total = g.Count() });
                // Print results
                //foreach (var item in groups.Where(x => x.Total > 2))
                foreach (var item in groups)
                {
                    model.UnivECs.Add(item.CodeUniversite);
                    model.nbreEC.Add(item.Total);
                }
            }
            return Ok(model);
        }

        //[HttpGet]
        //[Route("GetStatDataCommune")]
        //public async Task<ActionResult> GetStatDataCommune(List<string>? paramCodeUnivs, string? paramGrade, int? paramNiveau, int? paramSemestre)
        //{
        //    DataDashboardDto model = new DataDashboardDto();

        //    var allData = await _serviceData.GetFormationCommuneAsync(paramCodeUnivs, paramGrade, paramNiveau, paramSemestre);
        //    if (allData == null) return NotFound();

        //    model.ImportDatas = _mapper.Map<IEnumerable<ImportDataDto>>(allData);

        //    // Get Stemmed Tokens En Communs 
        //    if (model.LstDataStatComparaisons.Count() > 0)
        //    {
        //        var groups = model.LstDataStatComparaisons.GroupBy(x => CleanningText(x.LibelleLongEC)).Select(g => new { LibelleLongEC = g.Key, Total = g.Count() });
        //        // Print results
        //        //foreach (var item in groups.Where(x => x.Total > 2))
        //        foreach (var item in groups)
        //        {
        //            model.StemmedTokens.Add(item.LibelleLongEC);
        //            model.FrequencyTokens.Add(item.Total);
        //        }
        //    }
        //    return Ok(model);
        //}

        //// GET: api/All
        //[HttpPost]
        //[Route("GetStatDataDifferente")]
        //public async Task<ActionResult> GetStatDataDifferente(List<string>? paramCodeUnivs, string? paramGrade, int? paramNiveau, int? paramSemestre)
        //{
        //    DataDashboardDto model = new DataDashboardDto();
        //    model.LstDataStatComparaisons = await _serviceData.GetFormationDifferenceAsync(paramCodeUnivs, paramGrade, paramNiveau, paramSemestre);

        //    // Get Stemmed Tokens Differents 
        //    if (model.LstDataStatComparaisons.Count() > 0)
        //    {
        //        var groups = model.LstDataStatComparaisons.GroupBy(x => CleanningText(x.LibelleLongEC)).Select(g => new { LibelleLongEC = g.Key, Total = g.Count() });
        //        // Print results
        //        foreach (var item in groups)
        //        {
        //            model.StemmedTokens.Add(item.LibelleLongEC);
        //            model.FrequencyTokens.Add(item.Total);
        //        }
        //    }

        //    return Ok(model);
        //}

        public static string CleanningText(string texteInput)
        {
            // Remove special characters and digits
            texteInput = Regex.Replace(texteInput, @"[^\w\s]", " ");
            texteInput = Regex.Replace(texteInput, @"\d", " ");
            // Remove extra spaces
            texteInput = Regex.Replace(texteInput, @"\s+", " ").Trim();
            // Convert to lowercase
            texteInput = texteInput.ToLowerInvariant();
            // Remove "et" "des" words
            texteInput = Regex.Replace(texteInput, @"\bet\b|\bdes\b", " ").Trim();
            // Create an MLContext instance
            var mlContext = new MLContext();

            // Step 1: Load data
            var data = mlContext.Data.LoadFromEnumerable(new[] { new TextData { Text = texteInput } });

            // Step 2: Normalize and tokenize text
            var textPipeline = mlContext.Transforms.Text.NormalizeText("NormalizedText", "Text")
                .Append(mlContext.Transforms.Text.TokenizeIntoWords("Tokens", "NormalizedText"))
                .Append(mlContext.Transforms.Text.RemoveDefaultStopWords("FilteredTokens", "Tokens"));

            var textModel = textPipeline.Fit(data);
            var processedData = textModel.Transform(data);

            // Step 3: Custom Stemming (using Porter2Stemmer)
            var stemmer = new EnglishPorter2Stemmer();
            var tokensColumn = processedData.GetColumn<string[]>("FilteredTokens");
            var stemmedTokens = tokensColumn.Select(tokens => tokens.Select(t => stemmer.Stem(t).Value).ToArray()).ToArray();

            var result = "";

            foreach (var item in stemmedTokens)
            {
                result = string.Join(" ", item);
            }

            return result;
        }

        #endregion
    }
}
