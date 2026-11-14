using EF_03.Context;
using EF_03.Enums;
using EF_03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Threading.Channels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
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

            if (student1 is not null && course1 is not null && course1.IsPublished == true)
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

            #region Read
            //Find a course: Get a course by Id using Find, then
            //by title using FirstOrDefault.Print "not found" when the result is null.
            var course2 = context.Courses.Find(7);
            if (course2 is not null)
                Console.WriteLine($"Course Found:{course2.Title}");
            else
                Console.WriteLine("Not Found");

            var course3 = context.Courses.FirstOrDefault(c=> c.Title == ".Net");
            if (course3 is not null)
                Console.WriteLine($"Course Found:{course3.Title}");
            else
                Console.WriteLine("Not Found");


            //Filter courses: Courses priced between two values,
            //ordered by price descending. Print only the title, level and price.
            var courses = context.Courses.Where(c => c.Price > 500 && c.Price < 5000);
            foreach (var course in courses) 
            {
                Console.WriteLine($"Title: {course.Title}, Level: {(Level)course.Level}, Price: {course.Price}");
            }

            //Sub - categories: Print the direct sub-categories of a given category,
            //then print the top - level categories.
            var category0 = context.Categories.FirstOrDefault(c => c.Name == "Programming");
            if(category0 is not null)
            {
                var subCategories = context.Categories.Where(sub => sub.SuperCategoryId == category0.Id).ToList();
                Console.WriteLine("---Sub Categories---");
                foreach (var sub in subCategories)
                {
                    Console.WriteLine(sub.Name);
                }
            }
            var topCategories = context.Categories.Where(top => top.SuperCategoryId == null).ToList();
            Console.WriteLine("---Top Categories---");
            foreach (var catt in topCategories)
            {
                Console.WriteLine(catt.Name);
            }

            //Course roster: Print how many students are enrolled in a course,
            //then their names. Do it without joins: get the student Ids from the
            //enrollments first, then get the students with Contains.
            var course4 = context.Courses.FirstOrDefault(c => c.Title == ".Net");
            var StudentIds = context.StudentCourses.Where(sc => sc.CourseId == course4.Id)
                                    .Select(sc => sc.StudentId).ToList();
            var studentss = context.Students.Where(s => StudentIds.Contains(s.Id)).ToList();
            Console.WriteLine($"Number of enrolled students: {studentss.Count}");

            foreach (var student in studentss)
            {
                Console.WriteLine(student.FullName);
            }
            #endregion

            #region Update
            //Change a price: Load a course, change its price, and save.
            var crs = context.Courses.FirstOrDefault();
            if(crs is not null)
            {
                crs.Price = 15930;
                context.SaveChanges();
                Console.WriteLine("Price updated successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
            //Update progress: Find the enrollment by its composite key and set the new progress.
            //At 100 set the status to Completed.Reject values outside 0–100.
            var enrollment = context.StudentCourses.Find(1, 4);
            decimal newProgress = 100;
            if(enrollment is not null)
            {
                enrollment.ProgressPercentage = newProgress;
                if(enrollment.ProgressPercentage == 100)
                {
                    enrollment.Status = Status.Completed;
                }
                context.SaveChanges();
                Console.WriteLine("Progress updated successfully.");
            }else
            {
                Console.WriteLine("Enrollment not found.");
            }

            //Publish a course: Set the published flag and the published date.
            var course5 = context.Courses.FirstOrDefault();
            if(course5 is not null)
            {
                course5.IsPublished = true;
                context.SaveChanges();
                Console.WriteLine("Course published successfully.");
            }
            #endregion

            #region Delete
            //Unenroll: Delete an enrollment using its composite key.
            var enrollment1 = context.StudentCourses.Find(1, 4);
            context.StudentCourses.Remove(enrollment1);
            context.SaveChanges();
            //Delete a category: First try to remove a category that still has sub-categories
            var cat = context.Categories.FirstOrDefault(c => c.SuperCategoryId == null);

            //and catch the DbUpdateException, then print its message.After that, write a safe
            //version that checks for sub - categories before deleting.
            if (cat is not null)
            {
                try
                {
                    context.Categories.Remove(cat);
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //Delete a course: Delete a course that has enrollments.Print the number of
            //its enrollments before and after, and explain in a comment why they were removed.
            var crss = context.Courses.FirstOrDefault();
            if(crss is not null)
            {
                int before = context.StudentCourses.Count(sc => sc.CourseId == crss.Id);
                Console.WriteLine($"Enrollments before deletion: {before}");

                context.Courses.Remove(crss);
                context.SaveChanges();

                int after = context.StudentCourses.Count(sc => sc.CourseId == crss.Id);
                Console.WriteLine($"Enrollments after deletion: {after}");
                // it's removed because the OnDelete Behaviour is cascade so whenever
                // the course is removed it's enrollment records are removed too.
            }
            #endregion

        }
    }
}
