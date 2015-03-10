using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceandInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee JohnMcClary = new Employee("John", "McClary", "Known Liar");
            Musician Laura = new Musician("Laura", "Boyd", "Piano");

            Bird bird = new Bird();

            List<ISing> listofThingsThatSing = new List<ISing>();
            listofThingsThatSing.Add(Laura);
            listofThingsThatSing.Add(bird);
            foreach (ISing somethingThatSings in listofThingsThatSing)
            {
                somethingThatSings.Sing();
            }

            Console.ReadKey();
        }

    }

    #region " Inheritance"
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        // constructor
        public Person(string fname, string lname)
        {
            this.FirstName = fname;
            this.Lastname = lname;
        }
        //methods
        public void Walk()
        {
            Console.WriteLine("whistling sounds");
        }


        //virtual because we are overriding the job class
        public virtual void Talk()
        {
            Console.WriteLine("Hey, what's up?");
        }
    }
    // employee inherits the person class (person is the parent class, employee is the child class)
    public class Employee : Person
    {
        // property
        public string JobTitle { get; set; }
        // constructor                                              : inherits
        public Employee(string fname, string lname, string jobTitle)
            : base(fname, lname)
        {
            this.JobTitle = jobTitle;
        }
        // methods
        // override s the base class method
        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("I'm a {0}. Synergize the paradigm.", this.JobTitle);

        }
    }
    public class Janitor : Employee
    {
        public int NumberOfBrooms { get; set; }

        public Janitor(string fname, string lname)
            : base(fname, lname, "Janitor")
        {
            this.NumberOfBrooms = 3;
        }


        //methods
        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("Im a person too");
        }

        public void Sweep()
        {
            Console.WriteLine(" sweep sweep sweep");
        }
        public void Clean()
        {
            Console.WriteLine(" squeaky squeaky");
        }
    }
    public class Musician : Employee, ISing
    {
        public string Instrument { get; set; }

        public Musician(string fname, string lname, string Instrument)
            : base(fname, lname, "Musician")
        {
            this.Instrument = Instrument;
        }



        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("I like to wail on my {0}", this.Instrument);
        }
        public void Jam()
        {
            Console.WriteLine("Jamming on my {0}", this.Instrument);
        }

        public void Sing()
        {
            Console.WriteLine("oohh, child of mine..");
        }
    }

    #endregion Inheritance

    #region "Interfaces"
    interface ISing
    {
        // framework for describine something that sings
        // provides no information on how it sings (does not implement how it sings)

        void Sing();
    }

    class Bird : ISing
    {
        public void Sing()
        {
            Console.WriteLine("chirp, chirp, chirp");
        }
    }

    interface ICombustionEngine
    {
        int FuelLevel { get; set; }
        void Refuel(int fuel);
        void Go();
    }
    interface IVehicle
    {
        int Velocity { get; set; }
    }
    interface IPowerOutput
    {
        int KilowattsGenerated { get; set; }
    }
    public class Jet : ICombustionEngine, IVehicle
    {
        public int Velocity { get; set; }
        public int FuelLevel { get; set; }

        public void Refuel(int fuel)
        {
            this.FuelLevel -= 25;
        }
        public Jet()
        {
            this.FuelLevel = 20;
        }
        public void Go()
        {
            if (FuelLevel > 25)
            {
                Console.WriteLine(" vroom, breaking sound barrier");
                this.Velocity += 400;
                this.FuelLevel -= 25;
            }
            else
            {
                Console.WriteLine("Out of gas");
            }
        }

    }


        public class Generator : ICombustionEngine, IPowerOutput
        {
            public int FuelLevel {get; set;}
            public Generator()
            {
                this.FuelLevel = 20;
            }
            public void Refuel(int fuel)
            {
                this.FuelLevel += fuel;
            }


            public void Go()
            {
                if (this.FuelLevel < 10)
                {
                    Console.WriteLine(" I'm producing 25KW");
                    this.KilowattsGenerated +=25;
                    this.FuelLevel -= 10;
                }
                else
                {
                    Console.WriteLine("Out of gas");
                }
            }
            public int KilowattsGenerated
            {
                get;
                set;
            }

        }


    #endregion

    }


    



    

   


