using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace realLab3
{
    public class Student
    {
        public string _name;
        public int Age { get; set; }
        public static string nation;
        private static string defaultName;
        private static int defaultAge;

        static Student()
        {
            nation = "Неизвестно";
            defaultName = "Неизвестно";
            defaultAge = 0;
        }

        public Student()
        {
            //используются стандартные данные
        }

        public Student(string name)
        {
            _name = name;
            Age = 0;
        }

        public Student(string name, int age)
        {
            _name = name;
            Age = age;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetAge(int newAge)
        {
            Age = newAge;
        }

        public int GetAge()
        {
            return Age;
        }

        public string WriteInfo()
        {
            return $"Студент {_name} имеет возраст {Age}, гражданство - {nation}";
        }

        public void BecomeOlder()
        {
            Age++;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student.nation = "Россия";

            Student s1 = new Student("Олег Монгол");
            Console.WriteLine(s1.WriteInfo());

            Student s2 = new Student("Боря Рейбакс", 14);
            Console.WriteLine(s2.WriteInfo());

            Student s3 = new Student();
            Console.WriteLine(s3.WriteInfo());

            s2.BecomeOlder();
            Console.WriteLine(s2.WriteInfo());
            Console.WriteLine("Все русские!");
        }
    }
}