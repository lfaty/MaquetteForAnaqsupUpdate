using Microsoft.EntityFrameworkCore;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Collections.Specialized.BitVector32;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using Microsoft.ML;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MaquetteForAnaqsup.API.Services
{
    public class DatasService : IDatasService
    {
        private readonly ApplicationsDbContext _context;

        public DatasService(ApplicationsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImportData>> GetAllAsync()
        {
            var filteredData = await _context.ImportDatas.ToListAsync();
            return filteredData;
        }
        
        public async Task<IEnumerable<ImportData>> GetFilterDataAsync(string? paramCodeUniv, string? paramDept, string? paramGrade, string? paramFormation, int? paramNiveau, int? paramSemestre, string? paramParcour)
        {
            var filteredData = await _context.ImportDatas.ToListAsync();

            // Filtering paramCodeUniv
            if (string.IsNullOrWhiteSpace(paramCodeUniv) == false)
            {
                filteredData = filteredData.Where(x => x.CodeUniversite == paramCodeUniv).ToList();
            }

            // Filtering paramDept
            if (string.IsNullOrWhiteSpace(paramDept) == false)
            {
                filteredData = filteredData.Where(x => x.Departement.Contains(paramDept)).ToList();
            }

            // Filtering paramGrade
            if (string.IsNullOrWhiteSpace(paramGrade) == false)
            {
                filteredData = filteredData.Where(x => x.Grade == paramGrade).ToList();
            }

            // Filtering paramFormation
            if (string.IsNullOrWhiteSpace(paramFormation) == false)
            {
                filteredData = filteredData.Where(x => x.LibelleFormation.Contains(paramFormation) || x.Abreviation.Contains(paramFormation)).ToList();
            }

            // Filtering paramNiveau x.LibelleFormation.Contains(paramFormation)
            if (paramNiveau > 0)
            {
                filteredData = filteredData.Where(x => x.Niveau == paramNiveau).ToList();
            }

            // Filtering paramSemestre
            if (paramSemestre > 0)
            {
                filteredData = filteredData.Where(x => x.Semestre == paramSemestre).ToList();
            }

            // Filtering paramParcour
            if (string.IsNullOrWhiteSpace(paramParcour) == false)
            {
                filteredData = filteredData.Where(x => x.Parcours.Contains(paramParcour)).ToList();
            }

            return filteredData.OrderBy(x => x.LibelleFormation).ToList();
        }

        public async Task<IEnumerable<ImportData>> GetFormationCommuneAsync(DataParameterDto dataParameter)
        {
            var filteredData = await _context.ImportDatas.ToListAsync();
            var paramGrade = dataParameter.Grade;
            var paramNiveau = dataParameter.Niveau;
            var paramSemestre = dataParameter.Semestre;
            var lstCodeUniv = dataParameter.CodeUnivs ?? new List<string>();

            // Filtering paramGrade
            if (string.IsNullOrWhiteSpace(paramGrade) == false)
            {
                filteredData = filteredData.Where(x => x.Grade == paramGrade).ToList();
            }

            // Filtering paramNiveau 
            if (paramNiveau > 0)
            {
                filteredData = filteredData.Where(x => x.Niveau == paramNiveau).ToList();
            }

            // Filtering paramSemestre
            if (paramSemestre > 0)
            {
                filteredData = filteredData.Where(x => x.Semestre == paramSemestre).ToList();
            }

            //lstCodeUniv = ["UAD", "UASZ", "UGB", "UCAD"];
            List<ImportData> resultats = new List<ImportData>();

            if (lstCodeUniv.Count() > 1)
            {
                for (int i = 0; i < lstCodeUniv.Count(); i++)
                {
                    var j = i + 1;
                    if (j >= lstCodeUniv.Count())
                    {
                        var firstCode = lstCodeUniv.ElementAt(index: 0);
                        var lastCode = lstCodeUniv.ElementAt(index: ^1);
                        // Filtering paramCodeUniv
                        var filteredData_i = filteredData.Where(x => x.CodeUniversite == firstCode).ToList();
                        var filteredData_j = filteredData.Where(x => x.CodeUniversite == lastCode).ToList();

                        // Select LibelleLongEC for both universities
                        var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
                        var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

                        // Find common LibelleLongEC between the two universities
                        var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
                        // Filter the data for both universities based on the common LibelleLongEC
                        if (commonLibelleLongEC.Count == 0)
                        {
                            continue; // Skip to the next iteration if no common elements
                        }
                        // Add the results to the final list
                        resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
                        resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());

                        break;
                    }
                    else
                    {
                        // Filtering paramCodeUniv
                        var filteredData_i = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[i]).ToList();
                        var filteredData_j = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[j]).ToList();

                        // Select LibelleLongEC for both universities
                        var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
                        var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

                        // Find common LibelleLongEC between the two universities
                        var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
                        // Filter the data for both universities based on the common LibelleLongEC
                        if (commonLibelleLongEC.Count == 0)
                        {
                            continue; // Skip to the next iteration if no common elements
                        }
                        // Add the results to the final list
                        resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
                        resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
                    }
                }
            }
            else
            {
                var filteredData_0 = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[0]).ToList();
                var lstFormation = filteredData_0.GroupBy(x => x.Abreviation).Select(g => new { Abreviation = g.Key });

                for (int i = 0; i < lstFormation.Count(); i++)
                {
                    var j = i + 1;
                    if (j >= lstFormation.Count())
                    {
                        var firstAbreg = lstFormation.ElementAt(index: 0).Abreviation;
                        var lastAbreg = lstFormation.ElementAt(index: ^1).Abreviation;
                        // Filtering paramCodeUniv
                        var filteredData_i = filteredData_0.Where(x => x.Abreviation == firstAbreg).ToList();
                        var filteredData_j = filteredData_0.Where(x => x.Abreviation == lastAbreg).ToList();
                        // Select LibelleLongEC for both universities
                        var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
                        var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
                        // Find common LibelleLongEC between the two universities
                        var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
                        // Filter the data for both universities based on the common LibelleLongEC
                        if (commonLibelleLongEC.Count == 0)
                        {
                            continue; // Skip to the next iteration if no common elements
                        }
                        // Add the results to the final list
                        resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
                        resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());

                        break;
                    }
                    else
                    {
                        // Filtering paramCodeUniv
                        var filteredData_i = filteredData_0.Where(x => x.Abreviation == lstFormation.ElementAt(i).Abreviation).ToList();
                        var filteredData_j = filteredData_0.Where(x => x.Abreviation == lstFormation.ElementAt(j).Abreviation).ToList();
                        // Select LibelleLongEC for both universities
                        var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
                        var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
                        // Find common LibelleLongEC between the two universities
                        var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
                        // Filter the data for both universities based on the common LibelleLongEC
                        if (commonLibelleLongEC.Count == 0)
                        {
                            continue; // Skip to the next iteration if no common elements
                        }
                        // Add the results to the final list
                        resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
                        resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
                    }
                }
            }

            return resultats;
        }

        public async Task<IEnumerable<ImportData>> GetFormationDifferenceAsync(DataParameterDto dataParameter)
        {
            var filteredData = await _context.ImportDatas.ToListAsync();
            var paramGrade = dataParameter.Grade;
            var paramNiveau = dataParameter.Niveau;
            var paramSemestre = dataParameter.Semestre;
            var lstCodeUniv = dataParameter.CodeUnivs ?? new List<string>();

            // Filtering paramGrade
            if (string.IsNullOrWhiteSpace(paramGrade) == false)
            {
                filteredData = filteredData.Where(x => x.Grade == paramGrade).ToList();
            }

            // Filtering paramNiveau 
            if (paramNiveau > 0)
            {
                filteredData = filteredData.Where(x => x.Niveau == paramNiveau).ToList();
            }

            // Filtering paramSemestre
            if (paramSemestre > 0)
            {
                filteredData = filteredData.Where(x => x.Semestre == paramSemestre).ToList();
            }

            var FormationCommune = await GetFormationCommuneAsync(dataParameter);
            var selectDataCommun = FormationCommune.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

            // Filter FormationTotal to exclude items present in FormationCommune
            var FormationDifferente = filteredData.Where(item => !selectDataCommun.Contains(item.LibelleLongEC.ToLower().Trim())).ToList();

            return FormationDifferente;
        }


        //public async Task<IEnumerable<ImportData>> GetFormationCommuneAsync(List<string>? lstCodeUniv, string? paramGrade, int? paramNiveau, int? paramSemestre)
        //{
        //    var filteredData = await _context.ImportDatas.ToListAsync();

        //    // Filtering paramGrade
        //    if (string.IsNullOrWhiteSpace(paramGrade) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.Grade == paramGrade).ToList();
        //    }

        //    // Filtering paramNiveau 
        //    if (paramNiveau > 0)
        //    {
        //        filteredData = filteredData.Where(x => x.Niveau == paramNiveau).ToList();
        //    }

        //    // Filtering paramSemestre
        //    if (paramSemestre > 0)
        //    {
        //        filteredData = filteredData.Where(x => x.Semestre == paramSemestre).ToList();
        //    }

        //    //lstCodeUniv = ["UAD", "UASZ", "UGB", "UCAD"];
        //    List<ImportData> resultats = new List<ImportData>();

        //    if (lstCodeUniv.Count() > 1)
        //    {
        //        for (int i = 0; i < lstCodeUniv.Count(); i++)
        //        {
        //            var j = i + 1;
        //            if (j >= lstCodeUniv.Count())
        //            {
        //                var firstCode = lstCodeUniv.ElementAt(index: 0);
        //                var lastCode = lstCodeUniv.ElementAt(index: ^1);
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData.Where(x => x.CodeUniversite == firstCode).ToList();
        //                var filteredData_j = filteredData.Where(x => x.CodeUniversite == lastCode).ToList();

        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());

        //                break;
        //            }
        //            else
        //            {
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[i]).ToList();
        //                var filteredData_j = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[j]).ToList();

        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var filteredData_0 = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[0]).ToList();
        //        var lstFormation = filteredData_0.GroupBy(x => x.Abreviation).Select(g => new { Abreviation = g.Key });

        //        for (int i = 0; i < lstFormation.Count(); i++)
        //        {
        //            var j = i + 1;
        //            if (j >= lstFormation.Count())
        //            {
        //                var firstAbreg = lstFormation.ElementAt(index: 0).Abreviation;
        //                var lastAbreg = lstFormation.ElementAt(index: ^1).Abreviation;
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData_0.Where(x => x.Abreviation == firstAbreg).ToList();
        //                var filteredData_j = filteredData_0.Where(x => x.Abreviation == lastAbreg).ToList();
        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());

        //                break;
        //            }
        //            else
        //            {
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData_0.Where(x => x.Abreviation == lstFormation.ElementAt(i).Abreviation).ToList();
        //                var filteredData_j = filteredData_0.Where(x => x.Abreviation == lstFormation.ElementAt(j).Abreviation).ToList();
        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //            }
        //        }
        //    }

        //    return resultats;
        //}


        //public async Task<IEnumerable<ImportData>> GetFormationDifferenceAsync(List<string>? lstCodeUniv, string? paramGrade, int? paramNiveau, int? paramSemestre)
        //{
        //    //lstCodeUniv = ["UAD", "UASZ", "UGB", "UCAD"];
        //    var FormationTotal = await GetStatElementConstitutifAsync();
        //    // Filtering paramGrade
        //    if (string.IsNullOrWhiteSpace(paramGrade) == false)
        //    {
        //        FormationTotal = FormationTotal.Where(x => x.Grade == paramGrade).ToList();
        //    }

        //    // Filtering paramNiveau 
        //    if (paramNiveau > 0)
        //    {
        //        FormationTotal = FormationTotal.Where(x => x.Niveau == paramNiveau).ToList();
        //    }

        //    // Filtering paramSemestre
        //    if (paramSemestre > 0)
        //    {
        //        FormationTotal = FormationTotal.Where(x => x.Semestre == paramSemestre).ToList();
        //    }

        //    FormationTotal = FormationTotal.Where(x => lstCodeUniv.Contains(x.CodeUniversite)).ToList();

        //    var FormationCommune = await GetFormationCommuneAsync(lstCodeUniv, paramGrade, paramNiveau, paramSemestre);
        //    var selectDataCommun = FormationCommune.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

        //    // Filter FormationTotal to exclude items present in FormationCommune
        //    var FormationDifferente = FormationTotal.Where(item => !selectDataCommun.Contains(item.LibelleLongEC.ToLower().Trim())).ToList();

        //    return FormationDifferente;
        //}


        public async Task<IEnumerable<DataUniversiteDto>> GetStatUniversiteAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.CodeUniversite,
                data.LibelleUniversite
            }).Select(g => new DataUniversiteDto
            {
                CodeUniversite = g.Key.CodeUniversite,
                LibelleUniversite = g.Key.LibelleUniversite
            }).OrderBy(x => x.LibelleUniversite).ToListAsync();
        }

        public async Task<IEnumerable<DataDepartementDto>> GetStatDepartementAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.CodeUniversite,
                data.Faculte,
                data.Departement,
            }).Select(g => new DataDepartementDto
            {
                CodeUniversite = g.Key.CodeUniversite,
                Faculte = g.Key.Faculte,
                Departement = g.Key.Departement,
            }).OrderBy(x => x.Departement).ToListAsync();
        }

        public async Task<IEnumerable<DataGradeDto>> GetStatGradeAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.Grade
            }).Select(g => new DataGradeDto
            {
                Grade = g.Key.Grade
            }).OrderBy(x => x.Grade).ToListAsync();
        }

        public async Task<IEnumerable<DataNiveauDto>> GetStatNiveauAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.Niveau
            }).Select(g => new DataNiveauDto
            {
                Niveau = g.Key.Niveau
            }).OrderBy(x => x.Niveau).ToListAsync();
        }

        public async Task<IEnumerable<DataSemestreDto>> GetStatSemestreAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.Semestre
            }).Select(g => new DataSemestreDto
            {
                Semestre = g.Key.Semestre
            }).OrderBy(x => x.Semestre).ToListAsync();
        }

        public async Task<IEnumerable<DataFormationDto>> GetStatFormationAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.CodeUniversite,
                data.Faculte,
                data.Departement,
                data.Abreviation,
                data.LibelleFormation,
                data.Grade
            }).Select(g => new DataFormationDto
            {
                CodeUniversite = g.Key.CodeUniversite,
                Faculte = g.Key.Faculte,
                Departement = g.Key.Departement,
                Abreviation = g.Key.Abreviation,
                LibelleFormation = g.Key.LibelleFormation,
                Grade = g.Key.Grade,
                VolumeHoraire = g.Sum(item => (item.CM ?? 0) + (item.SEM ?? 0) + (item.TD ?? 0) + (item.TP ?? 0) + (item.TPE ?? 0))
            }).OrderBy(x => x.LibelleFormation).ToListAsync();
        }

        public async Task<IEnumerable<DataParcourDto>> GetStatParcourAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.CodeUniversite,
                data.Faculte,
                data.Departement,
                data.Abreviation,
                data.LibelleFormation,
                data.Grade,
                data.Parcours,
                data.Niveau
            }).Select(g => new DataParcourDto
            {
                CodeUniversite = g.Key.CodeUniversite,
                Faculte = g.Key.Faculte,
                Departement = g.Key.Departement,
                Abreviation = g.Key.Abreviation,
                LibelleFormation = g.Key.LibelleFormation,
                Grade = g.Key.Grade,
                LibelleParcour = g.Key.Parcours,
                Niveau = (int)g.Key.Niveau,
                VolumeHoraire = g.Sum(item => (item.CM ?? 0) + (item.SEM ?? 0) + (item.TD ?? 0) + (item.TP ?? 0) + (item.TPE ?? 0))
            }).OrderBy(x => x.LibelleParcour).ToListAsync();
        }

        public async Task<IEnumerable<DataUniteEnseignementDto>> GetStatUniteEnseignementAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.CodeUniversite,
                data.Faculte,
                data.Departement,
                data.Abreviation,
                data.LibelleFormation,
                data.Grade,
                data.Parcours,
                data.Niveau,
                data.CodeUE,
                data.LibelleUE,
                data.CreditUE,
                data.CoefUE,
                data.NatureUE

            }).Select(g => new DataUniteEnseignementDto
            {
                CodeUniversite = g.Key.CodeUniversite,
                Faculte = g.Key.Faculte,
                Departement = g.Key.Departement,
                Abreviation = g.Key.Abreviation,
                LibelleFormation = g.Key.LibelleFormation,
                Grade = g.Key.Grade,
                LibelleParcour = g.Key.Parcours,
                Niveau = (int)g.Key.Niveau,
                CodeUE = g.Key.CodeUE,
                LibelleUE = g.Key.LibelleUE,
                CreditUE = g.Key.CreditUE,
                CoefUE = g.Key.CoefUE,
                NatureUE = g.Key.NatureUE,
                VolumeHoraire = g.Sum(item => (item.CM ?? 0) + (item.SEM ?? 0) + (item.TD ?? 0) + (item.TP ?? 0) + (item.TPE ?? 0))
            }).OrderBy(x => x.LibelleUE).ToListAsync();
        }

        public async Task<IEnumerable<DataElementConstitutifDto>> GetStatElementConstitutifAsync()
        {
            return await _context.ImportDatas.GroupBy(data => new {
                data.CodeUniversite,
                data.Faculte,
                data.Departement,
                data.Abreviation,
                data.LibelleFormation,
                data.Grade,
                data.Parcours,
                data.Niveau,
                data.CodeUE,
                data.LibelleUE,
                data.CreditUE,
                data.CoefUE,
                data.NatureUE,
                data.LibelleLongEC,
                data.CoefEC,
                data.Semestre

            }).Select(g => new DataElementConstitutifDto
            {
                CodeUniversite = g.Key.CodeUniversite,
                Faculte = g.Key.Faculte,
                Departement = g.Key.Departement,
                Abreviation = g.Key.Abreviation,
                LibelleFormation = g.Key.LibelleFormation,
                Grade = g.Key.Grade,
                LibelleParcour = g.Key.Parcours,
                Niveau = (int)g.Key.Niveau,
                CodeUE = g.Key.CodeUE,
                LibelleUE = g.Key.LibelleUE,
                CreditUE = g.Key.CreditUE,
                CoefUE = g.Key.CoefUE,
                NatureUE = g.Key.NatureUE,
                LibelleLongEC = g.Key.LibelleLongEC,
                CoefEC = g.Key.CoefEC,
                Semestre = g.Key.Semestre,
                VolumeHoraire = g.Sum(item => (item.CM ?? 0) + (item.SEM ?? 0) + (item.TD ?? 0) + (item.TP ?? 0) + (item.TPE ?? 0))
            }).OrderBy(x => x.LibelleLongEC).ToListAsync();
        }

        public async Task<IEnumerable<DataStatComparaisonDto>> GetStatComparaisonAsync()
        {
            var filteredData = await _context.ImportDatas.ToListAsync();

            var formation = filteredData.GroupBy(data => new {
                data.CodeUniversite,
                data.Abreviation,
                data.LibelleFormation,
                data.Grade,
                data.Parcours,
                data.Niveau,
                data.CodeUE,
                data.LibelleUE,
                data.CreditUE,
                data.CoefUE,
                data.NatureUE,
                data.LibelleLongEC,
                data.CoefEC,
                data.Semestre
            }).Select(g => new DataStatComparaisonDto
            {
                CodeUniversite = g.Key.CodeUniversite,
                Abreviation = g.Key.Abreviation,
                LibelleFormation = g.Key.LibelleFormation,
                Grade = g.Key.Grade,
                Parcours = g.Key.Parcours,
                Niveau = (int)g.Key.Niveau,
                CodeUE = g.Key.CodeUE,
                LibelleUE = g.Key.LibelleUE,
                CreditUE = g.Key.CreditUE,
                CoefUE = g.Key.CoefUE,
                NatureUE = g.Key.NatureUE,
                LibelleLongEC = g.Key.LibelleLongEC,
                CoefEC = g.Key.CoefEC,
                Semestre = g.Key.Semestre,
                VolumeHoraire = g.Sum(item => (item.CM ?? 0) + (item.SEM ?? 0) + (item.TD ?? 0) + (item.TP ?? 0) + (item.TPE ?? 0))

            }).OrderBy(x => x.LibelleLongEC).ToList();

            return formation;
        }

        public async Task<IEnumerable<ImportData>> GetStatECSearch(string? paramLibelleEC)
        {
            var filteredData = await _context.ImportDatas.ToListAsync();

            // Filtering paramLibelleEC
            if (string.IsNullOrWhiteSpace(paramLibelleEC) == false)
            {
                filteredData = filteredData.Where(x => x.LibelleLongEC.Contains(paramLibelleEC)).ToList();
            }

           return filteredData;
        }


        //public async Task<IEnumerable<DataStatComparaisonDto>> GetFormationCommuneAsync(List<string>? lstCodeUniv, string? paramGrade, int? paramNiveau, int? paramSemestre)
        //{
        //    var filteredData = await _context.ImportDatas.ToListAsync();

        //    // Filtering paramGrade
        //    if (string.IsNullOrWhiteSpace(paramGrade) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.Grade == paramGrade).ToList();
        //    }

        //    // Filtering paramNiveau 
        //    if (paramNiveau > 0)
        //    {
        //        filteredData = filteredData.Where(x => x.Niveau == paramNiveau).ToList();
        //    }

        //    // Filtering paramSemestre
        //    if (paramSemestre > 0)
        //    {
        //        filteredData = filteredData.Where(x => x.Semestre == paramSemestre).ToList();
        //    }

        //    //lstCodeUniv = ["UAD", "UASZ", "UGB", "UCAD"];
        //    List<ImportData> resultats = new List<ImportData>();

        //    if (lstCodeUniv.Count() > 1)
        //    {
        //        for (int i = 0; i < lstCodeUniv.Count(); i++)
        //        {
        //            var j = i + 1;
        //            if (j >= lstCodeUniv.Count())
        //            {
        //                var firstCode = lstCodeUniv.ElementAt(index: 0);
        //                var lastCode = lstCodeUniv.ElementAt(index: ^1);
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData.Where(x => x.CodeUniversite == firstCode).ToList();
        //                var filteredData_j = filteredData.Where(x => x.CodeUniversite == lastCode).ToList();

        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());

        //                break;
        //            }
        //            else
        //            {
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[i]).ToList();
        //                var filteredData_j = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[j]).ToList();

        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var filteredData_0 = filteredData.Where(x => x.CodeUniversite == lstCodeUniv[0]).ToList();
        //        var lstFormation = filteredData_0.GroupBy(x => x.Abreviation).Select(g => new { Abreviation = g.Key });

        //        for (int i = 0; i < lstFormation.Count(); i++)
        //        {
        //            var j = i + 1;
        //            if (j >= lstFormation.Count())
        //            {
        //                var firstAbreg = lstFormation.ElementAt(index: 0).Abreviation;
        //                var lastAbreg = lstFormation.ElementAt(index: ^1).Abreviation;
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData_0.Where(x => x.Abreviation == firstAbreg).ToList();
        //                var filteredData_j = filteredData_0.Where(x => x.Abreviation == lastAbreg).ToList();
        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());

        //                break;
        //            }
        //            else
        //            {
        //                // Filtering paramCodeUniv
        //                var filteredData_i = filteredData_0.Where(x => x.Abreviation == lstFormation.ElementAt(i).Abreviation).ToList();
        //                var filteredData_j = filteredData_0.Where(x => x.Abreviation == lstFormation.ElementAt(j).Abreviation).ToList();
        //                // Select LibelleLongEC for both universities
        //                var selectData_i = filteredData_i.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                var selectData_j = filteredData_j.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();
        //                // Find common LibelleLongEC between the two universities
        //                var commonLibelleLongEC = selectData_i.Intersect(selectData_j).ToList();
        //                // Filter the data for both universities based on the common LibelleLongEC
        //                if (commonLibelleLongEC.Count == 0)
        //                {
        //                    continue; // Skip to the next iteration if no common elements
        //                }
        //                // Add the results to the final list
        //                resultats.AddRange(filteredData_i.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //                resultats.AddRange(filteredData_j.Where(item => commonLibelleLongEC.Contains(item.LibelleLongEC.ToLower().Trim())).ToList());
        //            }
        //        }
        //    }

        //    var formation = resultats.GroupBy(data => new {
        //        data.CodeUniversite,
        //        data.Abreviation,
        //        data.LibelleFormation,
        //        data.Grade,
        //        data.Parcours,
        //        data.Niveau,
        //        data.CodeUE,
        //        data.LibelleUE,
        //        data.CreditUE,
        //        data.CoefUE,
        //        data.NatureUE,
        //        data.LibelleLongEC,
        //        data.CoefEC,
        //        data.Semestre
        //    }).Select(g => new DataStatComparaisonDto
        //    {
        //        CodeUniversite = g.Key.CodeUniversite,
        //        Abreviation = g.Key.Abreviation,
        //        LibelleFormation = g.Key.LibelleFormation,
        //        Grade = g.Key.Grade,
        //        Parcours = g.Key.Parcours,
        //        Niveau = (int)g.Key.Niveau,
        //        CodeUE = g.Key.CodeUE,
        //        LibelleUE = g.Key.LibelleUE,
        //        CreditUE = g.Key.CreditUE,
        //        CoefUE = g.Key.CoefUE,
        //        NatureUE = g.Key.NatureUE,
        //        LibelleLongEC = g.Key.LibelleLongEC,
        //        CoefEC = g.Key.CoefEC,
        //        Semestre = g.Key.Semestre,
        //        VolumeHoraire = g.Sum(item => (item.CM ?? 0) + (item.SEM ?? 0) + (item.TD ?? 0) + (item.TP ?? 0) + (item.TPE ?? 0))

        //    }).OrderBy(x => x.LibelleLongEC).ToList();

        //    return formation;
        //}

        //public async Task<IEnumerable<DataStatComparaisonDto>> GetFormationDifferenceAsync(List<string>? lstCodeUniv, string? paramGrade, int? paramNiveau, int? paramSemestre)
        //{
        //    //lstCodeUniv = ["UAD", "UASZ", "UGB", "UCAD"];
        //    var FormationTotal = await GetStatElementConstitutifAsync();
        //    // Filtering paramGrade
        //    if (string.IsNullOrWhiteSpace(paramGrade) == false)
        //    {
        //        FormationTotal = FormationTotal.Where(x => x.Grade == paramGrade).ToList();
        //    }

        //    // Filtering paramNiveau 
        //    if (paramNiveau > 0)
        //    {
        //        FormationTotal = FormationTotal.Where(x => x.Niveau == paramNiveau).ToList();
        //    }

        //    // Filtering paramSemestre
        //    if (paramSemestre > 0)
        //    {
        //        FormationTotal = FormationTotal.Where(x => x.Semestre == paramSemestre).ToList();
        //    }

        //    FormationTotal = FormationTotal.Where(x => lstCodeUniv.Contains(x.CodeUniversite)).ToList();

        //    var FormationCommune = await GetFormationCommuneAsync(lstCodeUniv, paramGrade, paramNiveau, paramSemestre);
        //    var selectDataCommun = FormationCommune.Select(x => x.LibelleLongEC.ToLower().Trim()).ToList();

        //    // Filter FormationTotal to exclude items present in FormationCommune
        //    var FormationDifferente = FormationTotal.Where(item => !selectDataCommun.Contains(item.LibelleLongEC.ToLower().Trim())).ToList();

        //    var formation = FormationDifferente.GroupBy(data => new
        //    {
        //        data.CodeUniversite,
        //        data.Abreviation,
        //        data.LibelleFormation,
        //        data.Grade,
        //        data.Niveau,
        //        data.CodeUE,
        //        data.LibelleUE,
        //        data.CreditUE,
        //        data.CoefUE,
        //        data.NatureUE,
        //        data.LibelleLongEC,
        //        data.CoefEC,
        //        data.Semestre
        //    }).Select(g => new DataStatComparaisonDto
        //    {
        //        CodeUniversite = g.Key.CodeUniversite,
        //        Abreviation = g.Key.Abreviation,
        //        LibelleFormation = g.Key.LibelleFormation,
        //        Grade = g.Key.Grade,
        //        Niveau = (int)g.Key.Niveau,
        //        CodeUE = g.Key.CodeUE,
        //        LibelleUE = g.Key.LibelleUE,
        //        CreditUE = g.Key.CreditUE,
        //        CoefUE = g.Key.CoefUE,
        //        NatureUE = g.Key.NatureUE,
        //        LibelleLongEC = g.Key.LibelleLongEC,
        //        CoefEC = g.Key.CoefEC,
        //        Semestre = g.Key.Semestre
        //    }).OrderBy(x => x.LibelleLongEC).ToList();

        //    return formation;
        //}
    }
}
