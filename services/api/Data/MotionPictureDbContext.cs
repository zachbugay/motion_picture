using Microsoft.EntityFrameworkCore;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data {
    public class MotionPictureDbContext : DbContext {

        public MotionPictureDbContext(DbContextOptions<MotionPictureDbContext> options) : base(options) {
        }

        public DbSet<MotionPicture> MotionPictures { get; set; }
    }
}
