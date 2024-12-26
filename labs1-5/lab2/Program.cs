using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab333
{
    // Класс Subject
    public class Subject
    {
        public string Name { get; set; }

        public Subject(string subjectName)
        {
            Name = subjectName;
        }
    }

    // Класс Game
    public class Game
    {
        public string Title { get; set; }

        public Game(string gameTitle)
        {
            Title = gameTitle;
        }
    }

    public class Student
    {
        private string _name;
        public int Age { get; set; }

        // Поля с модификатором private
        private Subject _favoriteSubject;
        private Game _favoriteGame;

        public Student(string name)
        {
            _name = name;
            Age = 0;
            _favoriteSubject = null;
            _favoriteGame = null;
        }

        public Student(string name, int age)
        {
            _name = name;
            Age = age;
            _favoriteSubject = null;
            _favoriteGame = null;
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

        public void SetFavoriteSubject(Subject favoriteSubject)
        {
            _favoriteSubject = favoriteSubject;
        }

        public Subject GetFavoriteSubject()
        {
            return _favoriteSubject;
        }

        public void SetFavoriteGame(Game favoriteGame)
        {
            _favoriteGame = favoriteGame;
        }

        public Game GetFavoriteGame()
        {
            return _favoriteGame;
        }

        public string WriteInfo()
        {
            return $"Студент {_name} имеет возраст {Age}." + Environment.NewLine +
                   $"Любимый предмет: {(_favoriteSubject != null ? _favoriteSubject.Name : "Не указан")}" + Environment.NewLine +
                   $"Любимая игра: {(_favoriteGame != null ? _favoriteGame.Title : "Не указана")}";
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
            // Создание объекта первого студента
            Student s1 = new Student("Олег Монгол");
            s1.SetFavoriteSubject(new Subject("Информатика"));
            s1.SetFavoriteGame(new Game("CSGO"));
            Console.WriteLine(s1.WriteInfo());

            // Создание объекта второго студента
            Student s2 = new Student("Боря Рейбакс", 14);
            s2.SetFavoriteSubject(new Subject("Физика"));
            s2.SetFavoriteGame(new Game("FIFA"));
            Console.WriteLine(s2.WriteInfo());

            // Передача параметра по значению
            var oldS2 = s2;
            s2.BecomeOlder();
            Console.WriteLine($"Старый S2: {oldS2.GetAge()}");
            Console.WriteLine($"Новый S2: {s2.GetAge()}");

            // Передача параметра по ссылке
            s2.SetAge(20);
            Console.WriteLine($"Текущий S2: {s2.GetAge()}");

            Console.ReadKey();
        }
    }
}