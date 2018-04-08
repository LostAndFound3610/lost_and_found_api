using System;

namespace lost_found_api.Models{

    public class Item{

        public int Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string School { get; set; }
        public string Building { get; set; }
        public User user { get; set; }
    }
}