namespace RefreshJwtAuthentication.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }
        public const string default_username = "admin";
        public const string default_email = "admin@gmail.com";
        public const string default_password = "Password@1234";
        public const Roles default_role = Roles.User;
    }
}
