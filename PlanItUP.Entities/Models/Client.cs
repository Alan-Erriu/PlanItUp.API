namespace PlanItUP.Entities.Models
{
    public class Client
    {
        public int client_id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string password_hash { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public bool status { get; set; }
        public int? role_id { get; set; }

    }
}
