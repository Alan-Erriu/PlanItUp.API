namespace PlanItUp.Data.Interfaces
{
    public interface IRoleDAO
    {
        Task<int?> GetIdRoleByName(string name);
    }
}