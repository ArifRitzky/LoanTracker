using System;
using System.Collections.Generic;

namespace LoanTracker.Models;

public partial class LoanApplication
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public decimal Amount { get; set; }

    public int TenorMonths { get; set; }

    public decimal InterestRatePercent { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
