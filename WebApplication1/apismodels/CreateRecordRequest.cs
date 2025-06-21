using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.models;

[Table("Record")]
public class CreateRecordRequest
{
    public int LanguageId { get; set; }
    public int StudentId { get; set; }
    public TaskRequest Task { get; set; }
    public long ExecutionTime { get; set; }
    public DateTime CreatedAt { get; set; }
    
}