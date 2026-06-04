using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppContext())
        {
            context.Database.EnsureCreated();
            Console.WriteLine("Database created successfully.");
        }
        char choice;
        while (true)
        {
            {
                Console.WriteLine("1 - students/ 2 - courses/ 3 - teachers");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choice)
                {
                    case '1':
                        StudentsFunctions();
                        break;
                    case '2':
                        CourseFunctions();
                        break;
                    case '3':
                        TeacherFunctions();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        return;
                }
            }
        }
    }

    static void StudentsFunctions() {
        char choice;
        while (true)
        {
            Console.WriteLine("1 - create students/ 2 - show students/ 3 - delete students");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    Console.WriteLine("Name of the student: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Grade of the student: ");
                    decimal grade = decimal.Parse(Console.ReadLine());
                    AddStudent(name, grade);
                    break;
                case '2':
                    ShowStudents();
                    break;
                case '3':
                    DeleteStudent();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }
        }
    }

    static void AddStudent(string name, decimal grade)
    {
        using (var context = new AppContext())
        {
            var student = new Student()
            {
                Name = name,
                Grade = grade
            };
            context.Students.Add(student);
            context.SaveChanges();
        }
    }

    static void ShowStudents()
    {
        using (var context = new AppContext())
        {
            foreach (var student in context.Students.ToList())
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
            }
        }
    }

    static void DeleteStudent()
    {
        Console.WriteLine("Enter the ID of the student to delete: ");
        int id = int.Parse(Console.ReadLine());
        using (var context = new AppContext())
        {
            var student = context.Students.Find(id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }

    static void CourseFunctions() {
        char choice;
        while (true)
        {
            Console.WriteLine("1 - create courses/ 2 - show courses/ 3 - delete courses");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    Console.WriteLine("Title of the course: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Length of course in hours: ");
                    int hours = int.Parse(Console.ReadLine());
                    AddCourse(title, hours);
                    break;
                case '2':
                    ShowCourses();
                    break;
                case '3':
                    DeleteCourse();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }
        }
    }

    static void AddCourse(string title, int hours)
    {
        using (var context = new AppContext())
        {
            var course = new Course()
            {
                Title = title,
                Hours = hours
            };
            context.Courses.Add(course);
            context.SaveChanges();
        }
    }

    static void ShowCourses()
    {
        using (var context = new AppContext())
        {
            foreach (var course in context.Courses.ToList())
            {
                Console.WriteLine($"ID: {course.Id}, Title: {course.Title}, Hours: {course.Hours}");
            }
        }
    }

    static void DeleteCourse()
    {
        Console.WriteLine("Enter the ID of the course to delete: ");
        int id = int.Parse(Console.ReadLine());
        using (var context = new AppContext())
        {
            var course = context.Courses.Find(id);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
                Console.WriteLine("Course deleted successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
    }

    static void TeacherFunctions() {
        char choice;
        while (true)
        {
            Console.WriteLine("1 - create teachers/ 2 - show teachers/ 3 - delete teachers");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    Console.WriteLine("First name of the teacher: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Last name of the teacher: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Subject of the teacher: ");
                    string subject = Console.ReadLine();
                    AddTeacher(firstName, lastName, subject);
                    break;
                case '2':
                    ShowTeachers();
                    break;
                case '3':
                    DeleteTeacher();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }
        }
    }
    static void AddTeacher(string firstName, string lastName, string subject)
    {
        using (var context = new AppContext())
        {
            var teacher = new Teacher()
            {
                FirstName = firstName,
                LastName = lastName,
                Subject = subject
            };
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }
    }

    static void ShowTeachers()
    {
        using (var context = new AppContext())
        {
            foreach (var teacher in context.Teachers.ToList())
            {
                Console.WriteLine($"ID: {teacher.Id}, First Name: {teacher.FirstName}, Last Name: {teacher.LastName}, Subject: {teacher.Subject}");
            }
        }
    }

    static void DeleteTeacher()
    {
        Console.WriteLine("Enter the ID of the teacher to delete: ");
        int id = int.Parse(Console.ReadLine());
        using (var context = new AppContext())
        {
            var teacher = context.Teachers.Find(id);
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
                Console.WriteLine("Teacher deleted successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }
    }
}
