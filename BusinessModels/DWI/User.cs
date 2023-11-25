using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BusinessModels.DWI
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }
        public string IPAddress { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public bool IsLineOperator { get; set; }
        public bool IsADAccount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }
 
    }
}
