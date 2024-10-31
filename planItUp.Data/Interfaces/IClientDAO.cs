namespace PlanItUp.Data.Interfaces
{
    public interface IClientDAO
    {
        Task<bool> CheckEmailExists(string emailClient);
    }
}