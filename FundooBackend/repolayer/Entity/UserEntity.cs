using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace repolayer.Entity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public long userid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
      
        public string email { get; set; }
        public string password { get; set; }


        
    }


}
