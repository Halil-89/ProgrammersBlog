using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
       
        [Required]
        public int Id { get; set; }
        [DisplayName("Kategory Adı")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [MaxLength(7, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string Name { get; set; }
        [DisplayName("Kategory  Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string Description { get; set; }
        [DisplayName("Kategory Özel Not Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string Note { get; set; }
        [DisplayName("Aktif mi")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public bool Isactive { get; set; }
        [DisplayName("Silisin mi")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public bool IsDeleted  { get; set; }
    }
}
