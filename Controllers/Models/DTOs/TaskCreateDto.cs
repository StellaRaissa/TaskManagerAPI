using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTOs
{
    public class TaskCreateDto
    {
        [Required(ErrorMessage = "Le titre est obligatoire")]
        [MinLength(3, ErrorMessage = "Le titre doit contenir au moins 3 caractères")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        [MaxLength(300)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
