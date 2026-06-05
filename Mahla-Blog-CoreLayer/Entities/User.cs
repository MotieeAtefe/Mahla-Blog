using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Mahla_Blog_DataLayer.Entities
{
    public class User : BaseEntities
    {

        [Required]
        public string FullName { get; set; }
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }


        #region Relation
        ICollection<Post> Posts { get; set; }
        ICollection<PostComment> PostComments { get; set; }
        #endregion

    }
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
