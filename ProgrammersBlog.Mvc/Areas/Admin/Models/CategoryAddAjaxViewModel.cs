using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto? CategoryAddDto { get; set; }
        public string? CategoryAddPArtial { get; set; }
        public CategoryDto? CategoryDto { get; set; }
    }
}
