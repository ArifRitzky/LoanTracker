using System;
using System.Collections.Generic;

namespace LoanTracker.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Nik { get; set; } = null!;

    public decimal Income { get; set; }

    public virtual ICollection<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();
}
