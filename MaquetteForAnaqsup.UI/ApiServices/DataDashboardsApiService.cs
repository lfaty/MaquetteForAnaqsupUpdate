using MaquetteForAnaqsup.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MaquetteForAnaqsup.UI.ApiServices
{
    public class DataDashboardsApiService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DataDashboardsApiService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<DataDashboardDto> GetAllData()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetAllData");
            if (!response.IsSuccessStatusCode) { return null; }

            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }
        public async Task<IEnumerable<DataUniversiteDto>> GetStatUniversite()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatUniversiteAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataUniversiteDto>>();
        }
        public async Task<IEnumerable<DataDepartementDto>> GetStatDepartement()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatDepartementAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataDepartementDto>>();
        }
        public async Task<IEnumerable<DataGradeDto>> GetStatGrade()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatGradeAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataGradeDto>>();
        }
        public async Task<IEnumerable<DataNiveauDto>> GetStatNiveau()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatNiveauAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataNiveauDto>>();
        }
        public async Task<IEnumerable<DataSemestreDto>> GetStatSemestre()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatSemestreAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataSemestreDto>>();
        }
        public async Task<IEnumerable<DataFormationDto>> GetStatFormation()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatFormationAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataFormationDto>>();
        }
        public async Task<IEnumerable<DataParcourDto>> GetStatParcour()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatParcourAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataParcourDto>>();
        }
        public async Task<IEnumerable<DataUniteEnseignementDto>> GetStatUniteEnseignement()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatUniteEnseignementAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataUniteEnseignementDto>>();
        }
        public async Task<IEnumerable<DataElementConstitutifDto>> GetStatElementConstitutif()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatElementConstitutifAsync");
            if (!response.IsSuccessStatusCode) { return null; }

            return await response.Content.ReadFromJsonAsync<IEnumerable<DataElementConstitutifDto>>();
        }
        public async Task<DataDashboardDto> GetAllStatData()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetAllStatData");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetStatParCodeUniv()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatParCodeUniv");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetDropdownStatData()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetDropdown");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetFilterInterneDeptData(string? codeUniv, string? dept, string? grade, string? formation, int? niveau, int? semestre, string? parcour)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"DataProcessings/GetFilterData?paramCodeUniv={codeUniv}&paramDept={dept}&paramGrade={grade}&paramFormation={formation}&paramNiveau={niveau}&paramSemestre={semestre}&paramParcour={parcour}");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetStatComparaisonData()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetStatComparaisonData");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetStatDataCommune(DataParameterDto dataParameter)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"DataProcessings/GetStatDataCommune", dataParameter);
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetStatDataDifferente(DataParameterDto dataParameter)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"DataProcessings/GetStatDataDifferente", dataParameter);
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetAllStatDataSearch()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("DataProcessings/GetAllStatDataSearch");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        public async Task<DataDashboardDto> GetFilterDataSearch(string? libelleEc)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"DataProcessings/GetFilterDataSearch?paramLibelleEC={libelleEc}");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

            return viewModel;
        }

        //public async Task<DataDashboardDto> GetStatDataCommune(List<string>? codeUnivs, string? grade, int? niveau, int? semestre)
        //{
        //    var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

        //    // Build query parameters
        //    var queryParams = new List<string>();

        //    if (codeUnivs != null && codeUnivs.Any()) { queryParams.AddRange(codeUnivs.Select(c => $"paramCodeUnivs={Uri.EscapeDataString(c)}")); }

        //    if (!string.IsNullOrEmpty(grade)) { queryParams.Add($"paramGrade={Uri.EscapeDataString(grade)}"); }

        //    if (niveau.HasValue) { queryParams.Add($"paramNiveau={niveau.Value}"); }

        //    if (semestre.HasValue) { queryParams.Add($"paramSemestre={semestre.Value}"); }

        //    // Construct URL with query parameters
        //    var url = "DataProcessings/GetStatDataCommune";
        //    if (queryParams.Any()) { url += "?" + string.Join("&", queryParams);
        //    }

        //    // Get data from Web API
        //    HttpResponseMessage response = await _httpClient.GetAsync(url);
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return null;
        //    }

        //    var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();
        //    return viewModel;
        //}

        //public async Task<DataDashboardDto> GetStatDataDifferente(List<string>? codeUnivs, string? grade, int? niveau, int? semestre)
        //{
        //    var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        //    // Get All Data from Web API
        //    HttpResponseMessage response = await _httpClient.GetAsync($"DataProcessings/GetStatDataDifferente?paramCodeUnivs={codeUnivs}&paramGrade={grade}&paramNiveau={niveau}&paramSemestre={semestre}");
        //    if (!response.IsSuccessStatusCode) { return null; }
        //    var viewModel = await response.Content.ReadFromJsonAsync<DataDashboardDto>();

        //    return viewModel;
        //}
    }
}
