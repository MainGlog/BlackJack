namespace ClassDemo
{
    public class Student
    {
        public String fname; //First Name
        public String lname; //Last Name
        public String gender;
        public DateOnly birthDate;
        public String address;
        public bool tuitionPaid;
        public String GetFullName()
        {
            return fname + " " + lname;

        }
        public int GetAge()
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if(DateTime.Now.DayOfYear < birthDate.DayOfYear)
            {
                age--;
            }
            return age;
        }
    }
}
