using System;
using System.Collections.Generic;
using System.Text;

namespace medical_common.Models
{
    public class Address : IEquatable<Address>
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

        public Address(string country, string region, string city, string street_name, int street_number, char staircase_ref=' ', int floor=-1, int apartment_number=0)
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



        public override string ToString()
        {
            return $"Address({Country}, {Region}, {City}, {StreetName}, {StreetNumber}, {StaircaseRef}, {Floor}, {ApartmentNumber})";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }

        public bool Equals(Address other)
        {
            return other != null &&
                   Country == other.Country &&
                   Region == other.Region &&
                   City == other.City &&
                   StreetName == other.StreetName &&
                   StreetNumber == other.StreetNumber &&
                   StaircaseRef == other.StaircaseRef &&
                   Floor == other.Floor &&
                   ApartmentNumber == other.ApartmentNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = -1955026388;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StreetName);
            hashCode = hashCode * -1521134295 + StreetNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + StaircaseRef.GetHashCode();
            hashCode = hashCode * -1521134295 + Floor.GetHashCode();
            hashCode = hashCode * -1521134295 + ApartmentNumber.GetHashCode();
            return hashCode;
        }
    }
}
