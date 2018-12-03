using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel
{
    public class FinanceViewModel
    {
        FinanceService financeService;
        public ObservableCollection<FinanceDTO> viewFinances { get; set; }
        public FinanceDTO finance { get; set; }


        public FinanceViewModel()
        {
            financeService = new FinanceService();
            viewFinances = new ObservableCollection<FinanceDTO>();            
            finance = new FinanceDTO();
            
            GetAllFinances();
        }

        async public Task<bool> AddFinance(bool financePosative, decimal financeValue, string financeReason, int financeEmployee,string financeEmployeeName, DateTime financeAddDate)
        {
            return await financeService.AddFinance( financePosative,  financeValue,  financeReason, financeEmployee,financeEmployeeName,  financeAddDate);
        }

        async public Task<decimal> GetAllPosativeFinanceDecimal() {
            return await financeService.GetAllPosativeFinanceDecimal();
        }
        async public Task<decimal> GetAllNegativeFinanceDecimal() {
            return await financeService.GetAllNegativeFinanceDecimal();
        }

        async public void GetAllFinances()
        {
            viewFinances = await financeService.GetAllFinances();
        }

        async public void GetFiananceByID(int financeID)
        {
            finance = await financeService.GetFiananceByID(financeID);
        }

        async public void GetFinanceByReason(string reason)
        {
            viewFinances = await financeService.GetFinanceByReason(reason);
        }

        async public void GetFinanceByEmployee(int employeeID)
        {
            viewFinances = await financeService.GetFinanceByEmployee(employeeID);            
        }

        async public void GetFinanceByDate(DateTime date)
        {
            viewFinances = await financeService.GetFinanceByDate(date);
        }

        async public void GetAllPosativeFinance()
        {
            viewFinances = await financeService.GetAllPosativeFinance();
        }

        async public void GetAllNegativeFinance()
        {
            viewFinances = await financeService.GetAllNegativeFinance();
        }


    }
}
