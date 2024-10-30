using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repos
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public List<CandidateProfile> GetCandidates() => CandidateProfileDAO.Instance.GetCandidates();

        public CandidateProfile GetCandidateProfile(string id) => CandidateProfileDAO.Instance.GetCandidateProfile(id);

        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string id) => CandidateProfileDAO.Instance.DeleteCandidateProfile(id);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
    }
}
