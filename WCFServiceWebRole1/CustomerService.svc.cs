
/*
 * RestCustomerCloudService
 *
 * Author Michael Claudius, ZIBAT Computer Science
 * Version 1.0. 2016.04.12, 1.1 2016.04.15, 1.2 2016.11.01
 * Copyright 2015 by Michael Claudius
 * Revised 2016.11.10, 2017.10.31
 * All rights reserved
 */

//WebOperationContext ctx = WebOperationContext.Current;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceWebRole1.Model;
using System.Net;
using System.ServiceModel.Web;

//Statuscode coming with HttpResponse
//https://stackoverflow.com/questions/22164780/how-do-i-return-http-status-code-420-from-my-wcf-service

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {

        public static int nextId = 0;
        private static Customer c = new Customer("Michael", "Claudius", new MyDate(1961, 5, 15)); //OR from database..
        WebOperationContext webOpContext = WebOperationContext.Current;

        private static List<Customer> cList = new List<Customer>()
        {    new Customer("Michael", "Claudius", new MyDate(1961, 5, 15)),
             new Customer("Yulia", "Claudius", new MyDate(1978, 5, 15))
        };

        public void DoWork()
        {
        }
        
        public IList<Customer> GetCustomers()
        {
            return cList;
        }

       
        public Customer GetCustomer(string id)
        {
            webOpContext.OutgoingResponse.StatusCode = HttpStatusCode.OK;
            int idNumber = int.Parse(id);
            Customer c =  cList.FirstOrDefault(customer => customer.ID == idNumber);
            //Set statuscode of response
            if (c == null) webOpContext.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;

            //Alternatively 
            //if (c==null) webOpContext.OutgoingResponse.StatusCode = (System.Net.HttpStatusCode)404;
            //Any number can be used for tyupe casting, even customized numbers like 420

            return c;
        }

        public Customer DeleteCustomer(string id)  //HttpActionResult returns response status code
        {
            Customer c = GetCustomer(id);
            if (c == null) return null;
            cList.Remove(c);
            return c;

            //Delete seemed not to work so I tried
            //    int index = -1;
            //    int idNumber = int.Parse(id);
            //    for (int i = 0; i < cList.Count; i++) 

            //    {
            //        if (cList.ElementAt(i).ID == idNumber)
            //        {
            //            index = i;
            //        }
            //    }
            //    if (index == -1) return null;
            //    Customer c = cList.ElementAt(index);
            //    cList.RemoveAt(index);
            //    return c;

            //Also tried this
            //Customer c = GetCustomer(id);
            //if (c == null) return null;
            //int index = cList.IndexOf(c);
            //cList.RemoveAt(index);
            //if (c != null) cList.Remove(c);

            //PROBLEM CANNOT BE IN DELETE BUT WHERE....?
            //The problem was the print-out sentences in the client-code was not encapsulated in 
            //an asynchronous method.
            //A classic example of looking at the wrong place !!
        }
        public Customer GetCustomer1(int id)
        {
            return cList.FirstOrDefault(customer => customer.ID == id);
        }

        //public Customer DeleteCustomer1(int id)
        //{
        //    Customer c = GetCustomer1(id);
        //    if (c == null) return null;
        //    cList.Remove(c);
        //    return c;
        //}


        public Customer AddCustomer(Customer customer)
        {            
            customer.ID =  CustomerService.nextId++;
            cList.Add(customer);
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            string id = customer.ID.ToString();
            Customer oldCustomer = DeleteCustomer(id);
            if (oldCustomer != null)
            {
                customer.ID = oldCustomer.ID;
                cList.Add(customer);
            }

            return GetCustomer(id);
            //Alternatively fond index of customer and then make the changes
        }

    }
}
