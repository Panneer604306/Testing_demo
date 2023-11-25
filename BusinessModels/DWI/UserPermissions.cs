using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class UserPermissions
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string Mode { get; set; }
        public List<UserModulePermission> ObjLstUserModule { get; set; }
    }

    public class UserModulePermission
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleType { get; set; }
        public bool ModAdd { get; set; }
        public bool ModEdit { get; set; }
        public bool ModView { get; set; }
        public bool ModDelete { get; set; }


    }
}
