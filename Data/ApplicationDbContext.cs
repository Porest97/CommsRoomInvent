using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CommsRoomInvent.Models.DataModels;

namespace CommsRoomInvent.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CommsRoomInvent.Models.DataModels.Company> Company { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.CRoomReport> CRoomReport { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.Person> Person { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.PersonRole> PersonRole { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.PersonStatus> PersonStatus { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.PersonType> PersonType { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.Rating> Rating { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.ReportStatus> ReportStatus { get; set; }
        public DbSet<CommsRoomInvent.Models.DataModels.Site> Site { get; set; }
    }
}
