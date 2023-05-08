﻿using AutoMapper;
using Entities.Models;
using Entities.Models.Services;
using Entities.Models.Staff;
using Shared;
using Shared.CategoryService;
using Shared.Doctors;
using Shared.Nurses;
using Shared.Patients;
using Shared.Suppliers;

namespace ClinicBermejoApp;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DoctorDto, Doctor>().ReverseMap();
        CreateMap<DoctorForCreationDto, Doctor>().ReverseMap();
        CreateMap<DoctorForUpdateDto, Doctor>().ReverseMap();

        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<PatientForCreationDto, Patient>().ReverseMap();
        CreateMap<PatientForUpdateDto, Patient>().ReverseMap();

        CreateMap<NurseDto, Nurse>().ReverseMap();
        CreateMap<NurseForCreationDto, Nurse>().ReverseMap();
        CreateMap<NurseForUpdateDto, Nurse>().ReverseMap();

        CreateMap<SupplierDto, Supplier>().ReverseMap();
        CreateMap<SupplierForCreationDto, Supplier>().ReverseMap();
        CreateMap<SupplierForUpdateDto, Supplier>().ReverseMap();

        CreateMap<CategoryServiceDto, CategoryService>().ReverseMap();
        CreateMap<CategoryServiceForCreationDto, CategoryService>().ReverseMap();
        CreateMap<CategoryServiceForUpdateDto, CategoryService>().ReverseMap();
    }
}