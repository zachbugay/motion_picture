using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using server.Models;

namespace server.DTO {
    public class Payload {
        public List<MotionPicture>? MotionPictures { get; set; }
        public MotionPicture? MotionPicture { get; set; }
    }
}
