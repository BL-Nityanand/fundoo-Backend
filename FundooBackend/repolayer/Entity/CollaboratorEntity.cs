using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace repolayer.Entity
{
    public class CollaboratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long collabId { get; set; }

        public string email { get; set; }

        [ForeignKey("users"), Column(Order = 0)]
        public long userid { get; set; }
        [JsonIgnore]
        public virtual UserEntity users { get; set; }

        [ForeignKey("note"), Column(Order = 1)]
        public long noteid { get; set; }
        [JsonIgnore]
        public virtual NoteEntity note { get; set; }

        
    }
}
