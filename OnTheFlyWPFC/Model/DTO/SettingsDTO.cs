using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class SettingsDTO
    {
        public int settingID { get; set; }
        public string name { get; set; }
        public decimal? value_money { get; set; }
        public int? value_int { get; set; }
        public string code { get; set; }
    }
}
