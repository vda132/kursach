using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class Users:IModel
    {
        public int IdUser { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
    }
}
