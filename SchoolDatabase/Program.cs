using System.Security.Cryptography;
using ConsoleTables;
using Bogus;

namespace SchoolDatabase
{
    public class Program
    {
        private enum InputDecision : sbyte
        {
            ViewStudents = 1,
            ViewTeachers, // = 2
            ViewCourses, // = 3
            ViewClasses, // = 4
            Quit = -1
        }
        private enum ActionDecision : sbyte
        {
            Add = 1,
            Remove,
            Back = -1
        }
        private enum ClassActionDecision : sbyte
        {
            Add = 1,
            Remove,
            AddStudent,
            RemoveStudent,
            Back = -1
        }
        private static List<Student> students = [];
        private static List<Teacher> teachers = [];
        private static List<Course> courses = [];
        private static List<Class> classes = [];

        public static void Main()
        {
            students = GenerateStudents();
            teachers = GenerateTeachers();
            Console.Title = "School Database";
            InputDecision decision = 0; //Done so initial label is not set

            while (decision != InputDecision.Quit)
            {
                Console.Clear();
                Console.WriteLine(" ===== School Database ===== ");

                decision = GetInitialInput();
                switch(decision)
                {
                    case InputDecision.ViewStudents:
                        ViewStudents();
                        break;
                    case InputDecision.ViewTeachers:
                        ViewTeachers();
                        break;
                    case InputDecision.ViewCourses:
                        ViewCourses();
                        break;
                    case InputDecision.ViewClasses:
                        ViewClasses();
                        break;
                }
            }
        }

        public static String GetInput()
        {
            Console.Write(">> ");
            Console.ForegroundColor = ConsoleColor.Green;
            String input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        private static InputDecision GetInitialInput()
        {
            String[] validInputs = { "1", "2", "3", "4", "q"};
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("View student (1) | View teachers (2) | View courses (3) | View classes (4) | Quit (q)");
            String input = GetInput();

            //Input Validation
            while (!validInputs.Contains(input, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid input.");
                input = GetInput();
            }
            
            if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                return InputDecision.Quit;
            }

            return (InputDecision)sbyte.Parse(input);
        }
        private static void ViewStudents()
        {
            ActionDecision action = 0; //Enum initialization
            while (action != ActionDecision.Back)
            {
                Console.Clear();
                Console.WriteLine(" ===== Students ===== ");

                if(students.Count > 0) 
                {
                    ConsoleTable table = new("ID", "First Name", "Last Name", "Birth Date", "Address", "GPA");
                    //var e = new ConsoleTable(); var is an implied type, used when the data type is long
                    foreach (Student student in students)
                    {
                        table.AddRow(student.Id, student.FirstName, student.LastName,
                            student.BirthDate, student.Address, student.GPA);
                    }
                    table.Write();
                }
                else //No Students
                {
                    Console.WriteLine("No students found.");

                }
                Console.Write(Environment.NewLine);

                action = GetFollowUpInput("student");

                switch (action)
                {
                    case ActionDecision.Add:
                        students.Add(Student.CreateStudent());
                        break;
                    case ActionDecision.Remove:
                        if(students.Count == 0)
                        {
                            Console.WriteLine("There are no students to remove.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue; //continue means do not break loop, but stop iteration and start a new iteration of the loop.
                        }
                        Console.WriteLine("Remove a student by entering the student's ID.");
                        int studentId;

                        while(!int.TryParse(GetInput(), out studentId))
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                        
                        Student studentToRemove = students.FirstOrDefault(x => x.Id == studentId);

                        if(studentToRemove != null) 
                        {
                            students.Remove(studentToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }

        private static ActionDecision GetFollowUpInput(String context)
        {
            String[] validInputs = { "1", "2", "q" };
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"Add {context} (1) | Remove {context} (2) | Back (q)");
            String input = GetInput();
            while (!validInputs.Contains(input, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid input. Please try again.");
                input = GetInput();
            }
            
            if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                return ActionDecision.Back;
            }

            return (ActionDecision)sbyte.Parse(input);
        }
        private static ClassActionDecision GetClassFollowUpInput()
        {
            String[] validInputs = { "1", "2", "3", "4", "q" };
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Add class (1) | Remove class (2) | Add student (3) | Remove student (4) | Back (q)");
            String input = GetInput();
            while (!validInputs.Contains(input, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid input. Please try again.");
                input = GetInput();
            }

            if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                return ClassActionDecision.Back;
            }
            return (ClassActionDecision)sbyte.Parse(input);
        }
        private static void ViewTeachers()
        {
            ActionDecision action = 0; //Enum initialization
            while (action != ActionDecision.Back)
            {
                Console.Clear();
                Console.WriteLine(" ===== Teachers ===== ");

                if (teachers.Count > 0)
                {
                    ConsoleTable table = new("ID", "First Name", "Last Name", "Birth Date", "Address", "Salary");
                    //var e = new ConsoleTable(); var is an implied type, used when the data type is long
                    foreach (Teacher teacher in teachers)
                    {
                        table.AddRow(teacher.Id, teacher.FirstName, teacher.LastName,
                            teacher.BirthDate, teacher.Address, teacher.Salary);
                    }
                    table.Write();
                }
                else //No Teachers
                {
                    Console.WriteLine("No teachers found.");

                }
                Console.Write(Environment.NewLine);

                action = GetFollowUpInput("teacher");

                switch (action)
                {
                    case ActionDecision.Add:
                        teachers.Add(Teacher.CreateTeacher());
                        break;
                    case ActionDecision.Remove:
                        if (teachers.Count == 0)
                        {
                            Console.WriteLine("There are no teachers to remove.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue; //continue means do not break loop, but stop iteration and start a new iteration of the loop.
                        }
                        Console.WriteLine("Remove a teacher by entering the teacher's ID.");
                        int teacherId;

                        while (!int.TryParse(GetInput(), out teacherId))
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }

                        Teacher teacherToRemove = teachers.FirstOrDefault(x => x.Id == teacherId);

                        if (teacherToRemove != null)
                        {
                            teachers.Remove(teacherToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Teacher not found.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }

        private static void ViewCourses()
        {
            ActionDecision action = 0; //Enum initialization
            while (action != ActionDecision.Back)
            {
                Console.Clear();
                Console.WriteLine(" ===== Courses ===== ");

                if (courses.Count > 0)
                {
                    ConsoleTable table = new("Code", "Name", "Description", "Credits");
                    foreach (Course course in courses)
                    {
                        table.AddRow(course.GetCourseCode(), course.GetCourseName(), course.GetCourseDescription(),
                            course.GetCourseCredits());
                    }
                    table.Write();
                }
                else //No Courses
                {
                    Console.WriteLine("No courses found.");

                }
                Console.Write(Environment.NewLine);

                action = GetFollowUpInput("course");

                switch (action)
                {
                    case ActionDecision.Add:
                        courses.Add(Course.CreateCourse(courses));
                        break;
                    case ActionDecision.Remove:
                        if (courses.Count == 0)
                        {
                            Console.WriteLine("There are no courses to remove.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue; //continue means do not break loop, but stop iteration and start a new iteration of the loop.
                        }
                        Console.WriteLine("Remove a course by entering the course code.");
                        
                        String courseCode = GetInput();
                        Course courseToRemove = courses.FirstOrDefault(x => x.GetCourseCode().Equals(courseCode, StringComparison.OrdinalIgnoreCase));

                        if (courseToRemove != null)
                        {
                            courses.Remove(courseToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Course not found.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }

        private static void ViewClasses()
        {
            ClassActionDecision action = 0; //Enum initialization
            while (action != ClassActionDecision.Back)
            {
                Console.Clear();
                Console.WriteLine(" ===== Classes ===== ");

                if (classes.Count > 0)
                {
                    ConsoleTable table = new("ID", "Course", "Section", "Season", "Teacher", "Students");
                    foreach (Class c in classes) //@ is the ignore keyword that allows you to use variables with reserved names like class. 
                    {
                        table.AddRow(c.GetClassId(), c.GetCourse(), c.GetSection(), 
                            c.GetSeason(), c.GetTeacher(), String.Join(", ", c.GetStudents()));
                    }
                    table.Write();
                }
                else //No classes
                {
                    Console.WriteLine("No classes found.");

                }
                Console.Write(Environment.NewLine);

                action = GetClassFollowUpInput();

                switch (action)
                {
                    case ClassActionDecision.Add:
                        classes.Add(Class.CreateClass(courses, teachers));
                        break;
                    case ClassActionDecision.Remove:
                        if (classes.Count == 0)
                        {
                            Console.WriteLine("There are no classes to remove.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue; //continue means do not break loop, but stop iteration and start a new iteration of the loop.
                        }
                        Console.WriteLine("Remove a class by entering the class's ID.");
                        
                        int classId;

                        while (!int.TryParse(GetInput(), out classId))
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }

                        Class classToRemove = classes.FirstOrDefault(x => x.GetClassId() == classId);

                        if (classToRemove != null)
                        {
                            classes.Remove(classToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Class not found.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case ClassActionDecision.AddStudent:
                        Console.WriteLine("Enter Class ID to add a student to.");

                        Class classToAddTo = null;
                        while (classToAddTo == null)
                        {
                            while (!int.TryParse(GetInput(), out classId))
                            {
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                            classToAddTo = classes.FirstOrDefault(c => c.GetClassId() == classId);
                            if (classToAddTo == null)
                            {
                                Console.WriteLine("Class not found.");
                                Console.WriteLine("Enter Class ID to add a student to.");
                            }
                        }
                        Console.WriteLine("Enter student ID to add student to the class");

                        Student studentToAdd = null;
                        int studentId;
                        while (studentToAdd == null)
                        {
                            while (!int.TryParse(GetInput(), out studentId))
                            {
                                Console.WriteLine("Invalid input. Please try again.");
                            }

                            studentToAdd = students.FirstOrDefault(s => s.Id == studentId);

                            if (studentToAdd == null 
                                || classToAddTo.GetStudents().Contains(studentToAdd))
                            {
                                Console.WriteLine("Invalid student ID.");
                                Console.WriteLine("Enter student ID to add student to the class");
                            }
                            else
                            {
                                break;
                            }
                        }
                        classToAddTo.AddStudent(studentToAdd);
                        break;
                    case ClassActionDecision.RemoveStudent:
                        Console.WriteLine("Enter Class ID to remove a student from.");
                        Class classToRemoveFrom = null;
                        while (classToRemoveFrom == null)
                        {
                            while (!int.TryParse(GetInput(), out classId))
                            {
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                            classToRemoveFrom = classes.FirstOrDefault(c => c.GetClassId() == classId);
                            if (classToRemoveFrom == null)
                            {
                                Console.WriteLine("Class not found.");
                                Console.WriteLine("Enter Class ID to add a student to.");
                            }
                        }

                        Console.WriteLine(String.Join(Environment.NewLine, students));
                        //students.ForEach(x => Console.WriteLine(x));

                        Console.WriteLine("Enter student ID to add student to the class");

                        Student studentToRemove = null;
                        while (studentToRemove == null)
                        {
                            while (!int.TryParse(GetInput(), out studentId))
                            {
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                            studentToRemove = students.FirstOrDefault(s => s.Id == studentId);
                            if (studentToRemove == null)
                            {
                                Console.WriteLine("Student not found.");
                                Console.WriteLine("Enter student ID to add student to the class");
                            }
                        }
                        classToRemoveFrom.RemoveStudent(studentToRemove);
                        break;
                }
            }
        }
        private static List<Student> GenerateStudents(int numToGen = 50)
        {
            Faker<Student> faker = new Faker<Student>()
                .RuleFor(s => s.FirstName, f => f.Person.FirstName)
                .RuleFor(s => s.LastName, f => f.Person.LastName)
                .RuleFor(s => s.BirthDate, 
                    f => DateOnly.FromDateTime(f.Date.Between(DateTime.Now.AddYears(-80), 
                    DateTime.Now.AddYears(-16)).Date))
                .RuleFor(s => s.Address, f => new Address(f.Address.StreetAddress(),
                                                          f.Address.City(),
                                                          f.Address.State(),
                                                          f.Address.ZipCode()))
                .RuleFor(s => s.GPA, f => f.Random.Float(0, 4));

            return faker.Generate(numToGen);
        }

        private static List<Teacher> GenerateTeachers(int numToGen = 50)
        {
            Faker<Teacher> faker = new Faker<Teacher>()
                .RuleFor(t => t.FirstName, f => f.Person.FirstName)
                .RuleFor(t => t.LastName, f => f.Person.LastName)
                .RuleFor(t => t.BirthDate,
                    f => DateOnly.FromDateTime(f.Date.Between(DateTime.Now.AddYears(-80),
                    DateTime.Now.AddYears(-16)).Date))
                .RuleFor(t => t.Address, f => new Address(f.Address.StreetAddress(),
                                                          f.Address.City(),
                                                          f.Address.State(),
                                                          f.Address.ZipCode()))
                .RuleFor(t => t.Salary, f => f.Random.Float(18500, 65000));

            return faker.Generate(numToGen);
        }
    }
}
