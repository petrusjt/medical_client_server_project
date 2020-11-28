using System;
using System.Collections.Generic;
using System.Text;

namespace medical_common.Models
{
    public class Patient
    {
        private string _name { get; set; }
        private Address _address { get; set; }
        // TAJ: Hungarian social security number
        private string _TAJ { get; set; }
        private string _problem { get; set; }
        private DateTime _timeRegistered { get; set; }

        public Patient(string name, Address address, string TAJ, string problem)
        {
            _name = name;
            _address = address;
            _TAJ = TAJ;
            _problem = problem;
            _timeRegistered = DateTime.Now;
        }

        public Patient(string name, Address address, string TAJ, string problem, DateTime timeRegistered) : this(name, address, TAJ, problem)
        {
            _timeRegistered = timeRegistered;
        }
    }
}
