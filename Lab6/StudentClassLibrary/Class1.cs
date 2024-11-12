namespace StudentClassLibrary
{
    public class Class1
    {
     
    }
    public class Student 
    {
        public int Id { get; set; }
        public int Age {  get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Course> Courses { get; set; }= new List<Course>();
    }
    public class Course
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Lecturer {  get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

