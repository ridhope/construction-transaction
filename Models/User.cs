using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
    [Key]
    [Column("userid")]
    public Guid UserID { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("username")]
    public string Username { get; set; }

    [Required]
    [Column("passwordhash")]
    public string PasswordHash { get; set; }

    public User()
    {
        Username = string.Empty; // Inisialisasi dengan nilai default
        PasswordHash = string.Empty; // Inisialisasi dengan nilai default
    }
}
