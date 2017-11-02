using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceWebRole1.Model
{
    public class Customer1
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int ID { get; set; }

        public MyDate DateOfBirth { get; set; }


        public Customer1()
        { //Start data generation

        }
        public Customer1(String firstName)
        { this.FirstName = firstName; }

        public Customer1(String firstName, String lastName, MyDate date)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = date;
        }

    }
}