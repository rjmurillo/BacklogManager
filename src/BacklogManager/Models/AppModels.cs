
using System;

namespace BacklogManager.Models
{
    public class BacklogItem 
     { 
         public int ID { get; set; } 
         public string Title { get; set; }
         public string Owner { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public int Upvotes { get; set; }
        public string Discipline { get; set; }
        public string Action { get; set; }
        public string Goal { get; set; }
     } 


}