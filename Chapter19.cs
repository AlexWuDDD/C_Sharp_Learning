using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace Chapter19
{
//C#不能直接在命名空间中直接声明变量或函数
    class Program
    {
        static void MainTest()
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
            Console.WriteLine("**************************************************");

            var groupA = new[]{3,4,5,6};
            var groupB = new[]{6,7,8,9};

            var someInts = from a in groupA
                           from b in groupB
                           where a > 4 && b <=8
                           select new{a,b, sum = a + b};
            foreach(var a in someInts)
                Console.WriteLine(a);
            Console.WriteLine("**************************************************");

            var someInts1 = from a in groupA
                            from b in groupB
                            let sum = a + b
                            where sum == 12
                            select new{a, b, sum};
            
            foreach(var a in someInts1)
                Console.WriteLine(a);
            Console.WriteLine("**************************************************");

            var students1 = new[]
            {
                new{LName = "Jones",    FName = "Mary",     Age = 19, Major = "History"},
                new{LName = "Smith",    FName = "Bob",      Age = 20, Major = "CompSci"},
                new{LName = "Fleming",  FName = "Carol",    Age = 21, Major = "History"}
            };

            var query1 = from student1 in students1
                        orderby student1.Age
                        select student1;

            foreach(var s1 in query1)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}",
                            s1.LName, s1.FName, s1.Age, s1.Major );
            }
            Console.WriteLine("***************************************");

            var query2 = from student2 in students1
                        group student2 by student2.Major;
            
            foreach(var s in query2)
            {
                Console.WriteLine("{0}", s.Key);

                foreach(var t in s)
                    Console.WriteLine("     {0}, {1}", t.LName, t.FName);
            }
            Console.WriteLine("*****************************************");

            var groupC = new[]{3,4,5,6};
            var groupD = new[]{4,5,6,7};

            var someInts8 = from c in groupC
                            join d in groupD on c equals d
                            into groupCandD
                            from x in groupCandD
                            select x;
            
            foreach(var y in someInts8)
                Console.Write("{0} ", y);
            Console.WriteLine();
            Console.WriteLine("****************************************");

            int[] numbersX = new int[] {2,4,6};
            int total = numbersX.Sum();
            int howMany = numbersX.Count();

            Console.WriteLine("Total: {0}, Count: {1}", total, howMany);
            Console.WriteLine("*****************************************");

            XDocument employees1 = 
                new XDocument(
                    new XElement("Employees",
                        new XElement("Name", "Bob Smith"),
                        new XElement("Name", "Sally Jones")
                    )
                );

            //employees1.Save("EmployeesFile.xml");
            XDocument employees2 = XDocument.Load("C:\\Users\\e823551\\Documents\\MyC#Learning\\EmployeesFile.xml");
            Console.WriteLine(employees2);
            Console.WriteLine("************************************************");

            XDocument employeeDoc = 
                    new XDocument(
                        new XElement("Employees",
                            new XElement("Employee",
                                new XElement("Name", "Bob Simith"),
                                new XElement("PhoneNumber", "408-555-1000")),
                                
                            new XElement("Employee",
                                new XElement("Name", "Sally Jones"),
                                new XElement("PhoneNumber", "415-555-2000"),
                                new XElement("PhoneNumber", "415-555-2001"))
                        )
                    );
            
            //Console.WriteLine(employeeDoc);
            XElement root = employeeDoc.Element("Employees");
            IEnumerable employees = root.Elements();
            foreach(XElement emp in employees)
            {
                XElement empNameNode = emp.Element("Name");
                Console.WriteLine(empNameNode.Value);

                IEnumerable empPhones = emp.Elements("PhoneNumber");
                foreach(XElement phone in empPhones)
                    Console.WriteLine("     {0}",phone.Value);
            }
            Console.WriteLine("********************************************");

            XDocument xd = new XDocument
            (
                new XElement("root",
                    new XElement("first")
                )
            );
            Console.WriteLine("Original tree");
            Console.WriteLine(xd);
            Console.WriteLine();

            XElement rt = xd.Element("root");
            rt.Add(new XElement("Second"));

            rt.Add(new XElement("third"),
                   new XComment("Important Comment"),
                   new XElement("fourth"));
            
            Console.WriteLine("Modified tree");
            Console.WriteLine(xd);
            Console.WriteLine("***************************************");

            XDocument xd1 = new XDocument
            (
                new XElement("root",
                        new XAttribute("color", "red"),
                        new XAttribute("size", "large"),
                    new XElement("first"),
                    new XElement("second")
                )
            );
            Console.WriteLine(xd1);
            Console.WriteLine();

            XElement rt1 = xd1.Element("root");
            XAttribute color = rt1.Attribute("color");
            XAttribute size = rt1.Attribute("size");

            Console.WriteLine("color  is {0}", color.Value);
            Console.WriteLine("size   is {0}", size.Value);

            rt1.Attribute("color").Remove(); //移除color特性
            rt1.SetAttributeValue("size", null); //移除size特性

            Console.WriteLine(xd1);
            Console.WriteLine();

            rt1.SetAttributeValue("size", "medium");
            rt1.SetAttributeValue("width", "narrow");
            Console.WriteLine(rt1);
            Console.WriteLine();
            Console.WriteLine("*************************************************");
            
            XDocument xd2 = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("This is a comment"),
                new XProcessingInstruction("xml-stylesheet", @"href=""stories-css"" type=""text/css"""),
            
                new XElement("root",
                    new XElement("first"),
                    new XElement("second")
                )
            );
            Console.WriteLine(xd2);
            Console.WriteLine("*************************************************");

            XDocument xd3 = new XDocument(
                new XElement("MyElements",
                    new XElement("first",
                        new XAttribute("color", "red"),
                        new XAttribute("size", "small")
                    ),

                    new XElement("second",
                        new XAttribute("color", "red"),
                        new XAttribute("size", "medium")
                    ),

                    new XElement("third",
                        new XAttribute("color", "blue"),
                        new XAttribute("size", "large")
                    )
                )
            );

            Console.WriteLine(xd3);

            XElement rt3 = xd3.Element("MyElements");

            var xyz = from e in rt3.Elements()
                      where e.Name.ToString().Length == 5
                      select e;

            foreach(XElement x in xyz)
                Console.WriteLine(x.Name.ToString());
            
            Console.WriteLine();
            foreach(XElement x in xyz)
                Console.WriteLine("Name: {0}, color: {1}, size: {2}",
                                x.Name,
                                x.Attribute("color").Value,
                                x.Attribute("size").Value);
            Console.WriteLine("************************************************");

            var xyz1 = from e in rt3.Elements()
                       select new{e.Name, color = e.Attribute("color")};
            
            foreach(var x in xyz1)
                Console.WriteLine(x);
            
            Console.WriteLine();
            foreach(var x in xyz1)
                Console.WriteLine("{0,-6},  color:{1,-7}",x.Name, x.color.Value);



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