using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class DigitalRty
    {
        public int Id { get; set; }
        public string RtyStatus { get; set; }
        public DateTime MonthAndYear { get; set; }
        public Calculation Calculation { get; set; }
        public AssemblyCal AssemblyCal { get; set; }
        public DebugCal DebugCal { get; set; }
        public PackingCal PackingCal { get; set; }
        public Percentage PercentageCal { get; set; }
    }
}



public class Calculation
{
    public int Assembly { get; set; }
    public int Debug { get; set; }
    public int Packing { get; set; }

}

public class AssemblyCal
{
    public int Total { get; set; }
    public int OneHrBelow { get; set; }
    public int OneHrAbove { get; set; }
    public int WIP { get; set; }
    public string Status { get; set; }
}

public class DebugCal
{
    public int Total { get; set; }
    public int OneHrBelow { get; set; }
    public int OneHrAbove { get; set; }
    public int WIP { get; set; }
    public string Status { get; set; }
}

public class PackingCal
{
    public int Total { get; set; }
    public int OneHrBelow { get; set; }
    public int OneHrAbove { get; set; }
    public int WIP { get; set; }
    public string Status { get; set; }
}

public class Percentage
{
    public int AssemblyPercentage { get; set; }
    public int DebugPercentage { get; set; }
    public int PackingPercentage { get; set; }
}
