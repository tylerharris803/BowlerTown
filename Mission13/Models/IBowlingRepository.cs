using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }
    }
}
