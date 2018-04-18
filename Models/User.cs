using System;
using System.Collections.Generic;

namespace lost_found_api.Models{

    public class User{

        public int Id { get; set; }
        public string username { get; set; }
        public string emailaddr { get; set; }
        public string phonenum { get; set; }
        //public List<Item> Items { get; set; }
        public string password { get; set; }
    }
}