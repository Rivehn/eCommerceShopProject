using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.ScenarioObjects
{
    public class Customer
    {
        //Customer Fields
        string firstname = "Peter";
        string lastname = "Deng";
        string company = "nFocus";
        string addressOne = "Building 36";
        string addressTwo = "University Rd";
        string city = "Southampton";
        string state = "Hampshire";
        string postcode = "SO17 1BJ";
        string phone = "02380592180";
        string email = "peter.deng@nfocus.co.uk";
        public string GetFirstName() { return firstname; }
        public string GetLastName() { return lastname; }
        public string GetCompany() { return company; }
        public string GetAddressOne() { return addressOne; }
        public string GetAddressTwo() { return addressTwo; }
        public string GetCity() { return city; }
        public string GetState() { return state; }
        public string GetPostCode() { return postcode; }
        public string GetPhone() { return phone; }
        public string GetEmail() { return email; }
    }
}
