using System.ComponentModel.DataAnnotations.Schema;

namespace Mahla_Blog_DataLayer.Entities
{
    public class PostComment:BaseEntities
    {

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        #region Relation 

        [ForeignKey("PostId")]
        public Post Posts { get; set; }

        [ForeignKey("UserId")]
        public User Users { get; set; }

        #endregion


    }
}
