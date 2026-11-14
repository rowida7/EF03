using EF_03.Context;
using EF_03.Models;
using EF_03.Enums;
using System.Security.Policy;
namespace EF_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlatformContext context = new PlatformContext();
            #region Create
            //Add an instructor: Insert a new instructor and print the generated Id.
            //Add a course: Insert a course for an existing instructor and an existing
            //category.Check that both exist first, otherwise print a message.
            Instructor instructor = new Instructor()
            {
                FullName = "Ahmed Ali",
                Email = "ahmed@gmail.com",
                Bio = "Anything...."
            };

            Category category = new Category()
            {
                Name = "Programming",
                Description = "Desc...."
            };

            context.Categories.Add(category);
            context.Instructors.Add(instructor);
            context.SaveChanges();
            Console.WriteLine(instructor.Id);

            int instructorId = instructor.Id;
            int categoryId = category.Id;

            var existingInstructor = context.Instructors.FirstOrDefault(i => i.Id == instructorId);
            var existingCategory = context.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (existingInstructor == null)
            {
                Console.WriteLine("Instructor does not exist.");
            }
            else if (existingCategory == null)
            {
                Console.WriteLine("Category does not exist.");
            }
            else
            {
                Course course = new Course()
                {
                    Title = ".Net",
                    Description = "Desc....",
                    Price = 10000,
                    Level = Level.Intermediate,
                    IsPublished = true,
                    InstructorId = instructor.Id,
                    CategoryId = category.Id
                };

                context.Courses.Add(course);
                context.SaveChanges();

                Console.WriteLine("Course added successfully.");
            }
            //Add several students: Insert three students using one AddRange
            //and one SaveChanges.Print their generated Ids.
            List<Student> students = new List<Student>()
            {
                new Student {FullName= "Mona",Email = "mona@gmail.com",DOB = new DateOnly(2024, 11, 11)},
                new Student {FullName= "Mai",Email = "mai@gmail.com",DOB = new DateOnly(2022, 10, 11)},
                new Student {FullName= "Moataz",Email = "moataz@gmail.com",DOB = new DateOnly(2002, 6, 2)}
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            foreach (var std in students)
            {
                Console.WriteLine($"Student ID: {std.Id}");
            }
            //Enroll a student: The student and the course must exist,
            //the course must be published, and the student must not be
            //enrolled already. Otherwise print why the enrollment was refused.

            var student1 = context.Students.FirstOrDefault();
            var course1 = context.Courses.FirstOrDefault();

            if (student1 is not null && course1 is not null)
            {
                StudentCourses studentCourses = new StudentCourses()
                {
                    StudentId = student1.Id,
                    CourseId = course1.Id,
                    ProgressPercentage = 30,
                    Status = Status.Active,
                    EnrollmentDate = new DateOnly(2002, 6, 2)

                };
                context.StudentCourses.Add(studentCourses);
                context.SaveChanges();
                Console.WriteLine("Enrolled successfully!");
            }
            else
            {
                Console.WriteLine("enrollment was refused.");
            }
            #endregion





        }
    }
}
