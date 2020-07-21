using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CustomerInfo.DTO.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        //public Customer(int id, string firstName, string lastName, DateTime dob)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    DateOfBirth = dob;
        //}
    }
}
