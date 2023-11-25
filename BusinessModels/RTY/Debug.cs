using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.RTY
{
    public class DebugFailure 
    {
        public int Id { get; set; }
        public string UWIP { get; set; }
        public string MTM { get; set; }
        public string SerialNo { get; set; }
        public string Product { get; set; }
        public string Series { get; set; }
        public string LineNo { get; set; }
        public string Stage { get; set; }
        public string PartName { get; set; }
        public string ProblemType { get; set; }
        public string ProblemClass { get; set; }
        public string Problem { get; set; }
        public string OtherProblem { get; set; }
        public IFormFile ProblemPic { get; set; }
        public int RtyId { get; set; }
        public string LogicalFileName { get; set; }
        public string PhysicalFileName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Owners { get; set; }


    }

      public class DebugSolution
    {
        public int Id { get; set; }
        public string UWIP { get; set; }
        public string MTM { get; set; }
        public string SerialNo { get; set; }
        public string Product { get; set; }
        public string Series { get; set; }
        public string LineNo { get; set; }
        public string Stage { get; set; }
        public string PartName { get; set; }
        public string SolutionType { get; set; }
        public string SolutionClass { get; set; }
        public string Solution { get; set; }
        public string OtherSolution { get; set; }
        public IFormFile SolutionPic { get; set; }
        public int RtyId { get; set; }
        public string LogicalFileName { get; set; }
        public string PhysicalFileName { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Owners { get; set; }
    }
}
