//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels
{
    public class Login
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long PhoneNo { get; set; }
        public string AuthToken { get; set; }
        public string RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string MachineIP { get; set; }
        public bool IsLineOperator { get; set; }
        public List<ListRoleAccess> ListRoleAccess { get; set; }


    }

    public class ListRoleAccess
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool ModAdd { get; set; }
        public bool ModEdit { get; set; }
        public bool ModView { get; set; }
        public bool ModDelete { get; set; }


    }




    #region  public class FacilityLogin
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }


    }
    #endregion


}
