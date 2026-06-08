using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [InverseProperty("Categorys")]
        ICollection<Post> Posts { get; set; }
        [InverseProperty("SubCategorys")]

        ICollection<Post> SubPosts { get; set; }

        #endregion
    }
}
