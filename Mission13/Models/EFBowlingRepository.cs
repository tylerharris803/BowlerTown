using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Models
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFBowlingRepository (BowlersDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
    }
}
