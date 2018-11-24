using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System.Collections.ObjectModel;

namespace OnTheFlyWPFC.ViewModel
{
    public class JobsViewModel
    {
        JobsService _jobsService;
        public ObservableCollection<JobsDTO> ViewJob { get; set; }
        public JobsDTO EditJob { get;
            set; }
        public JobsViewModel()
        {
            _jobsService = new JobsService();
            ViewJob = new ObservableCollection<JobsDTO>();
            EditJob = new JobsDTO();

            getAllJobs();
        }
        async public void getAllJobs()
        {
            ViewJob = await _jobsService.GetAllJobs();
        }
        async public Task<bool> AddJob(string job_name, double basic_salary, int working_days_per_month)
        {
            return await _jobsService.AddJob(job_name, basic_salary, working_days_per_month);
        }
        async public void GetJobByID(int jobID)
        {

            EditJob = await _jobsService.GetJobByID(jobID);
        }

        async public Task<bool> EditJobByID(int jobID, string job_name, int basic_salary, int working_days_per_month)
        {
            return await _jobsService.EditJobByID(jobID, job_name, basic_salary, working_days_per_month);
        }

        async public Task<bool> DeleteJobByID(int jobID)
        {
            return await _jobsService.DeleteJobByID(jobID);
        }

    }
}
