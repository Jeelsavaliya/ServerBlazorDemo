using System;
using System.Collections.Generic;

namespace ServerBlazorDemo.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int Experience { get; set; }
}
