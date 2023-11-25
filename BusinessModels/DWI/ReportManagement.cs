using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.RTY
{
    public class ReportManagement
    {
        public int Total { get; set; }
        public int Assembly { get; set; }
        public int Debug { get; set; }
        public int Packing { get; set; }
        public int Assembly_Failure { get; set; }
        public int Debug_Failure { get; set; }
        public int Packing_Failure { get; set; }
        public int Open { get; set; }
        public int Close { get; set; }        
        public List<report> report { get; set; }
    }


    public class report
    {
        public int Id { get; set; }
        public string UWIP { get; set; }
        public string MT { get; set; }
        public string MTM { get; set; }
        public string SerialNo { get; set; }
        public string Series { get; set; }
        public string LineNo { get; set; }
        public string PartName { get; set; }
        public string ProblemType { get; set; }
        public string ProblemClass { get; set; }
        public string SolutionClass { get; set; }
        public string ProblemPic { get; set; }
        public string ProblemPicPath { get; set; }
        public string SolutionPic { get; set; }
        public string SolutionPicPath { get; set; }
        public string Solution { get; set; }
        public string Problem { get; set; }
        public string Status { get; set; }
        public string OverAllStatus { get; set; }
        public string OtherProblem { get; set; }
        public string OtherSolution { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string UserName { get; set; }
        public int? RowNumber { get; set; }
        public string Owners { get; set; }
    }



    public class GetByFilter
    {
        public int PageIn { get; set; }
        public int PageSize { get; set; }
        public string Fromdate { get; set; }
        public string ToDate { get; set; }
        public string MTM { get; set; }
        public string Series { get; set; }
        public string location { get; set; }
        public string rtyStatus { get; set; }
    }
}
