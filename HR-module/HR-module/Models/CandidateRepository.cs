using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HR_module.Models
{
    public class CandidateRepository : IRepository<Candidate>
    {
        private Context db;

        public CandidateRepository(Context context)
        {
            this.db = context;
        }
        public IEnumerable<Candidate> GetItemsList(int id)
        {
            return db.Candidates;
        }

        public IEnumerable<Candidate> GetItemsList()
        {
            return db.Candidates;
        }

        public Candidate GetItem(int id)
        {
            return db.Candidates.Find(id);
        }

        public void Create(Candidate candidate)
        {
            db.Candidates.Add(candidate);
        }

        public void Update(Candidate candidate)
        {
            db.Entry(candidate).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate != null)
                db.Candidates.Remove(candidate);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}