using System;
using System.Collections.Generic;

namespace AspNetCoreWebApiEFDemo.Models;

public partial class Person
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public DateTime? HireDate { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public string Discriminator { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual OfficeAssignment? OfficeAssignment { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
