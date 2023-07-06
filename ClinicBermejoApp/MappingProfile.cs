using AutoMapper;
using Entities.Models;
using Entities.Models.Appointments;
using Entities.Models.Items;
using Entities.Models.Orders;
using Entities.Models.Sales;
using Entities.Models.Services;
using Entities.Models.Staff;
using Shared.AppointmentDoctors;
using Shared.Appointments;
using Shared.Brands;
using Shared.CategoryItem;
using Shared.CategoryService;
using Shared.Customers;
using Shared.DetailOrders;
using Shared.DetailSales;
using Shared.Doctors;
using Shared.Items;
using Shared.Notes;
using Shared.Nurses;
using Shared.Orders;
using Shared.Patients;
using Shared.Sales;
using Shared.ServiceDoctors;
using Shared.Services;
using Shared.Suppliers;
using Shared.UnitBases;
using Shared.Units;

namespace ClinicBermejoApp;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DoctorDto, Doctor>().ReverseMap();
        CreateMap<DoctorForCreationDto, Doctor>().ReverseMap();
        CreateMap<DoctorForUpdateDto, Doctor>().ReverseMap();
        CreateMap<DoctorForViewDto, Doctor>().ReverseMap();

        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<PatientForCreationDto, Patient>().ReverseMap();
        CreateMap<PatientForUpdateDto, Patient>().ReverseMap();
        CreateMap<PatientForViewDto, Patient>().ReverseMap();

        CreateMap<NurseDto, Nurse>().ReverseMap();
        CreateMap<NurseForCreationDto, Nurse>().ReverseMap();
        CreateMap<NurseForUpdateDto, Nurse>().ReverseMap();
        CreateMap<NurseForViewDto, Nurse>().ReverseMap();

        CreateMap<SupplierDto, Supplier>().ReverseMap();
        CreateMap<SupplierForCreationDto, Supplier>().ReverseMap();
        CreateMap<SupplierForUpdateDto, Supplier>().ReverseMap();
        CreateMap<SupplierForViewDto, Supplier>().ReverseMap();

        CreateMap<CategoryServiceDto, CategoryService>().ReverseMap();
        CreateMap<CategoryServiceForCreationDto, CategoryService>().ReverseMap();
        CreateMap<CategoryServiceForUpdateDto, CategoryService>().ReverseMap();
        CreateMap<CategoryServiceForViewDto, CategoryService>().ReverseMap();

        CreateMap<ServiceDto, Entities.Models.Services.Service>().ReverseMap();
        CreateMap<ServiceForCreationDto, Entities.Models.Services.Service>().ReverseMap();
        CreateMap<ServiceForUpdateDto, Entities.Models.Services.Service>().ReverseMap();
        CreateMap<ServiceForViewDto, Entities.Models.Services.Service>().ReverseMap();

        CreateMap<ServiceDoctorDto, ServiceDoctor>().ReverseMap();
        CreateMap<ServiceDoctorForCreationDto, ServiceDoctor>().ReverseMap();
        CreateMap<ServiceDoctorForUpdateDto, ServiceDoctor>().ReverseMap();
        CreateMap<ServiceDoctorForViewDto, ServiceDoctor>().ReverseMap();
        CreateMap<ServiceDoctorForDoctorViewDto, ServiceDoctor>().ReverseMap();

        CreateMap<AppointmentDto, Appointment>().ReverseMap();
        CreateMap<AppointmentForCreationDto, Appointment>().ReverseMap();
        CreateMap<AppointmentForUpdateDto, Appointment>().ReverseMap();
        CreateMap<AppointmentForViewDto, Appointment>().ReverseMap();
        CreateMap<AppointmentForDoctorViewDto, Appointment>().ReverseMap();

        CreateMap<AppointmentDoctorDto, AppointmentDoctor>().ReverseMap();
        CreateMap<AppointmentDoctorForCreationDto, AppointmentDoctor>().ReverseMap();
        CreateMap<AppointmentDoctorForUpdateDto, AppointmentDoctor>().ReverseMap();
        CreateMap<AppointmentDoctorForViewDto, AppointmentDoctor>().ReverseMap();
        CreateMap<AppointmentDoctorForDoctorViewDto, AppointmentDoctor>().ReverseMap();

        CreateMap<OrderDto, Order>().ReverseMap();
        CreateMap<OrderForCreationDto, Order>().ReverseMap();
        CreateMap<OrderForUpdateDto, Order>().ReverseMap();
        CreateMap<OrderForViewDto, Order>().ReverseMap();

        CreateMap<DetailOrderDto, DetailOrder>().ReverseMap();
        CreateMap<DetailOrderForCreationDto, DetailOrder>().ReverseMap();
        CreateMap<DetailOrderForUpdateDto, DetailOrder>().ReverseMap();
        CreateMap<DetailOrderForViewDto, DetailOrder>().ReverseMap();

        CreateMap<BrandDto, Brand>().ReverseMap();
        CreateMap<BrandForViewDto, Brand>().ReverseMap();
        CreateMap<BrandForCreationDto, Brand>().ReverseMap();
        CreateMap<BrandForUpdateDto, Brand>().ReverseMap();

        CreateMap<UnitDto, Unit>().ReverseMap();
        CreateMap<UnitForCreationDto, Unit>().ReverseMap();
        CreateMap<UnitForUpdateDto, Unit>().ReverseMap();
        CreateMap<UnitForViewDto, Unit>().ReverseMap();

        CreateMap<CategoryItemDto, CategoryItem>().ReverseMap();
        CreateMap<CategoryItemForCreationDto, CategoryItem>().ReverseMap();
        CreateMap<CategoryItemForUpdateDto, CategoryItem>().ReverseMap();
        CreateMap<CategoryItemForViewDto, CategoryItem>().ReverseMap();

        CreateMap<ItemDto, Item>().ReverseMap();
        CreateMap<ItemForCreationDto, Item>().ReverseMap();
        CreateMap<ItemForUpdateDto, Item>().ReverseMap();
        CreateMap<ItemForViewDto, Item>().ReverseMap();

        CreateMap<ItemUnitForManipulationDto, ItemUnit>().ReverseMap();
        CreateMap<CategoryItemMNForManipulationDto, CategoryItemMN>().ReverseMap();

        CreateMap<UnitBaseDto, UnitBase>().ReverseMap();
        CreateMap<UnitBaseForCreationDto, UnitBase>().ReverseMap();
        CreateMap<UnitBaseForUpdateDto, UnitBase>().ReverseMap();
        CreateMap<UnitBaseForViewDto, UnitBase>().ReverseMap();

        CreateMap<CustomerDto, Customer>().ReverseMap();
        CreateMap<CustomerForCreationDto, Customer>().ReverseMap();
        CreateMap<CustomerForUpdateDto, Customer>().ReverseMap();
        CreateMap<CustomerForViewDto, Customer>().ReverseMap();

        CreateMap<SaleDto, Sale>().ReverseMap();
        CreateMap<SaleForCreationDto, Sale>().ReverseMap();
        CreateMap<SaleForUpdateDto, Sale>().ReverseMap();
        CreateMap<SaleForViewDto, Sale>().ReverseMap();

        CreateMap<DetailSaleDto, DetailSale>().ReverseMap();
        CreateMap<DetailSaleForCreationDto, DetailSale>().ReverseMap();
        CreateMap<DetailSaleForUpdateDto, DetailSale>().ReverseMap();
        CreateMap<DetailSaleForViewDto, DetailSale>().ReverseMap();

        CreateMap<NoteDto, Note>().ReverseMap();
        CreateMap<NoteForCreationDto, Note>().ReverseMap();
        CreateMap<NoteForUpdateDto, Note>().ReverseMap();
        CreateMap<NoteForViewDto, Note>().ReverseMap();
    }
}