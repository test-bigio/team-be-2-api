using System;
using System.Collections.Generic;
using System.Text;

namespace BigioHrServices.Constant
{
    public static class AuditLogConstant
    {
        //Module Names
        public const string Employee = "Employee";
        public const string Position = "Posisi";
        public const string DelegationMatrix = "Delegation Matrix";
        public const string Leave = "Leave";
        public const string HistoryDigitalSignature = "History Digital Signature";

        //Action Names
        public const string Create = "Create";
        public const string List = "List";
        public const string GetDetail = "Detail";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string Approve = "Approve";
        public const string Reject = "Reject";
        public const string Deactivate = "Deactivate";

        //Detail Templates
        public const string Detail = "{0} data {1} was {2} by {3} at {4}";
    }
}
