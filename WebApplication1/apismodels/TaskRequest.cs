using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.models;


public class TaskRequest
{
  
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}