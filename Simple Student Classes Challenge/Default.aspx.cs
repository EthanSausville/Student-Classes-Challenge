using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        // Initilize Courses
        Course eng101 = new Course() { CourseId = "ENG101", Name = "Intro to English" };
        Course math090 = new Course() { CourseId = "MATH090", Name = "Algebra I" };
        Course bus101 = new Course() { CourseId = "BUS101", Name = "Intro to Business" };

        // Initilize Students
        Student johnWilson = new Student() { StudentId = 528772355, Name = "John Wilson" };
        Student hollyEvans = new Student() { StudentId = 528586249, Name = "Holly Evans" };
        Student adamHardin = new Student() { StudentId = 528469925, Name = "Adam Hardin" };
        Student scottWayne = new Student() { StudentId = 528913527, Name = "Scott Wayne" };
        Student ellaPrice = new Student() { StudentId = 528651635, Name = "Ella Price" };
        Student danielTompkins = new Student() { StudentId = 528362524, Name = "Daniel Tompkins" };

        List<Course> coursesList;
        Dictionary<int, Student> studentDictionary;


        // On Page_Load relationships between the above defined objects are defined
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create List of Students in each course
            eng101.Students = new List<Student>() { johnWilson, ellaPrice, danielTompkins, adamHardin };
            math090.Students = new List<Student>() { johnWilson, hollyEvans, danielTompkins, scottWayne };
            bus101.Students = new List<Student>() { hollyEvans, ellaPrice, scottWayne, adamHardin };

            // Create course List
            coursesList = new List<Course>() { eng101, math090, bus101 };

            // Add courses to students
            johnWilson.Courses = new List<Course>() { eng101, math090 };
            hollyEvans.Courses = new List<Course>() { math090, bus101 };
            adamHardin.Courses = new List<Course>() { eng101, bus101 };
            scottWayne.Courses = new List<Course>() { math090, bus101 };
            ellaPrice.Courses = new List<Course>() { eng101, bus101 };
            danielTompkins.Courses = new List<Course>() { eng101, math090 };

            // Create dictionary of students
            studentDictionary = new Dictionary<int, Student>()
            {
                { johnWilson.StudentId, johnWilson},
                { hollyEvans.StudentId, hollyEvans},
                { adamHardin.StudentId, adamHardin},
                { scottWayne.StudentId, scottWayne},
                { ellaPrice.StudentId, ellaPrice},
                { danielTompkins.StudentId, danielTompkins}
            };

            // Create Student scores
            johnWilson.Grades = new List<Grade> {
                new Grade(){ Score = 94, Student = johnWilson, Course = eng101 },
                new Grade(){ Score = 77.9, Student = johnWilson, Course = math090 }};
            hollyEvans.Grades = new List<Grade> {
                new Grade(){ Score = 89, Student = hollyEvans, Course = math090 },
                new Grade(){ Score = 97, Student = hollyEvans, Course = bus101 }};
            adamHardin.Grades = new List<Grade> {
                new Grade(){ Score = 81, Student = adamHardin, Course = eng101 },
                new Grade(){ Score = 63.5, Student = adamHardin, Course = bus101 }};
            scottWayne.Grades = new List<Grade> {
                new Grade(){ Score = 104.58, Student = scottWayne, Course = math090 },
                new Grade(){ Score = 92.3, Student = scottWayne, Course = bus101 }};
            ellaPrice.Grades = new List<Grade> {
                new Grade(){ Score = 91, Student = ellaPrice, Course = eng101 },
                new Grade(){ Score = 94.5, Student = ellaPrice, Course = bus101 }};
            danielTompkins.Grades = new List<Grade> {
                new Grade(){ Score = 76, Student = danielTompkins, Course = eng101 },
                new Grade(){ Score = 85.92, Student = danielTompkins, Course = math090 }};


        }


        // This button prints the Course List with the students in each course
        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            resultLabel.Text = "";
            foreach (var course in coursesList)
            {
                string students = "";
                foreach (var student in course.Students)
                    students += string.Format("<li>Student ID: {0:000-00-0000} -- {1}</li>",
                        student.StudentId, student.Name);

                resultLabel.Text += string.Format("<h3>Course: {0} -- {1}</h3><ul>" + students + "</ul>",
                    course.CourseId, course.Name);
            }

        }


        // This button prints the Student list with the courses they are taking
        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */

            resultLabel.Text = "";
            foreach (var student in studentDictionary)
            {
                string courses = "";
                foreach (var course in student.Value.Courses)
                    courses += string.Format("<li>Course: {0} -- {1}</li>",
                        course.CourseId, course.Name);

                resultLabel.Text += string.Format("<h3>Student: {0} -- ID: {1:000-00-0000}</h3><ul>"
                    + courses + "</ul>", student.Value.Name, student.Value.StudentId);
            }
        }


        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */

            resultLabel.Text = "";
            foreach (var student in studentDictionary)
            {
                string courses = "";
                for (int i = 0; i < student.Value.Courses.Count(); i++)
                    courses += string.Format("<li>Course: {0} -- {1} -- Grade: {2}</li>",
                        student.Value.Courses.ElementAt(i).CourseId,
                        student.Value.Courses.ElementAt(i).Name,
                        student.Value.Grades.ElementAt(i).Score);

                resultLabel.Text += string.Format("<h3>Student: {0} -- ID: {1:000-00-0000}</h3><ul>"
                    + courses + "</ul>", student.Value.Name, student.Value.StudentId);
            }
        }
    }
}