
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacklogManager.Models
{
    /**
     * Make a change? Don't forget to run Add-Migration and Update-Database!
     **/

    public class BacklogItem
    {
        [Key]
        public int ID { get; set; }
        [Index]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
        public int Upvotes { get; set; }
        public string Discipline { get; set; }
        public string Action { get; set; }
        public string Goal { get; set; }
        public int TeamRank { get; set; }
        public int GlobalRank { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }

    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int SocialId { get; set; }
    }
}