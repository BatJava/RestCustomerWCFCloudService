using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFServiceWebRole1;
using WCFServiceWebRole1.Model;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICustomerService customerService = new CustomerService();
            IList<Customer> customers = customerService.GetCustomers();
            Assert.AreEqual(2, customers.Count);

            Customer c = customerService.GetCustomer("1");
            Assert.AreEqual("Michael",c.FirstName );

            MyDate date = new MyDate(1808,8,8);

            Customer newCustomer = new Customer("H.C.", "Andersen", date);
            customerService.AddCustomer(newCustomer);
            c = customerService.GetCustomer("2");           
            Assert.AreEqual("Andersen", c.LastName);








        }
    }
}
