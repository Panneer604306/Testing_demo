using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.COM
{
    public class Common
    {

    }

    public class GetUserPermissions
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string Mode { get; set; }
        public List<GetUserModulePermission> ObjLstUserModule { get; set; }
    }

    public class GetUserModulePermission
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleType { get; set; }
        public bool ModAdd { get; set; }
        public bool ModEdit { get; set; }
        public bool ModView { get; set; }
        public bool ModDelete { get; set; }
    }

    public class AllSeries
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class MTBySeries
    {
        public int Id { get; set; }
        public string MT { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class CountStatus
    {
        public int Total { get; set; }
        public int Assembly { get; set; }
        public int Debug { get; set; }
        public int Packing { get; set; }
        public int AssemblyFailure { get; set; }
        public int DebugFailure { get; set; }
        public int PackingFailure { get; set; }
        public int AssemblySolution { get; set; }
        public int DebugSolution { get; set; }
        public int PackingSolution { get; set; }
        public int Open { get; set; }
        public int Close { get; set; }
    }

    public class ClienDisplaytList
    {
        public string Tiny { get; set; }
        public string Display { get; set; }
        public string TinyDisplay { get; set; }
    }

    public class GetRoles
    {
        public int Id { get; set; }
        public string Roles { get; set; }
    }
    public class GetPartList
    {
        public int Id { get; set; }
        public string PartName { get; set; }
    }
    public class GetPartByProduct
    {
        public string Product { get; set; }
        public string PartName { get; set; }
    }

    public class GetRTYProductId
    {
        public string Product { get; set; }
        public string Series { get; set; }
    }

    public class GetAllSatge
    {
        public string IPAddress { get; set; }
        public string Stage { get; set; }
        public string ConfIPAddress { get; set; }
        public string ConfStage { get; set; }
    }
    public class GetProblemClassList
    {
        public int Id { get; set; }
        public string ProblemType { get; set; }
        public string ProblemCls { get; set; }
    }
    public class GetProblemTypeList
    {
        public int Id { get; set; }
        public int PartName { get; set; }
        public string ProblemTypes { get; set; }
    }

    public class GetSolutionTypeList
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public string SolutionTypes { get; set; }
    }

    public class GetSolutionClassList
    {
        public int Id { get; set; }
        public string SolutionType { get; set; }
        public string SolutionCls { get; set; }
    }

    public class GetOwnersList
    {
        public int Id { get; set; }
        public string UWIP { get; set; }
        public string Rty_Status { get; set; }
        public string Owners { get; set; }
    }
}
