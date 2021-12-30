using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Cache
{
    class UserCache
    {
        private static UserCache instance = null;

        public Users CurrentUser { get; set; } = null;

        private UserCache()
        { }

        public static UserCache GetInstance()
        {
            return instance == null ? (instance = new UserCache()) : instance;
        }
    }
}
