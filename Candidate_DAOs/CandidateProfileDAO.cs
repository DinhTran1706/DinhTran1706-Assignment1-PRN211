using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbContext;
        private static CandidateProfileDAO instance;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CandidateProfileDAO();
                return instance;
            }
        }

        public CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public List<CandidateProfile> GetCandidates()
        {
            //return dbContext.CandidateProfiles.ToList();
            return dbContext.CandidateProfiles.AsNoTracking().Include(u => u.Posting).ToList();
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return dbContext.CandidateProfiles.AsNoTracking()
                .SingleOrDefault(m=>m.CandidateId.Equals(id));
        }
        
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate == null)
            {
                dbContext.CandidateProfiles.Add(candidateProfile);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool DeleteCandidateProfile(string id)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(id);
            if(candidate != null)
            {
                dbContext.CandidateProfiles.Remove(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            using var context = new CandidateManagementContext();
            CandidateProfile candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if(candidate != null)
            {
                context.Entry<CandidateProfile>(candidateProfile).State = 
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
