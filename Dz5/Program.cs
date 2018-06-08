using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

namespace Dz5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Получить список конструкторов класса List<T>
            GetConstructorsFromList();


            //С помощью рефлексии вызвать метод Substring класса String и извлечь из строки подстроку заданного размера.
            GetSubstringFromString();


            //Описать класс с несколькими свойствами. Создать экземпляр класса и инициализировать его свойства.
            //С помощью рефлексии получить свойства и их значения из созданного экземпляра класса. 
            //Вывести полученные значения на экран
            GetValuesFromClassPerson();


            //С помощью рефлексии получить список методов класса Console и вывести на экран.
            ShowMethodsOfConsole();


            Console.ReadLine();
        }

        static void GetConstructorsFromList()
        {
            Type type = typeof(List<string>);
            foreach (ConstructorInfo item in type.GetConstructors())
            {
                Console.WriteLine(item.Name);
                foreach (ParameterInfo parameterInfo in item.GetParameters())
                {
                    Console.WriteLine("-->" + parameterInfo.Name);
                }
            }
        }
        static void GetSubstringFromString()
        {
            string str = "Nastya";
            Type t1 = typeof(String);
            foreach (MethodInfo m in t1.GetMethods()
                .OrderBy(o => o.Name)
                .Where(w => w.GetParameters().Count() > 1 && w.Name == "Substring"))
            {
                Console.WriteLine(m.Name);
                foreach (var p in m.GetParameters())
                {
                    Console.WriteLine("  ->" + p.Name);
                }

                var strSubstr = m.Invoke(str, new object[] { 0, 2 });
                Console.WriteLine(strSubstr);

            }
        }
        static void GetValuesFromClassPerson()
        {
            Person per = new Person();
            Type fieldsType = typeof(Person);

            PropertyInfo[] fields = fieldsType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            Console.WriteLine(fieldsType);

            foreach (PropertyInfo item in fields)
            {
                Console.WriteLine($"Name of property : {item.Name}\nValue : {item.GetValue(per)}\n");
            }
        }
        static void ShowMethodsOfConsole()
        {
            Assembly assemblyGenerate = Assembly.LoadFile(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\mscorlib.dll");

            Type[] types = assemblyGenerate.GetTypes();
            //получаем корневые элементы
            foreach (Type item in types)
            {

                if (item.Name == "Console")
                {
                    Console.WriteLine($"-> {item.Name} ({item.IsClass})");
                    foreach (MethodInfo method in item.GetMethods())
                    {
                        Console.WriteLine($"    -> {method.Name} - {method.ReturnType}");
                    }
                }
            }
        }
    }
}
