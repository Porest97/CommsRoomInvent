using System.ComponentModel.DataAnnotations;

namespace CommsRoomInvent.Models.DataModels
{
    public class PersonType
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string PersonTypeName { get; set; }
    }
}