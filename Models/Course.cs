﻿using System;
using System.Collections.Generic;

namespace AspNetCoreWebApiEFDemo.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Person> Instructors { get; set; } = new List<Person>();
}
