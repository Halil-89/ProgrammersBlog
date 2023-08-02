using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategory Adı")]
        [Required(ErrorMessage = "Kategory Adı boş geçilemez")]
        [MaxLength(10, ErrorMessage = "Katagori adı 10 karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "Katagori adı 3 karakterden az olamaz")]
        public string? Name { get; set; } 
        [DisplayName("Kategory Açıklaması")]
        [MaxLength(500, ErrorMessage = "Kategory Açıklaması 500 karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "Kategory Açıklaması 3 karakterden az olamaz")]
        public string? Description { get; set; } 
        [DisplayName("Kategory Özel Not Açıklaması")]
        [MaxLength(500, ErrorMessage = "Kategory Özel Not Açıklaması 500 karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "Kategory Özel Not Açıklaması 3 karakterden az olamaz")]
        public string? Note { get; set; } 
        [DisplayName("Aktif mi")]
        [Required(ErrorMessage = "Aktif mi boş geçilemez")]
        public bool Isactive { get; set; }
    }
}
