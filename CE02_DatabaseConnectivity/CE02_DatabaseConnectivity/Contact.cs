using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CE02_DatabaseConnectivity
{
    public class Contact
    {

        int contactId;
        string firstName;
        string lastName;
        string phoneNumber;
        string emailAddress;
        string relationship;
        int relationshipIndex;

        public int ContactId { get => contactId; set => contactId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public string Relationship { get => relationship; set => relationship = value; }
        public int RelationshipIndex { get => relationshipIndex; set => relationshipIndex = value; }


        public override string ToString()  {
            return $"{firstName} {lastName}";
        }

        //Text file string for saving to print
        public string SaveOutput() {
            return $"First Name: {firstName}\r\nLast Name: {lastName}\r\nPhone Number: {phoneNumber}\r\nEmail: {emailAddress}\r\nRelationship: {relationship}";
        }

        //Validate Email Address
        public static bool validateEmail(string emailAddress) {
            return Regex.IsMatch (emailAddress, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase);
        }

        //Validate Phone Number
        public static bool validatePhone(string phoneNum) {
            return Regex.IsMatch(phoneNum, @"^\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}$", RegexOptions.IgnoreCase);
        }
    }
}
