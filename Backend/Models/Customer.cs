using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public int Id { get; set; }

    public string? User { get; set; }

    public bool? IsDelete { get; set; }
}
