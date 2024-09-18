using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerBlazorDemo.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public int Std { get; set; }

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;
}
