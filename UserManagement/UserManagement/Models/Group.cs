using System;
using System.Collections.Generic;

namespace UserManagement.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string? GroupName { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
