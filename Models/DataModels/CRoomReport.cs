using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommsRoomInvent.Models.DataModels
{
    public class CRoomReport
    {
        public int Id { get; set; }

        public int? ReportStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReportStatusId")]
        public ReportStatus ReportStatus { get; set; }

        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        public int? RatingId { get; set; }
        [Display(Name = "Rating")]
        [ForeignKey("RatingId")]
        public Rating Rating { get; set; }

        public int? PersonId { get; set; }
        [Display(Name = "Preformed By")]
        [ForeignKey("PersonId")]
        public Person PreformedBy { get; set; }

        [Display(Name = "Scheduled")]
        public DateTime? DateTimeScheduled { get; set; }

        [Display(Name = "Started")]
        public DateTime? DateTimeStarted { get; set; }
        [Display(Name = "Ended")]
        public DateTime? DateTimeEnded { get; set; }
        [Display(Name = "# Of Floors")]
        public int? NumberOfFloors { get; set; }
        [Display(Name = "# Of Commsrooms")]
        public int? NumberOfCRs { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Special considirations")]
        public string SpecialConsiderations { get; set; }
    }
}
