using System;
using System.Collections;
using System.Linq;

namespace Chapter19
{
//C#不能直接在命名空间中直接声明变量或函数
    class Program
    {
        static void Main()
        {
            int[] numbers = {2,12,5,15};
            IEnumerable lowNums = 
                            from n in numbers
                            where n < 10
                            select n;
            foreach(var x in lowNums)
            {
                Console.Write("{0}, ", x);
            }
            Console.WriteLine();
            Console.WriteLine("************************************");

            var student = new {Name = "Mary Jones", Age = 19, Major = "History"};
            Console.WriteLine("{0}, Age {1}, Major: {2}", student.Name, student.Age, student.Major);
            Console.WriteLine("*************************************");

            int[] numbers1 = {2, 5, 28, 31, 17, 16, 42};
            var numsQuery = from n in numbers1
                            where n < 20
                            select n;
            
            var numsMethod = numbers1.Where(x => x < 20);

            int numsCount = (from n in numbers
                             where n < 20
                             select n).Count();
            
            foreach(var x in numsQuery)
                Console.Write("{0}, ", x);
            Console.WriteLine();

            foreach(var x in numsMethod)
                Console.Write("{0}, ", x);
            Console.WriteLine();

            Console.WriteLine(numsCount);
            Console.WriteLine("*************************************************");

            var query = from s in students
                        join c in studentsInCourses on s.StID equals c.StID
                        where c.CourseName == "History"
                        select s.LastName;

            foreach(var q in query)
                Console.WriteLine("Student taking Histroy: {0}", q);

        }

        public class Student
        {
            public int StID;
            public string LastName;
        }

        public class CourseStudent
        {
            public string CourseName;
            public int StID;
        }


        static Student[] students = new Student[]
        {
            new Student{StID = 1, LastName = "Carson"},
            new Student{StID = 2, LastName = "Klassen"},
            new Student{StID = 3, LastName = "Fleming"}
        };

        static CourseStudent[] studentsInCourses = new CourseStudent[]
        {
            new CourseStudent{CourseName = "Art",       StID = 1},
            new CourseStudent{CourseName = "Art",       StID = 2},
            new CourseStudent{CourseName = "History",   StID = 1},
            new CourseStudent{CourseName = "History",   StID = 3},
            new CourseStudent{CourseName = "Physics",   StID = 3}
        };
    }
}