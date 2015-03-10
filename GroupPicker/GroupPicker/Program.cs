using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupPicker
{
    class Program
    {
        static void Main(string[] args)
        {
                   PickGroup(3);
            Console.ReadKey();
        }
      
        /// This function takes in an integer for group size and uses , 
        /// <summar the string of student names to put into random groups
        /// </summary>
        /// <param name="groupSize">an int letting us know what size of group to put the students in</param>
        /// <returns></returns>
        static void PickGroup(int groupSize)
        {
        List <string> studentList = new List<string>() {"Eugene", "Patrick","linda", "Sergio", "Nate", "Michael", "Andrii", "Nicole", "Juli", "Andrew", "BrandonE", "BrandonS", "Maria", "Daniel", "Mike", "Laura", "Tim"};
        List<string> currentGroupList = new List<string>();
            int studentListCounter = studentList.Count;
            int groupNumber = 1;
        for (int i = 0; i< studentListCounter; i++)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, studentList.Count); // creates a number between 0 and number of students left
            var currentStudent = studentList[index]; //get a reference to the student
            currentGroupList.Add(currentStudent);// Put student in another list
            studentList.RemoveAt(index); //Remove

            if ((currentGroupList.Count == groupSize) || (studentList.Count == 0))
            {
               
                    Console.WriteLine("Group " + groupNumber);
                    for (int j = 0; j < currentGroupList.Count; j++)
                    {
                        Console.WriteLine(currentGroupList[j]);
                    }
                    // clear the current group
                    currentGroupList.Clear();
                    // increase the group number
                    groupNumber++;
              
            }
            

        }
        }
    
}
}