using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects_StudentCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowCourseConstructors();
            Console.ReadKey();

        }
        static void DoStudentExamples()
        {
            Student student1 = new Student("John McClary");
            student1.CourseList.Add( new Course("professional Development", "B"));

            student1.printStudentInfo();
        }
        static void ShowCourseConstructors()
        {

            Course course1 = new Course();
            Course course2 = new Course("Biology");
            Course course3 = new Course("Math 101", "A");

            course1.PrintCourseInfo();
            course2.PrintCourseInfo();
            course3.PrintCourseInfo();

         
    
        }
         //new functions
    }
    //new classes
    public class Course
    {
        //step 1. define properties
        // 
        // creating Properties
        // Step 1. Create the hide behind variable
        private string _name;
        // step 2. create the property layer that sits on top of the variable. It controls the interface
        public string Name
        {
            get
            {
                //getter: whenv=ever the value is on the right side of the equation
                //eg. myString = myObject.Name
                return _name.ToUpper();
            }
            set
            {
                // setter: whenever the value is on the left side of the equation
                //eg. Object.Name = "Nickleback";
                _name = value;
            }
        }

        private string _letterGrade;
        public string LetterGrade
        {
            get { return _letterGrade;}
            set { _letterGrade = value.ToUpper(); }
        }

        // Grade Points, we are going to do a read only property
        public double GradePoints
        {
            get
            {
                switch (this.LetterGrade)
                {
                    case "A":
                        return 4.0;
                    case "B":
                        return 3.0;
                    case "C":
                        return 2.0;
                    case "D":
                        return 1.0;
                    default:
                        return 0.0;
                }

            }
        }
        // Creating a new class: Step 2: Define constructor(s)

        // Parameterless constructor
        public Course()
        {
            this.Name = "Undefined";
            this.LetterGrade = "I";
            
        }
        // Parameterfull constructor, more common, this is the constructor that you'll usually use
        public Course( string name)
        {
            this.Name = name;
            this.LetterGrade = "I";
        }
        public Course(string name, string letterGrade)
        {
            this.Name =  name;
            this.LetterGrade = letterGrade;
        }
        // creating a new class; Step 3: Define its Methods )+(actions)
    
      
    
        public void PrintCourseInfo()
        {
            Console.WriteLine("{0,20} {1,2} {2,3}", this.Name, this.LetterGrade, this.GradePoints);
        }
    }
    
    public class Student  
    {
        // step1: Define the properties
        private string _name;

        public string Name
        {
            get { return _name; } // Console.Write(myObj.Name)
            set { _name = value; } // myObj.Name = "Patrick Yee"
        }

        private List<Course> _courseList;

        public List<Course> CourseList
        {
            get { return _courseList; }
            set { _courseList = value; }
        }
        public double GPA
        {
            get
            {
                // total grade points
                return this.CourseList.Average(x => x.GradePoints);
            }
        }

        // other properties might include age, studentID, major, gender

        // step 2: Constructors !!
        public Student(string name)
        {
            this.Name = name;
            this.CourseList = new List<Course>(); // make sure to initialize list

        }

        // step 3 methods
        public void printStudentInfo()
        {
            Console.WriteLine("Name:  {0}", this.Name);
            foreach( Course course in this.CourseList)
            {
                course.PrintCourseInfo();
            }
           // Console.WriteLine
        }
        
    }
    }

