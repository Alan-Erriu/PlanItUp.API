namespace PlanItUP.Entities.DTOs
{
    public class LoginDTO
    {
        public int client_id { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public bool status { get; set; }
    }
}
