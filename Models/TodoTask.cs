using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models; 
public class TodoTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tytuł jest wymagany")]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsCompleted { get; set; }
}