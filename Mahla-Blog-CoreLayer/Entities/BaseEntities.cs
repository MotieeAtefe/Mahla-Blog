using System;
using System.ComponentModel.DataAnnotations;

namespace Mahla_Blog_DataLayer.Entities
{
    public class BaseEntities
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
