using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Models {
    public class MotionPicture {
        
        [Required]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Name of the motion picture is required.")]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Year the motion picture was released is required.")]
        public int ReleaseYear{ get; set; }
    }
}
