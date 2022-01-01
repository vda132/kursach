using TVProgram.Models;

namespace TVProgram
{
    class Cache
    {
        #region Singleton
        private static Cache instance = null;
        public static Cache Instance => instance == null ? (instance = new Cache()) : instance;
        private Cache()
        {

        }
        #endregion

        private User currentUser;
        public User CurrectUser
        {
            get => currentUser;
            set
            {
                if (value == null)
                    CurrentUserStatus = UserStatus.Unknown;
                if (value.Status == "admin")
                    CurrentUserStatus = UserStatus.Admin;
                else
                    CurrentUserStatus = UserStatus.User;

                currentUser = value;
            }
        }
        public UserStatus CurrentUserStatus { get; private set; }
    }
}
