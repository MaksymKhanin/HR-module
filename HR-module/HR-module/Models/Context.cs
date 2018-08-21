using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HR_module.Models
{
    public class Context:DbContext
        
    {
        public DbSet<Candidate> Candidates { get; set; }
        public Context() : base("LocalDb") { }
        static Context()
        {
            Database.SetInitializer<Context>(new DataBaseInitializer());
        }
        
    }
    public class DataBaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            Candidate c1 = new Candidate
            {
                Sirname = "Shapovalov",
                Name = "Sergey",
                Vacancy = ".Net",
                Experience = 3,
                PhoneNumber = "0509475634",
                Email = "candidate@gmail.com",
                Date1 = "14.08.18",
                Time1 = "11:00",
                Date2 = "17.08.18",
                Time2 = "12:00",
                Salary = 30000,
                Status = "offer job",
                Conclusion = "has experience with Oracle DataBases"
            };
            Candidate c2 = new Candidate
            {
                Sirname = "Kolesnikov",
                Name = "Anton",
                Vacancy = "Java",
                Experience = 5,
                PhoneNumber = "0509475634",
                Email = "candidate@gmail.com",
                Date1 = "14.08.18",
                Time1 = "11:00",
                Date2 = "17.08.18",
                Time2 = "12:00",
                Salary = 70000,
                Status = "offer job",
                Conclusion = "full stack developer"
            };
            Candidate c3 = new Candidate
            {
                Sirname = "Borodin",
                Name = "Denis",
                Vacancy = "Node.js",
                Experience = 4,
                PhoneNumber = "0509475634",
                Email = "candidate@gmail.com",
                Date1 = "14.08.18",
                Time1 = "11:00",
                Date2 = "17.08.18",
                Time2 = "12:00",
                Salary = 35000,
                Status = "offer job",
                Conclusion = "full stack developer"
            };
            db.Candidates.Add(c1);
            db.Candidates.Add(c2);
            db.Candidates.Add(c3);
            base.Seed(db);
        }
    }
}