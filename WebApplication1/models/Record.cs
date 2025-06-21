using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.models;

[Table("Record")]
public class Record
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public long ExecutionTime { get; set; }
    public DateTime CreatedAt { get; set; }
    [ForeignKey("Language")]
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    
    [ForeignKey("Task")]
    public int TaskId { get; set; }
    public Task Task { get; set; }

}