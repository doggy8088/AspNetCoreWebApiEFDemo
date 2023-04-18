using System;
using System.Collections.Generic;

namespace AspNetCoreWebApiEFDemo.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? Name { get; set; }

    public decimal Budget { get; set; }

    public DateTime StartDate { get; set; }

    public int? InstructorId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Person? Instructor { get; set; }
}
