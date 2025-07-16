using AutoMapper;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace MaquetteForAnaqsup.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            //DataProcessing Mapping
            CreateMap<ImportData, ImportDataDto>().ReverseMap();
            CreateMap<ImportData, DataFormationDto>().ReverseMap();
            CreateMap<ImportData, DataParcourDto>().ReverseMap();
            CreateMap<ImportData, DataUniteEnseignementDto>().ReverseMap();
            CreateMap<ImportData, DataElementConstitutifDto>().ReverseMap();


            // Model Relation
            CreateMap<AtomeElementConstitutif, AtomeElementConstitutifDto>().ReverseMap();
            CreateMap<AtomePedagogique, AtomePedagogiqueDto>().ReverseMap();
            CreateMap<Debouche, DeboucheDto>().ReverseMap();
            CreateMap<Departement, DepartementDto>().ReverseMap();
            CreateMap<Domaine, DomaineDto>().ReverseMap();
            CreateMap<ElementConstitutif, ElementConstitutifDto>().ReverseMap();
            CreateMap<Faculte, FaculteDto>().ReverseMap();
            CreateMap<Grade, GradeDto>().ReverseMap();
            CreateMap<Niveau, NiveauDto>().ReverseMap();
            CreateMap<Semestre, SemestreDto>().ReverseMap();
            CreateMap<Formation, FormationDto>().ReverseMap();
            CreateMap<Mention, MentionDto>().ReverseMap();
            CreateMap<Parcour, ParcourDto>().ReverseMap();
            CreateMap<ParcourUniteEnseignement, ParcourUniteEnseignementDto>().ReverseMap();
            CreateMap<Specialite, SpecialiteDto>().ReverseMap();
            CreateMap<UniteEnseignement, UniteEnseignementDto>().ReverseMap();
            CreateMap<Universite, UniversiteDto>().ReverseMap();
            CreateMap<Ville, VilleDto>().ReverseMap();
        }
    }
}
