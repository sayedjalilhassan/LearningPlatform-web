using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LearningPlatform.Models
{
    //DropCreateDatabaseAlways  DropCreateDatabaseIfModelChanges
    public class SampleData : DropCreateDatabaseAlways<PlatformDbContext>
    {
        protected override void Seed(PlatformDbContext context)
        {
            var admins = new List<Admin>
            {
                new Admin {AdminName = "Admin",Email_ID ="admin", Password ="admin_1" }
            };
            admins.ForEach(s => context.Admins.Add(s));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01"),Email_ID ="Carson",  Password ="student_1" },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    EnrollmentDate = DateTime.Parse("2002-09-01"),Email_ID ="Meredith",  Password ="student_1" },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     EnrollmentDate = DateTime.Parse("2003-09-01") ,Email_ID ="Arturo",  Password ="student_1"},
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") ,Email_ID ="Gytis",  Password ="student_1"},
                new Student { FirstMidName = "Yan",      LastName = "Li",        EnrollmentDate = DateTime.Parse("2002-09-01") ,Email_ID ="Yan",  Password ="student_1"},
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   EnrollmentDate = DateTime.Parse("2001-09-01") ,Email_ID ="Peggy",  Password ="student_1"},
                new Student { FirstMidName = "Laura",    LastName = "Norman",    EnrollmentDate = DateTime.Parse("2003-09-01") ,Email_ID ="Laura",  Password ="student_1"},
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  EnrollmentDate = DateTime.Parse("2005-09-01") ,Email_ID ="Nino",  Password ="student_1"}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor{InstructorName = "Pervaiz HoodBhoy" ,Email_ID ="Pervaiz",  Password ="teacher_1"},
                new Instructor{InstructorName = "Mudasir Moosa" ,Email_ID ="Mudasir",  Password ="teacher_1"},
                new Instructor{InstructorName = "Ali Shehper",Email_ID ="Ali",  Password ="teacher_1"},
                new Instructor{InstructorName = "Azeem ul Hassan",Email_ID ="Azeem",  Password ="teacher_1"},
                new Instructor{InstructorName = "Alamdar Hussain",Email_ID ="Alamdar",  Password ="teacher_1"}
            };
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { DepartmentName = "English",       UserID = 9 },
                new Department { DepartmentName = "Mathematics",  UserID = 10 },
                new Department { DepartmentName = "Engineering", UserID = 11 },
                new Department { DepartmentName = "Economics",   UserID = 12 }
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { CourseId = 101, CourseName = "English", Credits = 3 , DepartmentID = 1, Instructors = new List<Instructor>()},
                new Course { CourseId = 200, CourseName = "Chemistry", Credits = 4, DepartmentID = 3, Instructors = new List<Instructor>()},
                new Course { CourseId = 300, CourseName = "Computer Sciences", Credits = 4 , DepartmentID = 3, Instructors = new List<Instructor>()},
                new Course { CourseId = 412, CourseName = "Biology" , Credits = 3, DepartmentID = 3, Instructors = new List<Instructor>()},
                new Course { CourseId = 545, CourseName = "Physics" , Credits = 3, DepartmentID = 3, Instructors = new List<Instructor>()},
                new Course { CourseId = 102, CourseName = "Math" , Credits = 4, DepartmentID = 2, Instructors = new List<Instructor>()},
                new Course { CourseId = 203, CourseName = "History" , Credits = 2, DepartmentID = 4, Instructors = new List<Instructor>()},
                new Course { CourseId = 402, CourseName = "Software Engineering" , Credits = 3, DepartmentID = 3, Instructors = new List<Instructor>()},
                new Course { CourseId = 501, CourseName = "Graphics" , Credits = 4, DepartmentID = 3, Instructors = new List<Instructor>()},
                new Course { CourseId = 370, CourseName = "Vision" , Credits = 3, DepartmentID = 3, Instructors = new List<Instructor>()}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();


            courses[0].Instructors.Add(instructors[0]);
            courses[0].Instructors.Add(instructors[1]);
            courses[1].Instructors.Add(instructors[2]);
            courses[2].Instructors.Add(instructors[2]);
            courses[3].Instructors.Add(instructors[3]);
            courses[4].Instructors.Add(instructors[3]);
            courses[5].Instructors.Add(instructors[3]);
            courses[6].Instructors.Add(instructors[3]);
            context.SaveChanges();


            new List<Chapter>
            {
                new Chapter{ ChapterTitle = "Physical Quantities and Measurment", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Kinametics" , Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Dynamics", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle ="Turning Effect of Force", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Gravitation", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Work and Energy", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Properties of Matter", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Thermal Properties of Matter", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Transfer of Heat", Course = courses.Single(g => g.CourseName == "Physics"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},

                new Chapter{ ChapterTitle = "Physical Quantities and Measurment", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Kinametics" , Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Dynamics", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle ="Turning Effect of Force", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Gravitation", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Work and Energy", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Properties of Matter", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Thermal Properties of Matter", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Transfer of Heat", Course = courses.Single(g => g.CourseName == "Chemistry"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},

                new Chapter{ ChapterTitle = "Physical Quantities and Measurment", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Kinametics" , Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Dynamics", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle ="Turning Effect of Force", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Gravitation", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Work and Energy", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Properties of Matter", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Thermal Properties of Matter", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"},
                new Chapter{ ChapterTitle = "Transfer of Heat", Course = courses.Single(g => g.CourseName == "Computer Sciences"), Instructor = instructors.Single(a => a.InstructorName == "Pervaiz HoodBhoy"), ChapterArtUrl = "/Content/Images/placeholder.gif"}
            }.ForEach(a => context.Chapters.Add(a)); context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { UserID = 1, CourseID = 101, Grade = 1 },
                new Enrollment { UserID = 1, CourseID = 200, Grade = 3 },
                new Enrollment { UserID = 1, CourseID = 300, Grade = 1 },
                new Enrollment { UserID = 2, CourseID = 412, Grade = 2 },
                new Enrollment { UserID = 2, CourseID = 545, Grade = 4 },
                new Enrollment { UserID = 2, CourseID = 102, Grade = 4 },
                new Enrollment { UserID = 3, CourseID = 101            },
                new Enrollment { UserID = 4, CourseID = 102,           },
                new Enrollment { UserID = 4, CourseID = 203, Grade = 4 },
                new Enrollment { UserID = 5, CourseID = 300, Grade = 3 },
                new Enrollment { UserID = 6, CourseID = 402            },
                new Enrollment { UserID = 7, CourseID = 501, Grade = 2 },
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();


        }
    }
}