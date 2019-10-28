using System.ComponentModel.DataAnnotations;

namespace CommsRoomInvent.Models.DataModels
{
    public class PersonStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string PersonStatusName { get; set; }
    }
}