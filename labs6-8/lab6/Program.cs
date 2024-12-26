using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    abstract public class Person
    {
        public string _name;
        public int _age { get; set; }

        public virtual string WriteInfo()
        {
            return $"Человек {_name} имеет возраст {_age}";
        }
    }
    public class Student : Person
    {
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18)
                {
                    throw new ArgumentException("Возраст студента не может быть меньше 18-ти лет");
                }
                else
                {
                   _age = value;
                }
            }
        }
        public Student()
        {
            _name = "Репа";
            Age = 111;
        }
        public Student(string name)
        {
            _name = name;
            Age = 18;
        }

        public Student(string name, int age)
        {
            _name = name;
            try
            {
                Age = age;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Ошибка при установке возраста: {ex.Message}");
                Age = 18;
            }
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        public string GetName()
        {
            return _name;
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

            Student s1 = new Student();
            Console.WriteLine(s1.WriteInfo());

            Student s2 = new Student("Боря Рейбакс", 14);
            Console.WriteLine(s2.WriteInfo());

            s2.BecomeOlder();
            Console.WriteLine(s2.WriteInfo());
        }
    }
}
