using System.ComponentModel.DataAnnotations;

namespace EventAPI.Models
{
    public class Event
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The event name is required.")] //diz que é obrigatório
        public string? Name { get; set; }

        [Required(ErrorMessage = "The event date is required.")]
        public string? Date { get; set; }

        public string? Organizador { get; set; }
        public string? Description { get; set; }
        
        public string? Time { get; set; }

  
       

    }
}
