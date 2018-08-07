using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExamAspNabilBouna.Models
{
    public class BDMembres : DbContext
    {
        public DbSet<User> user { get; set; }
    }
}