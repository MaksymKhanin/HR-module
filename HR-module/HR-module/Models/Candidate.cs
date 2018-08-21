using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_module.Models
{
    public class Candidate
    {
        public Int32 CandidateId { get; set; }
        public string Sirname { get; set; }
        public string Name { get; set; }
        public string Vacancy { get; set; }
        public Single Experience { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Date1 { get; set; }
        public string Time1 { get; set; }
        public string Date2 { get; set; }
        public string Time2 { get; set; }
        public Int32 Salary { get; set; }
        public string Status { get; set; }
        public string Conclusion { get; set; }
    }
}