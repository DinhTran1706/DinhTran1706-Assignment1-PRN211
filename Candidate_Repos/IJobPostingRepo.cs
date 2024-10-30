using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repos
{
    public interface IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPosting(string id);
        public bool AddJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(string id);
        public bool UpdateJobPosting(JobPosting jobPosting);
    }
}
