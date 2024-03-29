﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;

namespace OnTheFlyWPFC.Model.Service
{
    public class JobsService
    {
        async public Task<ObservableCollection<JobsDTO>> GetAllJobs()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<JobsDTO> result = con.JobsTBLs.Select(s => new JobsDTO()
                {
                    job_name = s.job_name,
                    basic_salary = (Double)s.basic_salary,
                    working_days_per_month = s.working_days_per_month?? 0

                }).ToList();

                return new ObservableCollection<JobsDTO>(result);
            }
        }
        async public Task<bool> AddJob(string jobname, double basic_salary, int working_days_per_month)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.JobsTBLs.Add(new JobsTBL()
                    {
                        job_name= jobname,
                        basic_salary= basic_salary,
                        working_days_per_month= working_days_per_month
                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message,"");
            }
            return false;
        }

        async public Task<JobsDTO> GetJobByID(int jobID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.JobsTBLs.SingleOrDefault(w => w.jobID == jobID);

                if (result != null)
                {
                    return new JobsDTO()
                    {
                        jobID = result.jobID,
                        job_name = result.job_name,
                        basic_salary = result.basic_salary??0,
                        working_days_per_month = result.working_days_per_month??0
                    };
                };

                return new JobsDTO()
                {
                    jobID = 0,
                    job_name = "",
                    basic_salary = 0,
                    working_days_per_month =  0

                };



            }

        }
        async public Task<bool> EditJobByID(int jobID, string job_name, int basic_salary, int working_hours_per_month)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.JobsTBLs.SingleOrDefault(w => w.jobID == jobID);
                    if (Result != null)
                    {

                        try
                        {
                            Result.job_name = job_name;
                            Result.basic_salary = basic_salary;
                            Result.working_days_per_month = working_hours_per_month;
                            

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

        async public Task<bool> DeleteJobByID(int jobID)
        {
            await Task.FromResult(true);

            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.JobsTBLs.SingleOrDefault(w => w.jobID == jobID);

                    if (result != null)
                    {
                        con.JobsTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch
            {

            }

            return false;

        }
    }
}
