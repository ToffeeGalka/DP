﻿namespace Business.Models
{
    public class DispReg
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public DateOnly DateTaken { get; set; }
        public int IdICD { get; set; }
        public int IdDoctor { get; set; }
        public DateOnly? DateNotTaken { get; set; }
        public int? IdReason { get; set; }
        public string? ICDCodeName { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public string? ReasonName { get; set; }
    }
}
