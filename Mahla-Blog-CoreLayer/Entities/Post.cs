using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mahla_Blog_DataLayer.Entities
{
    public class Post :BaseEntities
    {

        public int UserId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(400)]
        public string Slug { get; set; }

        public int Visit { get; set; }



        #region Realation
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public Category Categorys { get; set; }
        ICollection<PostComment> PostComments { get; set; }
        #endregion
    }
}
