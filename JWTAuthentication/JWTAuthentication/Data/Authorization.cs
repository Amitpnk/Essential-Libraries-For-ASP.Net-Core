namespace JWTAuthentication.Data
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }
        public const string default_username = "user";
        public const string default_email = "amit.naik8103@gmail.com";
        public const string default_password = "Password";
        public const Roles default_role = Roles.User;
    }
}
