using System.ComponentModel.DataAnnotations;

namespace CommsRoomInvent.Models.DataModels
{
    public class ReportStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string ReportStatusName { get; set; }
    }
}