using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMedTracker.Repository.EFModels
{
    [Keyless]
    public class TrialDataNetRow
    {
        public int DrugID { get; set; } 
        public int TrialDescID { get; set; }
        public int TrialDataID { get; set; }
        public string Description { get; set; }
        public int EffectID { get; set; }
        public int EndpointID { get; set; }
        public int MeasureTypeID { get; set; }
        public double Grp1Measure { get; set; } 
        public string Grp1Sign { get; set; }
        public double Grp1PValue { get; set; }
        public double Grp1MeasureValue { get; set; }
        public double Grp2Measure { get; set; }
        public string Grp2Sign { get; set; }
        public double Grp2PValue { get; set; }
        public double Grp2MeasureValue { get; set; }
        public double Grp3Measure { get; set; }
        public string Grp3Sign { get; set; }
        public double Grp3PValue { get; set; }
        public double Grp3MeasureValue { get; set; }
        public double Grp4Measure { get; set; }
        public string Grp4Sign { get; set; }
        public double Grp4PValue { get; set; }
        public double Grp4MeasureValue { get; set; }
        public double Grp5Measure { get; set; }
        public string Grp5Sign { get; set; }
        public double Grp5PValue { get; set; }
        public double Grp5MeasureValue { get; set; }
        public double Grp6Measure { get; set; }
        public string Grp6Sign { get; set; }
        public double Grp6PValue { get; set; }
        public double Grp6MeasureValue { get; set; }
        public int SortOrder { get; set; }
    }
}
