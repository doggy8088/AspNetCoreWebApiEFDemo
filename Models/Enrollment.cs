﻿using System;
using System.Collections.Generic;

namespace AspNetCoreWebApiEFDemo.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public int? Grade { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Person Student { get; set; } = null!;
}
