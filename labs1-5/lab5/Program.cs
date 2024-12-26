using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab5
{
    interface IPerson
    {
        string WriteInfo();
    }

    interface ISpecialist : IPerson
    {
        string SpecOut();
    }

    public class Student : IPerson, ICloneable, IComparable<Student>
    {
        public string _name;
        public int Age;
        public Subject subject;

        public Student()
        {
            _name = "Репа";
            Age = 111;
            subject = new Subject();
        }
        public Student(string name)
        {
            _name = name;
            Age = 0;
            subject = new Subject();
        }

        public Student(string name, int age)
        {
            _name = name;
            Age = age;
            subject = new Subject();
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
            return $"Студент {_name} имеет возраст {Age}. Его любимый предмет - {subject.name}";
        }

        public void BecomeOlder()
        {
            Age++;
        }

        public override string ToString()
        {
            return $"Студент {_name} имеет возраст {Age}. Его любимый предмет - {subject.name}";
        }

        public object Clone()
        {
            return new Student(_name, Age);
        }

        public int CompareTo(Student student)
        {
            if (student is null) throw new ArgumentException("Ошибка!");
            return Age - student.Age;
        }

    }

    public class ITStudent : Student, ISpecialist, IComparable<ITStudent>
    {
        //переопределение метода
        string ISpecialist.SpecOut()
        {
            return $"Студент {_name} является специалистом в IT-технологиях уже в {Age} лет! Его любимый предмет - {subject.name}";
        }

        //скрытие метода
        public new void SetName(string newName)
        {
            base.SetName(newName + "-слон");
        }

        public int CompareTo(ITStudent student)
        {
            if (student is null) throw new ArgumentException("Ошибка!");
            return Age - student.Age;
        }
    }

    public class Subject
    {
        public string name;

        public Subject()
        {
            name = "Алгебра";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            ISpecialist s1 = new ITStudent();
            Console.WriteLine(s1.SpecOut());

            Student s2 = new Student("Боря Рейбакс", 14);
            //Console.WriteLine(s2.WriteInfo());

            Student s3 = (Student)s2.Clone();
            //Console.WriteLine(s3.WriteInfo());

            Student s4 = new Student("Пашок Безумный", 53);
            //Console.WriteLine(s4.WriteInfo());

            Student[] studs = { s2, s3, s4 };
            Array.Sort(studs);

            foreach (Student student in studs)
            {
                Console.WriteLine($"{student._name} - {student.Age}");
            }
        }
    }
}