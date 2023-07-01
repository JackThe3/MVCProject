using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models;

public class Plan{
    [Display(Name = "ID")]
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 1)]
    [Required]
    [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9.,$;]+$")]
    [Display(Name = "Názov")]
    public string? Name { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    [Display(Name = "Osoba")]
    public string? Owner { get; set; }
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:MMMM, dd yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
    [Display(Name = "Dátum vytvorenia")]
    public DateTime CreatedAt { get; set; }
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:MMMM, dd yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
    [Display(Name = "Posledná úprava")]
    public DateTime UpdatedAt { get; set; }

    [Display(Name = "Platnosť")]
    public bool Status { get; set; }

    [StringLength(60)]
    [Display(Name = "Upravil")]
    public string? UpdatedBy { get; set; }

}
