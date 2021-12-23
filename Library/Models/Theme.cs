using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class Theme:IModel
    {
        public int ThemeId { get; set; }
        public string ThemeName { get; set; }
        public IReadOnlyCollection<ThemeBookFund> ThemeBookFunds { get; set; } = new List<ThemeBookFund>();
    }
}
