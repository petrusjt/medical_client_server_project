using System;
using System.Collections.Generic;
using System.Text;

namespace medical_common.Models
{
    public class Address
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public char StaircaseRef { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }

        public Address()
        {
        }

        public Address(string country, string region, string city, string street_name, int street_number, char staircase_ref=' ', int floor=0, int apartment_number=0)
        {
            Country = country;
            Region = region;
            City = city;
            StreetName = street_name;
            StreetNumber = street_number;
            StaircaseRef = staircase_ref;
            Floor = floor;
            ApartmentNumber = apartment_number;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return $"Address({Country}, {Region}, {City}, {StreetName}, {StreetNumber}, {StaircaseRef}, {Floor}, {ApartmentNumber})";
        }
    }
}
