//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnTheFlyWPFC.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FinanceTBL
    {
        public int FinanceID { get; set; }
        public bool FinancePositive { get; set; }
        public decimal FinanceValue { get; set; }
        public string FinanceReason { get; set; }
        public int FinanceEmployee { get; set; }
        public string FinanceEmployeeName { get; set; }
        public System.DateTime FinanceAddDate { get; set; }
    }
}
