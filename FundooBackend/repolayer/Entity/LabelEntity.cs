using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace repolayer.Entity
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long labelID { get; set; }

        public string label { get; set; }

        [ForeignKey("user")]
        public long userid { get; set; }
        [JsonIgnore]
        public virtual UserEntity user { get; set; }

        [ForeignKey("note")]
        public long noteid { get; set; }
        [JsonIgnore]
        public virtual NoteEntity note { get; set; }

        
    }
}
