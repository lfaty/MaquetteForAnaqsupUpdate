using Azure.Core;
using MaquetteForAnaqsup.API.Data;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;

namespace MaquetteForAnaqsup.API.Services
{
    public class UploadFilesService : IUploadFilesService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationsDbContext _context;
        private readonly IConfiguration _configuration;

        public UploadFilesService(IWebHostEnvironment env, 
            IHttpContextAccessor httpContextAccessor,
            ApplicationsDbContext context,
            IConfiguration configuration)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _configuration = configuration;
        }

        public async Task Upload(IFormFile formFile)
        {
            var extension = Path.GetExtension(formFile.FileName).Trim();

            var localFilePath = Path.Combine(_env.ContentRootPath, "UploadFile", $"{formFile.FileName}");

            // Upload Image to Local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);

            await formFile.CopyToAsync(stream);

            var filePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/UploadFile/{formFile.FileName}";

            var fileName = formFile.FileName;
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
                    sqlBulkCopy.ColumnMappings.Add("CODE_UNIV", "CodeUniversite");
                    sqlBulkCopy.ColumnMappings.Add("CODE_UNIVERSITE", "LibelleUniversite");
                    sqlBulkCopy.ColumnMappings.Add("FACULTE", "Faculte");
                    sqlBulkCopy.ColumnMappings.Add("DEPARTEMENT", "Departement");
                    sqlBulkCopy.ColumnMappings.Add("CODE_DOMAINE", "CodeDomaine");
                    sqlBulkCopy.ColumnMappings.Add("LIBELLE_DOMAINE", "LibelleDomaine");
                    sqlBulkCopy.ColumnMappings.Add("MENTION", "Mention");
                    sqlBulkCopy.ColumnMappings.Add("SPECIALITE", "Specialite");
                    sqlBulkCopy.ColumnMappings.Add("ABREVIATION", "Abreviation");
                    sqlBulkCopy.ColumnMappings.Add("GRADE", "Grade");
                    sqlBulkCopy.ColumnMappings.Add("SEMESTRE", "Semestre");
                    sqlBulkCopy.ColumnMappings.Add("PARCOURS", "Parcours");
                    sqlBulkCopy.ColumnMappings.Add("NIVEAU", "Niveau");
                    sqlBulkCopy.ColumnMappings.Add("CODE_UE", "CodeUE");
                    sqlBulkCopy.ColumnMappings.Add("LIBELLE_UE", "LibelleUE");
                    sqlBulkCopy.ColumnMappings.Add("CREDIT_UE", "CreditUE");
                    sqlBulkCopy.ColumnMappings.Add("COEF_UE", "CoefUE");
                    sqlBulkCopy.ColumnMappings.Add("CODE_EC", "CodeEC");
                    sqlBulkCopy.ColumnMappings.Add("LIBELLE_LONG_EC", "LibelleLongEC");
                    sqlBulkCopy.ColumnMappings.Add("COEF_EC", "CoefEC");
                    sqlBulkCopy.ColumnMappings.Add("AP", "AtomePedagogique");
                    sqlBulkCopy.ColumnMappings.Add("VOLUME_HORAIRE", "VolumeHoraire");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
        }
    }
}
