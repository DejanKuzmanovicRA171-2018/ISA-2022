namespace Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        //IUserRepository User { get; }
        IRegUserRepository RegUser { get; }
        IEmployeeRepository Employee { get; }
        ITransfusionCenterRepository TransfusionCenter { get; }
        IAdminRepository Admin { get; }
        IAppointmentRepository Appointment { get; }
        IBloodRepository Blood { get; }
        Task Save();
    }
}
