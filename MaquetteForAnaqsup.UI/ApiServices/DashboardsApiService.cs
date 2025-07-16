using MaquetteForAnaqsup.UI.Models.DTO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MaquetteForAnaqsup.UI.ApiServices
{
    public class DashboardsApiService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DashboardsApiService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        #region Get All Datas Globals
        public async Task<IEnumerable<UniversiteDto>> GetAllUniversite()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("Dashboards/GetAllUniversite");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<UniversiteDto>>();
        }

        public async Task<DashboardDto> GetAllFaculte(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllFaculte?paramCodeUniv={codeUniv}");
            response.EnsureSuccessStatusCode();

            DashboardDto viewModel = new DashboardDto();
            viewModel.Facultes = await response.Content.ReadFromJsonAsync<IEnumerable<FaculteDto>>();

            return viewModel;
        }

        public async Task<DashboardDto> GetAllDepartement(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllDepartement?paramCodeUniv={codeUniv}");
            response.EnsureSuccessStatusCode();

            DashboardDto viewModel = new DashboardDto();
            viewModel.Departements = await response.Content.ReadFromJsonAsync<IEnumerable<DepartementDto>>();

            return viewModel;
        }

        public async Task<IEnumerable<FormationDto>> GetAllFormation(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllFormation?paramCodeUniv={codeUniv}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<FormationDto>>(); ;
        }

        public async Task<IEnumerable<ParcourDto>> GetAllParcour(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllParcour?paramCodeUniv={codeUniv}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ParcourDto>>(); ;
        }

        public async Task<DashboardDto> GetAllGrade(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllGrade?paramCodeUniv={codeUniv}");

            response.EnsureSuccessStatusCode();
            DashboardDto viewModel = new DashboardDto();
            viewModel.Grades = await response.Content.ReadFromJsonAsync<IEnumerable<GradeDto>>();

            return viewModel;
        }

        public async Task<DashboardDto> GetAllNiveau(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllNiveau?paramCodeUniv={codeUniv}");

            response.EnsureSuccessStatusCode();
            DashboardDto viewModel = new DashboardDto();
            viewModel.Niveaus = await response.Content.ReadFromJsonAsync<IEnumerable<NiveauDto>>();

            return viewModel;
        }

        public async Task<DashboardDto> GetAllSemestre(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllSemestre?paramCodeUniv={codeUniv}");

            response.EnsureSuccessStatusCode();
            DashboardDto viewModel = new DashboardDto();
            viewModel.Semestres = await response.Content.ReadFromJsonAsync<IEnumerable<SemestreDto>>();

            return viewModel;
        }

        public async Task<IEnumerable<ElementConstitutifDto>> GetAllElementConstitutif(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllElementConstitutif?paramCodeUniv={codeUniv}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ElementConstitutifDto>>();
        }

        public async Task<IEnumerable<UniteEnseignementDto>> GetAllUniteEnseignement(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllUniteEnseignement?paramCodeUniv={codeUniv}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<UniteEnseignementDto>>();
        }

        public async Task<DashboardDto> GetAllAtomePedagogique(string? codeUniv)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllAtomePedagogique?paramCodeUniv={codeUniv}");

            response.EnsureSuccessStatusCode();
            DashboardDto viewModel = new DashboardDto();
            viewModel.AtomePedagogiques = await response.Content.ReadFromJsonAsync<IEnumerable<AtomePedagogiqueDto>>();

            return viewModel;
        }

        #endregion


        #region Data Processing

        public async Task<DashboardDto> GetAllData()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync("Dashboards/GetAllData");
            if (!response.IsSuccessStatusCode) { return null; }
            var viewModel = await response.Content.ReadFromJsonAsync<DashboardDto>();

            return viewModel;
        }

        public async Task<DashboardDto> FilterFormation(string? codeUniv, Guid? idFaculte, Guid? idDept)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/FilterFormation?paramCodeUniv={codeUniv}&paramIdFaculte={idFaculte}&paramIdDept={idDept}");
            if (!response.IsSuccessStatusCode) { return null; }

            response.EnsureSuccessStatusCode();
            var viewModel = await response.Content.ReadFromJsonAsync<DashboardDto>();

            return viewModel;
        }

        public async Task<DashboardDto> FilterSearch(string? codeUniv, string? motCle)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/FilterSearch?paramCodeUniv={codeUniv}&keyword={motCle}");
            if (!response.IsSuccessStatusCode) { return null; }

            var viewModel = await response.Content.ReadFromJsonAsync<DashboardDto>();

            return viewModel;
        }

        public async Task<DashboardDto> GetAllFormationBeetwenTwoUniv(string? codeUnivA, string? codeUnivB)
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/GetAllFormationBeetwenTwoUniv?paramCodeUniv1={codeUnivA}&paramCodeUniv2={codeUnivB}");
            if (!response.IsSuccessStatusCode) { return null; }

            response.EnsureSuccessStatusCode();
            var viewModel = await response.Content.ReadFromJsonAsync<DashboardDto>();

            return viewModel;
        }

        public async Task<DashboardDto> GetAllDataCompleted()
        {
            var _httpClient = httpClientFactory.CreateClient("custom-httpclient");

            // Get All Data from Web API
            //HttpResponseMessage response = await _httpClient.GetAsync($"Dashboards/FilterUeParcourByCodeUniv?paramCodeUniv={codeUniv}");
            HttpResponseMessage response = await _httpClient.GetAsync("Dashboards/GetAllDataCompleted");
            if (!response.IsSuccessStatusCode) { return null; }

            var viewModel = await response.Content.ReadFromJsonAsync<DashboardDto>();

            return viewModel;
        }
        #endregion

    }
}
