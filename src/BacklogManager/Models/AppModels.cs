
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Upvotes { get; set; }
        [Required]
        public string Discipline { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public string Goal { get; set; }
        public int ProjectRank { get; set; }
        [Required]
        public int GlobalRank { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        [Index]
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        [MaxLength(2083)]
        public string WorkItemUrl { get; set; }
    }

    public class User
    {
        [Key]
        public int ID { get; set; }
        [Index(IsClustered = false, IsUnique = false)]
        [MaxLength(15)]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        [Index(IsClustered = false)]
        public int SocialId { get; set; }
        //public virtual List<BacklogItem> BacklogItems { get; set; }
    }

    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Index(IsClustered = false, IsUnique = true)]
        [MaxLength(7)]
        public string Color { get; set; }

        //public virtual List<BacklogItem> BacklogItems { get; set; }
    }
}