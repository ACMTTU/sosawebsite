using System;
using System.Collections.Generic;

namespace Models
{

    public class Project
    {

        public String id { get; set; }
        public String name { get; set; }
        public String extendedDescription { get; set; }
        public String description { get; set; }
        public String projectOwner { get; set; }
        public Boolean isNewProject { get; set; }
        public String imageSource { get; set; }
        public String proposalSource { get; set; }
    }
}