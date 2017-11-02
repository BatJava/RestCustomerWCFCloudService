using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace WCFServiceWebRole1.Model
{

    //Datacontract not necessary as we are using JSON
    //Why use a Datacontract ?
    //https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/data-member-order
    //How to order data member?
    //https://stackoverflow.com/questions/4836683/when-to-use-datacontract-and-datamember-attributes

    [DataContract]
    public class Customer
    {
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public MyDate DateOfBirth { get; set; }


        public Customer()
        { //Start data generation

        }

        public Customer(String firstName)
        { this.ID = CustomerService.nextId++;
            this.FirstName = firstName; }

        public Customer(String firstName, String lastName, MyDate date)
        {
            this.ID = CustomerService.nextId++; //I also have this in AddCustomer, dont have it two times
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = date;
        }



    }
}