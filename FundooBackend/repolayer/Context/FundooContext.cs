using Microsoft.EntityFrameworkCore;
using repolayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace repolayer.Context
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }
        //public DbSet<User> UserTable { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NoteEntity> NotesTable { get; set; }
        public DbSet<CollaboratorEntity> CollaboratorsTable { get; set; }
        public DbSet<LabelEntity> Labels { get; set; }

    }
}
