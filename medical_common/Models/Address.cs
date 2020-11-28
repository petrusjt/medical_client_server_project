using System;
using System.Collections.Generic;
using System.Text;

namespace medical_common.Models
{
    public class Address
    {
        private string _country { get; set; }
        private string _region { get; set; }
        private string _city { get; set; }
        private string _streetName { get; set; }
        private int _streetNumber { get; set; }
        private char _staircaseRef { get; set; }
        private int _floor { get; set; }
        private int _apartmentNumber { get; set; }

        public Address(string country, string region, string city, string street_name, int street_number, char staircase_ref=' ', int floor=0, int apartment_number=0)
        {
            _country = country;
            _region = region;
            _city = city;
            _streetName = street_name;
            _streetNumber = street_number;
            _staircaseRef = staircase_ref;
            _floor = floor;
            _apartmentNumber = apartment_number;
        }
    }
}
