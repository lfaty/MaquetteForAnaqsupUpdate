using Microsoft.AspNetCore.Mvc;
using MaquetteForAnaqsup.API.Services;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using MaquetteForAnaqsup.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
using MaquetteForAnaqsup.API.Models.Domain;


namespace MaquetteForAnaqsup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDatasController : ControllerBase
    {
        private readonly ApplicationsDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAtomeElementConstitutifsService _serviceAtomeParcour;
        private readonly IParcourUniteEnseignementsService _serviceUeParcour;
        private readonly IAtomePedagogiquesService _serviceAtomePedagogique;
        private readonly INatureUEsService _serviceNatureUE;
        private readonly IDebouchesService _serviceDebouche;
        private readonly IDepartementsService _serviceDepartement;
        private readonly IDomainesService _serviceDomaine;
        private readonly IElementConstitutifsService _serviceElementConstitutif;
        private readonly IFacultesService _serviceFalcute;
        private readonly IFormationsService _serviceFormation;
        private readonly IGradesService _serviceGrade;
        private readonly IMentionsService _serviceMention;
        private readonly INiveausService _serviceNiveau;
        private readonly IParcoursService _serviceParcour;
        private readonly ISemestresService _serviceSemestre;
        private readonly ISpecialitesService _serviceSpecialite;
        private readonly IUniteEnseignementsService _serviceUniteEnseignement;
        private readonly IUniversitesService _serviceUniversite;
        private readonly IVillesService _serviceIVille;

        public ImportDatasController(ApplicationsDbContext context,
            IConfiguration configuration,
            IAtomeElementConstitutifsService serviceAtomeParcour,
            INatureUEsService serviceNatureUE,
            IParcourUniteEnseignementsService serviceUeParcour,
            IAtomePedagogiquesService serviceAtomePedagogique,
            IDebouchesService serviceDebouche,
            IDepartementsService serviceDepartement,
            IDomainesService serviceDomaine,
            IElementConstitutifsService serviceElementConstitutif,
            IFacultesService serviceFalcute,
            IFormationsService serviceFormation,
            IGradesService serviceGrade,
            IMentionsService serviceMention,
            INiveausService serviceNiveau,
            IParcoursService serviceParcour,
            ISemestresService serviceSemestre,
            ISpecialitesService serviceSpecialite,
            IUniteEnseignementsService serviceUniteEnseignement,
            IUniversitesService serviceUniversite,
            IVillesService serviceIVille)
        {
            _context = context;
            _configuration = configuration;
            _serviceAtomeParcour = serviceAtomeParcour;
            _serviceNatureUE = serviceNatureUE;
            _serviceUeParcour = serviceUeParcour;
            _serviceAtomePedagogique = serviceAtomePedagogique;
            _serviceDebouche = serviceDebouche;
            _serviceDepartement = serviceDepartement;
            _serviceDomaine = serviceDomaine;
            _serviceElementConstitutif = serviceElementConstitutif;
            _serviceFalcute = serviceFalcute;
            _serviceFormation = serviceFormation;
            _serviceGrade = serviceGrade;
            _serviceMention = serviceMention;
            _serviceNiveau = serviceNiveau;
            _serviceParcour = serviceParcour;
            _serviceSemestre = serviceSemestre;
            _serviceSpecialite = serviceSpecialite;
            _serviceUniteEnseignement = serviceUniteEnseignement;
            _serviceUniversite = serviceUniversite;
            _serviceIVille = serviceIVille;
        }

        [HttpPost]
        [Route("UploadFile")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            try
            {
                var mainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFile");
                if (!Directory.Exists(mainPath))
                {
                    Directory.CreateDirectory(mainPath);
                }
                var filePath = Path.Combine(mainPath, formFile.FileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                var fileName = formFile.FileName;
                string extension = Path.GetExtension(fileName);
                string conString = string.Empty;
                switch (extension)
                {
                    case ".xls":
                        conString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filePath + ";Extended Properties ='Excel 8.0; HDR=Yes'";
                        break;

                    case ".xlsx":
                        conString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + filePath + ";Extended Properties ='Excel 8.0; HDR=Yes'";
                        break;
                }
                System.Data.DataTable dt = new System.Data.DataTable();
                conString = string.Format(conString, filePath);
                using (OleDbConnection conExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = conExcel;
                            conExcel.Open();
                            System.Data.DataTable dtExcelSchema = conExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            conExcel.Close();
                        }
                    }
                }
                conString = _configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        sqlBulkCopy.DestinationTableName = "ImportDatas";
                        sqlBulkCopy.ColumnMappings.Add("ID", "Id");
                        sqlBulkCopy.ColumnMappings.Add("CODE_UNIV", "CodeUniversite");
                        sqlBulkCopy.ColumnMappings.Add("LIB_UNIVERSITE", "LibelleUniversite");
                        sqlBulkCopy.ColumnMappings.Add("FACULTE", "Faculte");
                        sqlBulkCopy.ColumnMappings.Add("DEPARTEMENT", "Departement");
                        sqlBulkCopy.ColumnMappings.Add("CODE_DOM", "CodeDomaine");
                        sqlBulkCopy.ColumnMappings.Add("LIB_DOMAINE", "LibelleDomaine");
                        sqlBulkCopy.ColumnMappings.Add("MENTION", "Mention");
                        sqlBulkCopy.ColumnMappings.Add("SPECIALITE", "Specialite");
                        sqlBulkCopy.ColumnMappings.Add("ABREVIATION", "Abreviation");
                        sqlBulkCopy.ColumnMappings.Add("FORMATION", "LibelleFormation");
                        sqlBulkCopy.ColumnMappings.Add("GRADE", "Grade");
                        sqlBulkCopy.ColumnMappings.Add("SEMESTRE", "Semestre");
                        sqlBulkCopy.ColumnMappings.Add("PARCOURS", "Parcours");
                        sqlBulkCopy.ColumnMappings.Add("NIVEAU", "Niveau");
                        sqlBulkCopy.ColumnMappings.Add("CODE_UE", "CodeUE");
                        sqlBulkCopy.ColumnMappings.Add("LIBELLE_UE", "LibelleUE");
                        sqlBulkCopy.ColumnMappings.Add("NATURE_UE", "NatureUE");
                        sqlBulkCopy.ColumnMappings.Add("CREDIT_UE", "CreditUE");
                        sqlBulkCopy.ColumnMappings.Add("COEF_UE", "CoefUE");
                        sqlBulkCopy.ColumnMappings.Add("CODE_EC", "CodeEC");
                        sqlBulkCopy.ColumnMappings.Add("LIB_LONG_EC", "LibelleLongEC");
                        sqlBulkCopy.ColumnMappings.Add("COEF_EC", "CoefEC");
                        sqlBulkCopy.ColumnMappings.Add("CM", "CM");
                        sqlBulkCopy.ColumnMappings.Add("TD", "TD");
                        sqlBulkCopy.ColumnMappings.Add("TP", "TP");
                        sqlBulkCopy.ColumnMappings.Add("SEM", "SEM");
                        sqlBulkCopy.ColumnMappings.Add("TPE", "TPE");
                        //sqlBulkCopy.ColumnMappings.Add("AP", "AtomePedagogique");
                        //sqlBulkCopy.ColumnMappings.Add("VOLUME_HORAIRE", "VolumeHoraire");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }

                return Ok("File Imported Successfull, Data Saved into Database.");

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Ok();
        }


        ////[HttpGet]
        //[HttpPost]
        //[Route("VentileData")]
        //public async Task<IActionResult> VentileData()
        //{
        //    var maquetteDatas = _context.ImportDatas.ToList();
        //    if (maquetteDatas.Count() <= 0) return null;

        //    string codeUniv = null;

        //    foreach (var item in maquetteDatas)
        //    {
        //        // Add Universite Informations
        //        var lstUniversites = await _serviceUniversite.GetAllAsync();
        //        var universite = lstUniversites.Where(x => x.CodeUniv == item.CodeUniversite).FirstOrDefault();
        //        if (universite != null)
        //        {
        //            codeUniv = item.CodeUniversite;
        //        }
        //        else
        //        {
        //            Universite model = new Universite();
        //            model.CodeUniv = item.CodeUniversite;
        //            model.NomUniversite = item.LibelleUniversite;
        //            codeUniv = item.CodeUniversite;
        //            await _serviceUniversite.AddAsync(model);
        //        }


        //        // Add Faculte Informations
        //        var faculteData = new Faculte();
        //        var lstFacultes = await _serviceFalcute.GetAllAsync(codeUniv);
        //        var faculte = lstFacultes.Where(x => x.LibelleFaculte == item.Faculte).FirstOrDefault();
        //        if (faculte != null) { faculteData = faculte; }
        //        else
        //        {
        //            Faculte model = new Faculte();
        //            model.CodeUniv = codeUniv;
        //            model.LibelleFaculte = item.Faculte;
        //            faculteData = await _serviceFalcute.AddAsync(model);
        //        }


        //        // Add Departement Informations
        //        var departementData = new Departement();
        //        var lstDepartements = await _serviceDepartement.GetAllAsync(codeUniv, f => f.Faculte);
        //        var departement = lstDepartements.Where(x => x.LibelleDepartement == item.Departement).FirstOrDefault();
        //        if (departement != null) { departementData = departement; }
        //        else
        //        {
        //            Departement model = new Departement();
        //            model.CodeUniv = codeUniv;
        //            model.LibelleDepartement = item.Departement;
        //            model.FaculteId = faculteData.Id;
        //            departementData = await _serviceDepartement.AddAsync(model);
        //        }


        //        // Add Domaine Informations
        //        var domaineData = new Domaine();
        //        var lstDomaines = await _serviceDomaine.GetAllAsync(codeUniv);
        //        var domaine = lstDomaines.Where(x => x.CodeDomaine == item.CodeDomaine).FirstOrDefault();
        //        if (domaine != null) { domaineData = domaine; }
        //        else
        //        {
        //            Domaine model = new Domaine();
        //            model.CodeUniv = codeUniv;
        //            model.CodeDomaine = item.CodeDomaine;
        //            model.LibelleDomaine = item.LibelleDomaine;
        //            domaineData = await _serviceDomaine.AddAsync(model);
        //        }


        //        // Add Mention Informations
        //        var mentionData = new Mention();
        //        var lstMentions = await _serviceMention.GetAllAsync(codeUniv, d => d.Domaine);
        //        var mention = lstMentions.Where(x => x.LibelleMention == item.Mention).FirstOrDefault();
        //        if (mention != null) { mentionData = mention; }
        //        else
        //        {
        //            Mention model = new Mention();
        //            model.CodeUniv = codeUniv;
        //            model.LibelleMention = item.Mention;
        //            model.DomaineId = domaineData.Id;
        //            mentionData = await _serviceMention.AddAsync(model);
        //        }


        //        // Add Specialite Informations
        //        var specialiteData = new Specialite();
        //        var lstSpecialites = await _serviceSpecialite.GetAllAsync(codeUniv, m => m.Mention);
        //        var specialite = lstSpecialites.Where(x => x.LibelleSpecialite == item.Specialite).FirstOrDefault();
        //        if (specialite != null) { specialiteData = specialite; }
        //        else
        //        {
        //            Specialite model = new Specialite();
        //            model.CodeUniv = codeUniv;
        //            model.LibelleSpecialite = item.Specialite;
        //            model.MentionId = mentionData.Id;
        //            specialiteData = await _serviceSpecialite.AddAsync(model);
        //        }


        //        // Add Grade Informations
        //        var gradeData = new Grade();
        //        var lstGrades = await _serviceGrade.GetAllAsync();
        //        var grade = lstGrades.Where(x => x.LibelleGrade == item.Grade).FirstOrDefault();
        //        if (grade != null) { gradeData = grade; }
        //        else
        //        {
        //            Grade model = new Grade();
        //            model.CodeUniv = codeUniv;
        //            model.LibelleGrade = item.Grade;
        //            gradeData = await _serviceGrade.AddAsync(model);
        //        }

        //        // Add Niveau Informations
        //        var niveauData = new Niveau();
        //        var lstNiveaus = await _serviceNiveau.GetAllAsync();
        //        var niveau = lstNiveaus.Where(x => x.NumNiveau == item.Niveau).FirstOrDefault();
        //        if (niveau != null) { niveauData = niveau; }
        //        else
        //        {
        //            Niveau model = new Niveau();
        //            model.CodeUniv = codeUniv;
        //            model.NumNiveau = item.Niveau;
        //            niveauData = await _serviceNiveau.AddAsync(model);
        //        }

        //        // Add Semestre Informations
        //        var semestreData = new Semestre();
        //        var lstSemestres = await _serviceSemestre.GetAllAsync();
        //        var semestre = lstSemestres.Where(x => x.NumSemestre == item.Semestre).FirstOrDefault();
        //        if (semestre != null) { semestreData = semestre; }
        //        else
        //        {
        //            Semestre model = new Semestre();
        //            model.CodeUniv = codeUniv;
        //            model.NumSemestre = item.Semestre;
        //            semestreData = await _serviceSemestre.AddAsync(model);
        //        }

        //        // Add AP Informations
        //        //var apData = new AtomePedagogique();
        //        //var lstAps = await _serviceAtomePedagogique.GetAllAsync(codeUniv);
        //        //var ap = lstAps.Where(x => x.LibelleAP == item.AtomePedagogique).FirstOrDefault();
        //        //if (ap != null) { apData = ap; }
        //        //else
        //        //{
        //        //    AtomePedagogique model = new AtomePedagogique();
        //        //    model.CodeUniv = codeUniv;
        //        //    model.LibelleAP = item.AtomePedagogique;
        //        //    apData = await _serviceAtomePedagogique.AddAsync(model);
        //        //}

        //        // Add NatureUE Informations
        //        var natureUEData = new NatureUniteEnseignement();
        //        var lstNatures = await _serviceNatureUE.GetAllAsync();
        //        var nature = lstNatures.Where(x => x.LibelleNature == item.NatureUE).FirstOrDefault();
        //        if (nature != null) { natureUEData = nature; }
        //        else
        //        {
        //            NatureUniteEnseignement model = new NatureUniteEnseignement();
        //            model.CodeUniv = codeUniv;
        //            model.LibelleNature = item.NatureUE;
        //            natureUEData = await _serviceNatureUE.AddAsync(model);
        //        }

        //        // Add UE Informations
        //        var ueData = new UniteEnseignement();
        //        var lstUEs = await _serviceUniteEnseignement.GetAllAsync(codeUniv);
        //        var ue = lstUEs.Where(x => x.LibelleUE == item.LibelleUE).FirstOrDefault();
        //        if (ue != null) { ueData = ue; }
        //        else
        //        {
        //            UniteEnseignement model = new UniteEnseignement();
        //            model.CodeUniv = codeUniv;
        //            model.CodeUE = item.CodeUE;
        //            model.LibelleUE = item.LibelleUE;
        //            model.NatureUniteEnseignementId = natureUEData.Id;
        //            model.CreditUE = item.CreditUE;
        //            model.CoefUE = item.CoefUE;
        //            ueData = await _serviceUniteEnseignement.AddAsync(model);
        //        }

        //        // Add EC Informations
        //        var ecData = new ElementConstitutif();
        //        var lstECs = await _serviceElementConstitutif.GetAllAsync(codeUniv);
        //        var ec = lstECs.Where(x => x.LibelleEC == item.LibelleLongEC).FirstOrDefault();
        //        if (ec != null) { ecData = ec; }
        //        else
        //        {
        //            ElementConstitutif model = new ElementConstitutif();
        //            model.CodeUniv = codeUniv;
        //            model.UniteEnseignementId = ueData.Id;
        //            model.LibelleEC = item.LibelleLongEC;
        //            model.CodeEC = item.CodeEC;
        //            ecData = await _serviceElementConstitutif.AddAsync(model);
        //        }


        //        // Add Formation Informations
        //        var formationData = new Formation();
        //        var lstFormations = await _serviceFormation.GetAllAsync(codeUniv, m => m.Departement);
        //        var formation = lstFormations.Where(x => x.CodeFormation == item.Abreviation).FirstOrDefault();
        //        if (formation != null) { formationData = formation; }
        //        else
        //        {
        //            Formation model = new Formation();
        //            model.CodeUniv = codeUniv;
        //            model.CodeFormation = item.Abreviation;
        //            model.LibelleFormation = item.LibelleFormation;
        //            model.DepartementId = departementData.Id;
        //            model.MentionId = mentionData.Id;
        //            model.SpecialiteId = specialiteData.Id;
        //            model.GradeId = gradeData.Id;

        //            formationData = await _serviceFormation.AddAsync(model);
        //        }


        //        // Add Parcour Informations
        //        var parcourData = new Parcour();
        //        var lstParcours = await _serviceParcour.GetAllAsync(codeUniv, f => f.Formation, n => n.Niveau, s => s.Semestre);
        //        var parcour = lstParcours.Where(x => x.LibelleParcour == item.Parcours).FirstOrDefault();
        //        if (parcour != null) { parcourData = parcour; }
        //        else
        //        {
        //            Parcour model = new Parcour();
        //            model.CodeUniv = codeUniv;
        //            model.FormationId = formationData.Id;
        //            model.NiveauId = niveauData.Id;
        //            model.SemestreId = semestreData.Id;
        //            model.LibelleParcour = item.Parcours;
        //            parcourData = await _serviceParcour.AddAsync(model);
        //        }

        //        // Add UeParcour Informations
        //        var lstUeParcours = await _serviceUeParcour.GetAllAsync(codeUniv, f => f.UniteEnseignement, n => n.Parcour);
        //        var ueParcour = lstUeParcours.Where(x => x.UniteEnseignementId == ueData.Id & x.ParcourId == parcourData.Id).FirstOrDefault();
        //        if (ueParcour != null)
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            ParcourUniteEnseignement apemodel = new ParcourUniteEnseignement();
        //            apemodel.CodeUniv = codeUniv;
        //            apemodel.UniteEnseignementId = ueData.Id;
        //            apemodel.ParcourId = parcourData.Id;
        //            await _serviceUeParcour.AddAsync(apemodel);
        //        }


        //        // Add AtomeParcourEc Informations
        //        //var lstAtomeECs = await _serviceAtomeParcour.GetAllAsync(codeUniv, n => n.ElementConstitutif, s => s.AtomePedagogique);
        //        //var atomeParcour = lstAtomeECs.Where(x => x.ElementConstitutifId == ecData.Id & x.AtomePedagogiqueId == apData.Id).FirstOrDefault();
        //        //if (atomeParcour != null)
        //        //{
        //        //    continue;
        //        //}
        //        //else
        //        //{
        //        //    AtomeElementConstitutif apemodel = new AtomeElementConstitutif();
        //        //    apemodel.CodeUniv = codeUniv;
        //        //    apemodel.ElementConstitutifId = ecData.Id;
        //        //    //apemodel.AtomePedagogiqueId = apData.Id;
        //        //    //apemodel.VolumeHoraire = item.VolumeHoraire;
        //        //    await _serviceAtomeParcour.AddAsync(apemodel);
        //        //}
        //    }

        //    return Ok("Data Insert Success !");
        //}

    }
}
