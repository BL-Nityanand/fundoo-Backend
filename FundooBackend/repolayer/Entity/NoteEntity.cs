using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace repolayer.Entity
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long noteid { get; set; }

        public string title { get; set; }
        public string description { get; set; }

        public DateTime reminder { get; set; }

        public string color { get; set; }

        public string image { get; set; }

        public bool isArchived { get; set; }
        public bool isPinned { get; set; }
        public bool isDeleted { get; set; }

        public DateTime? createdAt { get; set; } //nullable

        public DateTime? editedAt { get; set; } 

        [ForeignKey("user")]
        public long userid { get; set; }
        public virtual UserEntity user { get; set; }


    }
}
