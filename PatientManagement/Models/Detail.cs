using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;

namespace PatientManagement.Models;

public partial class Detail
{
    public int PatientId { get; set; }

    public string? PatientName { get; set; }

    public string? Symptoms { get; set; }

    public DateTime? AdmittedDate { get; set; }

    public string? MedicalTest { get; set; }

    public DateTime? DischargedDate { get; set; }

    public string? Address { get; set; }

    public string? MblNo { get; set; }
}
