﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class FinanceDTO
    {
        public int financeID { get; set; }
        public bool financePositive { get; set; }
        public decimal financeValue { get; set; }
        public string financeReason { get; set; }
        public int financeEmployee { get; set; }
        public string financeEmployeeName { get; set; }
        public DateTime financeAddDate { get; set; }
    }
}
