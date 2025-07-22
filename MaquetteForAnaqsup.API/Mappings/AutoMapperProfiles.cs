using AutoMapper;
using MaquetteForAnaqsup.API.Identity.DTO;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace MaquetteForAnaqsup.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // User Mapping
            CreateMap<IdentityUser, UserDto>().ReverseMap();
            CreateMap<IdentityRole, RoleDto>().ReverseMap();
            CreateMap<IdentityRole, AddRoleDto>().ReverseMap();

            CreateMap<AnneeMaquette, AnneeMaquetteDto>().ReverseMap();
            CreateMap<AnneeMaquette, AddAnneeMaquetteDto>().ReverseMap();
            CreateMap<AnneeMaquette, UpdateAnneeMaquetteDto>().ReverseMap();
            CreateMap<AnneeMaquette, StatutDto>().ReverseMap();

            CreateMap<UniversiteUser, UniversiteUserDto>().ReverseMap();
            CreateMap<UniversiteUser, AddUniversiteUserDto>().ReverseMap();
            CreateMap<UniversiteUser, UpdateUniversiteUserDto>().ReverseMap();
            CreateMap<UniversiteUser, StatutDto>().ReverseMap();

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
