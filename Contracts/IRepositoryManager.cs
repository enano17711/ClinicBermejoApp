﻿namespace Contracts;

public interface IRepositoryManager
{
    ISupplierRepository Suppliers { get; }

    IPatientRepository Patients { get; }
    ICustomerRepository Customers { get; }

    // staff
    INurseRepository Nurses { get; }

    IDoctorRepository Doctors { get; }

    // services
    ICategoryServiceRepository CategoryServices { get; }
    IServiceRepository Services { get; }

    IServiceDoctorRepository ServiceDoctors { get; }

    // appointments
    IAppointmentRepository Appointments { get; }

    IAppointmentDoctorRepository AppointmentDoctors { get; }

    // Orders
    IOrderRepository Orders { get; }

    IDetailOrderRepository DetailOrders { get; }

    INoteRepository Notes { get; }

    // sales
    ISaleRepository Sales { get; }
    IDetailSaleRepository DetailSales { get; }

    // items
    IBrandRepository Brands { get; }
    IUnitRepository Units { get; }
    ICategoryItemRepository CategoryItems { get; }
    IItemRepository Items { get; }
    IItemUnitRepository ItemUnits { get; }
    ICategoryItemMNRepository CategoryItemMNs { get; }
    IUnitBaseRepository UnitBases { get; }
    Task SaveAsync();
}