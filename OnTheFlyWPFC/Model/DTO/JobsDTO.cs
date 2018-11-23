using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class JobsDTO
    {
        public int jobID { get; set; }
        public string job_name { get; set; }
        public Double basic_salary { get; set; }
        public int working_days_per_month { get; set; }
    }
}

