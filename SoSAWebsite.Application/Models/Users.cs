using System;
using System.Collections.Generic;

namespace Models
{

    public class User
    {
        public String id { get; set; }
        public String displayName { get; set; }
        public DateTime graduationDate { get; set; }
        public UserPermissions permissions { get; set; }
    }

}