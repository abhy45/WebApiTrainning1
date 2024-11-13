﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourthExample_Customization.Models
{
    public class BlogPost
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public bool Published { get; set; }
    }
    public class Blog
    {
        public string  Name { get; set; }
        public string Description { get; set; }

        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
