namespace WebApiApp.Model
{
    public class UserModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsDelete { get; set; }
    }
}
