using System.ComponentModel.DataAnnotations;

namespace CommsRoomInvent.Models.DataModels
{
    public class Rating
    {
        public int Id { get; set; }

        [Display(Name = "Rating")]
        public string RatingName { get; set; }
    }
}