using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using System.Collections.ObjectModel;

namespace OnTheFlyWPFC.Model.Service
{
    public class FinanceService
    {
        async public Task<bool> AddFinance(bool financePosative, decimal financeValue, string financeReason,int financeEmployee,string financeEmployeeName, DateTime financeAddDate)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.FinanceTBLs.Add(new FinanceTBL()
                    {
                        FinancePositive = financePosative,
                        FinanceValue = financeValue,
                        FinanceReason = financeReason,
                        FinanceEmployee = financeEmployee,
                        FinanceAddDate = financeAddDate,
                        FinanceEmployeeName = financeEmployeeName,

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        async public Task<ObservableCollection<FinanceDTO>> GetAllFinances()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.FinanceTBLs.Select(s => new FinanceDTO()
                {
                    financePositive = s.FinancePositive,
                    financeValue = s.FinanceValue,
                    financeReason = s.FinanceReason,
                    financeEmployee = s.FinanceEmployee,
                    financeAddDate = s.FinanceAddDate,
                    financeEmployeeName = s.FinanceEmployeeName,
                    
                }).ToList();

                return new ObservableCollection<FinanceDTO>(result);
            }
        }

        async public Task<FinanceDTO> GetFiananceByID(int financeID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.FinanceTBLs.SingleOrDefault(w => w.FinanceID == financeID);

                if (result != null)
                {
                    return new FinanceDTO()
                    {
                        financePositive = result.FinancePositive,
                        financeValue = result.FinanceValue,
                        financeReason = result.FinanceReason,
                        financeEmployee = result.FinanceEmployee,
                        financeEmployeeName = result.FinanceEmployeeName,
                        financeAddDate = result.FinanceAddDate

                    };
                };

                return new FinanceDTO() {
                    financePositive = false,
                    financeValue = 0,
                    financeReason = null,
                    financeEmployee = 0,
                    financeEmployeeName = "",
                financeAddDate = DateTime.Now,
                };
                               
            }
        }

        async public Task<ObservableCollection<FinanceDTO>> GetFinanceByReason(string reason)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.FinanceTBLs.Where(w => w.FinanceReason.StartsWith(reason)).Select(s => new FinanceDTO()
                {
                    financePositive = s.FinancePositive,
                    financeValue = s.FinanceValue,
                    financeReason = s.FinanceReason,
                    financeEmployee = s.FinanceEmployee,
                    financeEmployeeName = s.FinanceEmployeeName,
                    financeAddDate = s.FinanceAddDate
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<FinanceDTO>(result);
                }
                else
                {
                    return new ObservableCollection<FinanceDTO>();
                }
            }

        }

        async public Task<ObservableCollection<FinanceDTO>> GetFinanceByEmployee(int userID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.FinanceTBLs.Where(w => w.FinanceEmployee == userID).Select(s => new FinanceDTO()
                {
                    financePositive = s.FinancePositive,
                    financeValue = s.FinanceValue,
                    financeReason = s.FinanceReason,
                    financeEmployee = s.FinanceEmployee,
                    financeEmployeeName = s.FinanceEmployeeName,
                    financeAddDate = s.FinanceAddDate
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<FinanceDTO>(result);
                }
                else
                {
                    return new ObservableCollection<FinanceDTO>();
                }



            }

        }

        async public Task<ObservableCollection<FinanceDTO>> GetFinanceByDate(DateTime date)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.FinanceTBLs.Where(w => w.FinanceAddDate == date).Select(s => new FinanceDTO()
                {
                    financePositive = s.FinancePositive,
                    financeValue = s.FinanceValue,
                    financeReason = s.FinanceReason,
                    financeEmployee = s.FinanceEmployee,
                    financeEmployeeName = s.FinanceEmployeeName,
                    financeAddDate = s.FinanceAddDate
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<FinanceDTO>(result);
                }
                else
                {
                    return new ObservableCollection<FinanceDTO>();
                }



            }

        }

        async public Task<ObservableCollection<FinanceDTO>> GetAllPosativeFinance()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.FinanceTBLs.Where(w => w.FinancePositive == true).Select(s => new FinanceDTO()
                {
                    financePositive = s.FinancePositive,
                    financeValue = s.FinanceValue,
                    financeReason = s.FinanceReason,
                    financeEmployee = s.FinanceEmployee,
                    financeEmployeeName = s.FinanceEmployeeName,
                    financeAddDate = s.FinanceAddDate
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<FinanceDTO>(result);
                }
                else
                {
                    return new ObservableCollection<FinanceDTO>();
                }



            }

        }

        async public Task<ObservableCollection<FinanceDTO>> GetAllNegativeFinance()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.FinanceTBLs.Where(w => w.FinancePositive == false).Select(s => new FinanceDTO()
                {
                    financePositive = s.FinancePositive,
                    financeValue = s.FinanceValue,
                    financeReason = s.FinanceReason,
                    financeEmployee = s.FinanceEmployee,
                    financeEmployeeName = s.FinanceEmployeeName,
                    financeAddDate = s.FinanceAddDate
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<FinanceDTO>(result);
                }
                else
                {
                    return new ObservableCollection<FinanceDTO>();
                }



            }

        }

    }
}
