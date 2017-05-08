using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Futsal_1.Models;

namespace Futsal_1.Context
{
    /// <summary>
    /// Class FutsalContext
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class FutsalContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Arbiter> Arbiters { get; set; }
    }
}