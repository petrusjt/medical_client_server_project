using System;
using System.Collections.Generic;
using System.Text;

namespace medical_common.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        // TAJ: Hungarian social security number
        public string TAJ { get; set; }
        public string Problem { get; set; }
        public DateTime TimeRegistered { get; set; }

        public Patient(string name, Address address, string TAJ, string problem)
        {
            Name = name;
            Address = address;
            this.TAJ = TAJ;
            Problem = problem;
            TimeRegistered = DateTime.Now;
        }

        public Patient(string name, Address address, string TAJ, string problem, DateTime timeRegistered) : this(name, address, TAJ, problem)
        {
            TimeRegistered = timeRegistered;
        }
    }
}
