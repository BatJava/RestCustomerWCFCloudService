using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WCFServiceWebRole1.Model;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        // http://restcustomerwebservice.azurewebsites.net/CustomerService.svc/customers
        //http://localhost:49972/CustomerService.svc/customers
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "customers/")]
        IList<Customer> GetCustomers();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "customers/{id}")]
        Customer GetCustomer(string id);
        // UriTemplate = "customers/{*id}"  UriTemplate = "customers/name={id:int}" only works in asp.net

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "customers1/{id:int}")]
        //Customer GetCustomer1(int id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "customers/{id}")]
        Customer DeleteCustomer(string id);

        //Alternatively
        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //   // RequestFormat = WebMessageFormat.Json, 
        //   ResponseFormat = WebMessageFormat.Json,
        //   BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "customers1/{id:int}")]
        //Customer DeleteCustomer1(int id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "customers/")]
        Customer AddCustomer(Customer customer);

             [OperationContract]
        [WebInvoke(Method = "PUT",
           
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "customers/")]
         Customer UpdateCustomer(Customer customer);
      
    }
}
