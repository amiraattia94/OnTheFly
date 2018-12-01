using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OnTheFlyWPFC.Model.DTO;

namespace OnTheFlyWPFC.Model.Service
{
    public class PayrollService
    {
        async public Task<bool> AddPayroll(int employeeID, int extra_work_days, decimal bonus, int extra_work_hours, decimal cash_advance, int late_hours, int absent_days, decimal total_deduction, decimal total_addition , decimal gross_salary, int payroll_month, int payroll_year, bool paid )
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.PayrollTBLs.Add(new PayrollTBL()
                    {
                        employeeID = employeeID,
                        extra_work_days = extra_work_days,
                        bonus = bonus,
                        extra_work_hours = extra_work_hours,
                        cash_advance = cash_advance,
                        late_hours = late_hours,
                        absent_days= absent_days,
                        total_deduction= total_deduction,
                        total_addition= total_addition,
                        gross_salary= gross_salary,
                        payroll_month= payroll_month,
                        payroll_year= payroll_year,
                        paid= paid                        
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

        async public Task<bool> EditPayrollByID(int payrollID, int employeeID, int extra_work_days, decimal bonus, int extra_work_hours, decimal cash_advance, int late_hours, int absent_days, decimal total_deduction, decimal total_addition, decimal gross_salary, int payroll_month, int payroll_year, bool paid)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.PayrollTBLs.SingleOrDefault(w => w.payrollID == payrollID);
                    if (result != null)
                    {

                        try
                        {
                            result.employeeID = employeeID;
                            result.extra_work_days = extra_work_days;
                            result.bonus = bonus;
                            result.extra_work_hours = extra_work_hours;
                            result.cash_advance = cash_advance;
                            result.late_hours = late_hours;
                            result.absent_days = absent_days;
                            result.total_deduction = total_deduction;
                            result.total_addition = total_addition;
                            result.gross_salary = gross_salary;
                            result.payroll_month = payroll_month;
                            result.payroll_year = payroll_year;
                            result.paid = paid;
                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {

                        }
                        return false;
                    }
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        async public Task<ObservableCollection<PayrollDTO>> GetAllPayroll()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid
                }).ToList();

                return new ObservableCollection<PayrollDTO>(result);
            }

        }
     
        async public Task<PayrollDTO> GetPayrollByID(int payrollID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.SingleOrDefault(w => w.payrollID == payrollID);

                if (result != null)
                {
                    return new PayrollDTO()
                    {
                        payrollID = result.payrollID,
                        employeeID = result.employeeID,
                        extra_work_days = result.extra_work_days,
                        bonus = result.bonus,
                        extra_work_hours = result.extra_work_hours,
                        cash_advance = result.cash_advance,
                        late_hours = result.late_hours,
                        absent_days = result.absent_days,
                        total_deduction = result.total_deduction,
                        total_addition = result.total_addition,
                        gross_salary = result.gross_salary,
                        payroll_month = result.payroll_month,
                        payroll_year = result.payroll_year,
                        paid = result.paid

                };
                };

                return new PayrollDTO()
                {
                    employeeID = 0,
                    extra_work_days = 0,
                    bonus = 0,
                    extra_work_hours = 0,
                    cash_advance = 0,
                    late_hours = 0,
                    absent_days = 0,
                    total_deduction =0,
                    total_addition = 0,
                    gross_salary = 0,
                    payroll_month = 0,
                    payroll_year = 0,
                    paid = false
                };
            }
        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByEmployeeID(int employeeID)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.PayrollTBLs.Where(w => w.employeeID == employeeID).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid

                }).ToList();


                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }
            }
        }
        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByEmployeeIDs(int[] employeeIDs)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.PayrollTBLs.Where(w => employeeIDs.Contains(w.employeeID)).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid

                }).ToList();


                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }
            }
        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByPaid(bool paid)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.PayrollTBLs.Where(w => w.paid == paid).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid

                }).ToList();


                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }
            }
        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByMonthAndYear(int month, int year)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.Where(w => w.payroll_month == month && w.payroll_year == year).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }



            }

        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByMonth(int month)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.Where(w => w.payroll_month == month).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }



            }

        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByYear(int year)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.Where(w => w.payroll_year == year).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }



            }

        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByBonus(decimal bonus)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.Where(w => w.bonus == bonus).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }



            }

        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByCashAdvance(decimal cash_advance)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.Where(w => w.cash_advance == cash_advance).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }



            }

        }

        async public Task<ObservableCollection<PayrollDTO>> GetPayrollByAbsentDays(decimal absent_days)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.PayrollTBLs.Where(w => w.absent_days == absent_days).Select(s => new PayrollDTO()
                {
                    payrollID = s.payrollID,
                    employeeID = s.employeeID,
                    extra_work_days = s.extra_work_days,
                    bonus = s.bonus,
                    extra_work_hours = s.extra_work_hours,
                    cash_advance = s.cash_advance,
                    late_hours = s.late_hours,
                    absent_days = s.absent_days,
                    total_deduction = s.total_deduction,
                    total_addition = s.total_addition,
                    gross_salary = s.gross_salary,
                    payroll_month = s.payroll_month,
                    payroll_year = s.payroll_year,
                    paid = s.paid
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<PayrollDTO>(result);
                }
                else
                {
                    return new ObservableCollection<PayrollDTO>();
                }



            }

        }

    }
}
