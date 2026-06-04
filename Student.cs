class Student {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Grade { get; set; }
}

class Course {
    public int Id { get; set; }
    public string Title { get; set; }
    public int Hours { get; set; }
}

class Teacher {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Subject { get; set; }
}
