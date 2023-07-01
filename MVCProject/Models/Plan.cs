using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models;

public class Plan{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Owner { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
    [DataType(DataType.Date)]
    public DateTime UpdatedAt { get; set; }
    public bool Status { get; set; }
    public string? UpdatedBy { get; set; }

}
