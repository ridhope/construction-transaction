using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("projects")]
public class Project
{
    [Key]
    [Column("projectid")]
    public Guid ProjectID { get; set; }

    [Required]
    [MaxLength(200)]
    [Column("projectname")]
    public string ProjectName { get; set; }

    [Required]
    [MaxLength(500)]
    [Column("projectlocation")]
    public string ProjectLocation { get; set; }

    [Required]
    [Column("projectstage")]
    public string ProjectStage { get; set; }

    [Required]
    [Column("projectcategory")]
    public string ProjectCategory { get; set; }

    [Column("othercategory")]
    public string OtherCategory { get; set; }

    [Required]
    [Column("constructionstartdate")]
    public DateTime ConstructionStartDate { get; set; }

    [Required]
    [MaxLength(2000)]
    [Column("projectdetails")]
    public string ProjectDetails { get; set; }

    [Required]
    [Column("projectcreatorid")]
    public Guid ProjectCreatorID { get; set; }

     public Project()
    {
        ProjectName = string.Empty; 
        ProjectLocation = string.Empty; 
        ProjectStage = string.Empty; 
        ProjectCategory = string.Empty; 
        OtherCategory = string.Empty; 
        ProjectDetails = string.Empty; 
    }
}