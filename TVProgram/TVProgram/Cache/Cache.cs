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
                currentUser = value;
            }
        }
    }
}
