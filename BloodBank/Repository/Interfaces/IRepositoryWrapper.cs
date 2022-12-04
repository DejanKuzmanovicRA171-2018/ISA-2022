namespace Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IRegUserRepository RegUser { get; }
        IEmployeeRepository Employee { get; }
        ITransfusionCenterRepository TransfusionCenter { get; }
        ITCAdminRepository TCAdmin { get; }
        IAdminRepository Admin { get; }
        IAppointmentRepository Appointment { get; }
        Task Save();
    }
}
