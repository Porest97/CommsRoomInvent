using System.ComponentModel.DataAnnotations;

namespace CommsRoomInvent.Models.DataModels
{
    public class PersonRole
    {
        public int Id { get; set; }

        [Display(Name = "Role")]
        public string PersonRoleName { get; set; }
    }
}