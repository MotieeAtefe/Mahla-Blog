using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mahla_Blog_DataLayer.Entities
{
    public class Category :BaseEntities
    {
        
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]

        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }

        public int? ParentId { get; set; }

        #region Relation
        ICollection<Post> Posts { get; set; }
        #endregion
    }
}
