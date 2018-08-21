using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HR_module.Models;

namespace HR_module.Controllers
{
    public class CandidatesController : ApiController
    {
        private readonly IRepository<Candidate> db1;

        public CandidatesController(IRepository<Candidate>r1)
        {
            db1 = r1;
        }
        public CandidatesController()
        {

        }

        [HttpGet]
        public IEnumerable<Candidate> GetCandidates()
        {
            List<Candidate> candidates = new List<Candidate>();
            var candidatesList = db1.GetItemsList();
            foreach (var person in candidatesList)
            {
                var candidate = new Candidate
                {
                    CandidateId = person.CandidateId,
                    Sirname = person.Sirname,
                    Name = person.Name,
                    Vacancy = person.Vacancy,
                    Experience = person.Experience,
                    PhoneNumber = person.PhoneNumber,
                    Email = person.Email,
                    Date1 = person.Date1,
                    Time1 = person.Time1,
                    Date2 = person.Date2,
                    Time2 = person.Time2,
                    Salary = person.Salary,
                    Status = person.Status,
                    Conclusion = person.Conclusion
                };
                candidates.Add(candidate);
            }
            return candidates;
        }

        [HttpGet]
        public Candidate GetCandidate(int id)
        {
            Candidate candidate = db1.GetItem(id);
            return candidate;
        }

        [HttpPost]
        public void PostCandidate(Candidate candidate)
        {
            db1.Create(candidate);
            db1.Save();
        }

        [HttpPut]
        public void PutCandidate(Candidate candidate)
        {
            if (candidate != null && ModelState.IsValid)
            {
                if (candidate.CandidateId != 0)
                {
                    db1.Update(candidate);

                    db1.Save();
                }
            }

        }

        [HttpDelete]
        public void DeleteCandidate(Candidate candidate)
        {
            db1.Delete(candidate.CandidateId);
            db1.Save();
        }
        protected override void Dispose(bool disposing)
        {
            db1.Dispose();
            base.Dispose(disposing);
        }
    }
}
