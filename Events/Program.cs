using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Events
{
    public delegate void DoWork(string nameCompany, int ageStart);
    class Employee
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public Employee(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public override string ToString() { return ($"{surname} {name} {age} years"); }
        public void Gowork(string nameCompany, int ageStart)
        {
            if (age >= ageStart)
                WriteLine($"{surname} подходит для работы в {nameCompany}");
            else
                WriteLine($"{surname} по возрасту не подходит для работы в {nameCompany}");
        }

    }

    class Yandex
    {
        public event DoWork workYandex;
        public void Work(string nameCompany, int ageStart) { workYandex(nameCompany, ageStart); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>
            {
                new Employee ("Иван", "Петров", 25),
                new Employee ("Катя", "Иванова", 18),
                new Employee ("Олег", "Власов", 17),
                new Employee ("Митя", "Фомин", 15),
                new Employee ("Дима", "Гаврилов", 19),
                new Employee ("Иван", "Усович", 36),
            };
            Yandex yan = new Yandex();
            foreach (var item in emp) { yan.workYandex += item.Gowork; }
            WriteLine("+++++++++++++++++++++YANDEX++++++++++++++++++++++++");
            yan.Work("Yandex", 19);
            WriteLine("+++++++++++++++++++++GOOGLE++++++++++++++++++++++++");
            yan.Work("Google", 18);
            WriteLine("+++++++++++++++++++++RUSSIA++++++++++++++++++++++++");
            yan.Work("Президент РФ", 35);
            WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");


        }
    }
}
