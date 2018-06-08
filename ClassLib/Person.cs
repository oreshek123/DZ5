using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    /*2.	Описать класс с несколькими свойствами. Создать экземпляр класса и инициализировать его свойства.
     С помощью рефлексии получить свойства и их значения из созданного экземпляра класса. Вывести полученные значения на экран*/
    public enum Gender
    {
        Male,Female
    }
    public class Person
    {
        public int Age { get; set; } = 18;
        public string Name { get; set; } = "Nastya";
        public string SerName { get; set; } = "Chentsova";
        public double Salary { get; set; } = 120123.5;
        public Gender Gender { get; set; } = Gender.Female;
    }
}
