using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    public enum Season : byte
    {
        Autumn, 
        Winter, 
        Spring, 
        Summer
    }
    public class Class
    {
        private static int nextClassId;

        private readonly int classId;
        private Course course;
        private String section;
        private Season season;
        private Teacher teacher;
        private List<Student> students = [];
        public Class(Course course, String section,
            Season season, Teacher teacher)
        {
            classId = nextClassId++;
            this.course = course;
            this.section = section;
            this.season = season;
            this.teacher = teacher;
        }

        public static Class CreateClass(List<Course> courses, List<Teacher> teachers)
        {
            Console.Clear();
            Console.WriteLine(" ===== Create Class ===== ");
            
            Console.WriteLine("Courses: ");
            Console.WriteLine(String.Join(Environment.NewLine, courses));
            Console.Write(Environment.NewLine);
            
            Console.WriteLine("Input a course code.");
            String courseCode = Program.GetInput();

            Course course = courses.FirstOrDefault(c => c.GetCourseCode()
            .Equals(courseCode, StringComparison.OrdinalIgnoreCase)); //Course will be assigned null if it is not a valid course.
            
            while (course == null)
            {
                Console.WriteLine("Invalid input. Please try again.");
                courseCode = Program.GetInput();
                course = courses.FirstOrDefault(c => c.GetCourseCode()
                .Equals(courseCode, StringComparison.OrdinalIgnoreCase));
            }


            Console.WriteLine("Input a section.");
            String section = Program.GetInput();
            //TODO input validation


            Console.WriteLine("Input a season (Fall, Winter, Spring, Summer).");
            Season season;

            while (!Enum.TryParse(Program.GetInput(), out season))
            {
                Console.WriteLine("Invalid input. Please try again.");
            }


            Console.WriteLine("Teachers: ");
            Console.WriteLine(String.Join(Environment.NewLine, teachers));
            Console.Write(Environment.NewLine);
            Console.WriteLine("Input a teacher ID.");
            Teacher teacher = null;

            while (teacher == null)
            {
                int teacherId;
                while (!int.TryParse(Program.GetInput(), out teacherId))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherId); //If this fails, teacher will still be null.
                if (teacher == null)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            return new Class(course, section, season, teacher);
        }
        public void DisplayStudents()
        {
            Console.WriteLine($"Students in {this}");
            Console.WriteLine(String.Join(Environment.NewLine, students));
        }
        public int GetClassId() => classId;
        public Course GetCourse() => course;
        public void SetCourse(Course course)
        {

        }
        public String GetSection() => section;
        public void SetSection(String section)
        {
        
        }
        public Season GetSeason() => season;
        public void SetSeason(Season season)
        {
            if (season == Season.Summer)
            {
                throw new ArgumentException("No summer courses offered.");
            }
            this.season = season;
        }
        public Teacher GetTeacher() => teacher;
        public void SetTeacher(Teacher teacher)
        {
            this.teacher = teacher ?? throw new ArgumentNullException("Teacher cannot be null");
        }
        public List<Student> GetStudents() => students;
        public void AddStudent(Student student)
        {
            if (students.Contains(student))
            {
                throw new InvalidOperationException("Can't add duplicate student to class");
            }
            students.Add(student);
        }
        public void RemoveStudent(Student student) => students.Remove(student);
        public void RemoveStudent(int studentId)
        {
            Student student = students.FirstOrDefault(x => x.StudentId == studentId); //x is students. Iterates through students until one's id matches the id passed in
            //FirstOrDefault is needed because doing just first would crash if no student with that ID is found.
            if (student != null)
            {
                students.Remove(student);
            }
            /*
            Student student = null;
            foreach(Student s in students)
            {
                if (s.GetStudentId() == studentId)
                {
                    student = s;
                    break;
                }
            }
            if (student != null)
            {
                students.Remove(student);
            }
            */
        }
        public void RemoveAllStudents() => students.Clear();
    }
}
