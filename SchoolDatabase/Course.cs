using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    public class Course
    {
        private String courseCode;
        private String courseName;
        private String courseDescription;
        private float courseCredits;

        public Course(String courseCode, String courseName,
            String courseDescription)
            : this(courseCode, courseName, courseDescription, 3.0f)
        { }

        public Course(String courseCode, String courseName,
            String courseDescription, float courseCredits)
        {
            this.courseCode = courseCode;
            this.courseName = courseName;
            this.courseDescription = courseDescription;
            this.courseCredits = courseCredits;
        }
        public static Course CreateCourse(List<Course> existingCourses)
        {
            Console.Clear();
            Console.WriteLine(" ===== Create Course ===== ");


            Console.Write("Input a course code: ");
            String courseCode = Program.GetInput();

            while (existingCourses.Any(c => c.GetCourseCode().Equals(courseCode, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Course codes must be unique. Try again.");
                courseCode = Program.GetInput();
            }
            while (String.IsNullOrWhiteSpace(courseCode))
            {
                Console.WriteLine("Course code cannot be null or empty. Please try again.");
                courseCode = Program.GetInput();
            }

            Console.Write("Input a course name: ");

            String courseName = Program.GetInput();
            while (true)
            {
                if (String.IsNullOrWhiteSpace(courseName))
                {
                    Console.WriteLine("Course name cannot be null or empty. Please try again.");
                    courseName = Program.GetInput();
                }
                if (int.TryParse(courseName, out _))
                {
                    Console.WriteLine("Course name cannot contain only numbers. Please try again.");
                    courseName = Program.GetInput();
                }
                else break;
            }

            Console.Write("Input a course description: ");
            String courseDescription = Program.GetInput();

            Console.Write("Input course credits: ");
            
            float courseCredits;

            while (true)
            {
                if (!float.TryParse(Program.GetInput(), out courseCredits))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                else if (courseCredits < 0 || courseCredits > 4)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                else break;
            }
            
            return new Course(courseCode, courseName, courseDescription, courseCredits);

        }
        public override string ToString()
        {
            return $"{courseCode} - {courseName} ({courseCredits} credits)";
        }
        public String GetCourseCode() => courseCode;
        public void SetCourseCode(String courseCode)
        {
            if(String.IsNullOrWhiteSpace(courseCode))
            {
                throw new ArgumentNullException("Course code cannot be null or whitespace.");
            }
            this.courseCode = courseCode;

        }
        public String GetCourseName() => courseName;
        public void SetCourseName(String courseName)
        {
            if (String.IsNullOrWhiteSpace(courseName))
            {
                throw new ArgumentNullException("Course name cannot be null or whitespace.");
            }
            this.courseName = courseName;
        }
        public String GetCourseDescription() => courseDescription;
        public void SetCourseDescription()
        {
            this.courseDescription = courseDescription ?? throw new ArgumentNullException("Course description cannot be null.");
        }
        public float GetCourseCredits() => courseCredits;
        public void SetCourseCredits(float courseCredits)
        {
            if (courseCredits < 0) throw new ArgumentException("Course credits must be greater than 0.");
            this.courseCredits = courseCredits;
        }
        
    }
}
