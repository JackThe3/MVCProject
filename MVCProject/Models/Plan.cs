using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models;

public class Plan{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 1)]
    [Required]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9.,$;]+$")]
    public string? Name { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Owner { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
    
    public bool Status { get; set; }

    [StringLength(60)]
    public string? UpdatedBy { get; set; }

}
