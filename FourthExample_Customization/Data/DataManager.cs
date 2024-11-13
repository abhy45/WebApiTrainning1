using FourthExample_Customization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourthExample_Customization.Data
{
    public static class DataManager
    {
        private static List<Student> students = new List<Student>();
        static DataManager()
        {
            students = new List<Student>
            {
                new Student{ PhoneNo = "4523434234", StudentName ="Ram", StudentId = 1 },
                new Student{ PhoneNo = "2345676552", StudentName ="Shyam", StudentId = 2 },
                new Student{ PhoneNo = "7678884567", StudentName ="Sunder", StudentId = 3 },
                new Student{ PhoneNo = "2345556766", StudentName ="Mohan", StudentId = 4 }
            };
        }
        public static List<Student> GetStudents()
        {
            return students;
        }

        public static void AddStudent(Student s) => students.Add(s);
    }
}
