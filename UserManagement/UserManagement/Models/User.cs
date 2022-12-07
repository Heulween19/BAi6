using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models;

public partial class User
{
    [Required]
    [Display(Name ="User Id")]
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public int? Age { get; set; }

    public bool? Gender { get; set; }
    [Required]
    [Display(Name ="Group id")]
    public int GroupId { get; set; }

    public bool? Status { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
