using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dbContext;
        private static JobPostingDAO instance;
        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();
        }

        public JobPosting GetJobPosting(string id)
        {
            return dbContext.JobPostings.SingleOrDefault(a => a.PostingId.Equals(id));
        }
        
        public bool AddJobPostings(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            if(job == null)
            {
                dbContext.JobPostings.Add(jobPosting);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool DeleteJobPostings(string id)
        {
            bool isSuccess = false;
            JobPosting job = GetJobPosting(id);
            if( job != null)
            {
                dbContext.JobPostings.Remove(job);
                dbContext.SaveChanges() ;
                isSuccess = true;
            }
            return isSuccess ;
        }

        public bool UpdateJobPostings(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            if(job != null)
            {
                dbContext.Entry<JobPosting>(jobPosting).State 
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges() ;
                isSuccess = true;
            }
            return isSuccess ;
        }
    }
}
