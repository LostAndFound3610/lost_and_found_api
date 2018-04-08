using System;
using System.Collections.Generic;

namespace lost_found_api.Models{

    public class User{

        public int Id { get; set; }
        public string User_Name { get; set; }
        public string Email_Addr { get; set; }
        public string Phone_Num { get; set; }
        public List<Item> Items { get; set; }
    }
}