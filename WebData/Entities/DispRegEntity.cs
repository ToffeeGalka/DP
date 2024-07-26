using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData.Entities
{
    public class DispRegEntity
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public DateOnly DateTaken { get; set; }
        public int IdICD { get; set; }
        public int IdDoctor { get; set; }
        public DateOnly? DateNotTaken { get; set; }
        public int? IdReason { get; set; }
        public PatientEntity Patient { get; set; }
        public ICDEntity ICD { get; set; }
        public DoctorEntity Doctor { get; set; }
        public ReasonEntity Reason { get; set; }

    }
}
