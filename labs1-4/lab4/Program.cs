using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab333
{
    abstract public class Person
    {
        public string _name;
        public int Age { get; set; }

        public virtual string WriteInfo()
        {
            return $"Человек {_name} имеет возраст {Age}";
        }
    }
    public class Student : Person
    {
        public Student()
        {
            _name = "Репа";
            Age = 111;
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

        public override string WriteInfo()
        {
            return $"Студент {_name} имеет возраст {Age}";
        }

        public void BecomeOlder()
        {
            Age++;
        }

        public override string ToString()
        {
            return $"Студент {_name} имеет возраст {Age}";
        }
    }
    public class ITStudent : Student
    {
        //переопределение метода
        public override string WriteInfo()
        {
            return $"IT-студент {_name} имеет возраст {Age}";
        }

        //скрытие метода
        public new void SetName(string newName)
        {
            base.SetName(newName + "-слон");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            ITStudent s1 = new ITStudent();
            Console.WriteLine(s1.WriteInfo());

            Student s2 = new Student("Боря Рейбакс", 14);
            Console.WriteLine(s2.WriteInfo());

            s2.BecomeOlder();
            Console.WriteLine(s2.WriteInfo());
        }
    }
}