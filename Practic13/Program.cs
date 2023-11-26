
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practic13

{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1: Второе максимальное значение в List<int>
            List<int> numbers = new List<int> { /* инициализация списка */ };
            FindSecondMax(numbers);

            // Задача 2: Элементы списка больше среднего значения в List<double>
            List<double> doubleList = new List<double> { /* инициализация списка */ };
            PrintAboveAverage(doubleList);

            // Задача 3: Переписать числа в обратном порядке из одного файла в другой
            ReverseNumbersInFile("input.txt", "output.txt");

            // Задача 4: Сортировка данных сотрудников из файла
            List<Employee> employees = ReadEmployeesFromFile("employees.txt");
            SortAndPrintEmployees(employees);

            // Задача 5: Каталог музыкальных компакт-дисков
            CDCatalog catalog = new CDCatalog();
            // Добавление дисков и песен в каталог
            CD cd1 = new CD("Album 1", "Artist 1");
            cd1.AddSong("Song 1");
            cd1.AddSong("Song 2");
            catalog.AddCD(cd1);

            // Просмотр содержимого каталога
            catalog.PrintAllCDs();

            // Поиск всех записей заданного исполнителя
            catalog.PrintCDsByArtist("Artist 1");
        }

        static void FindSecondMax(List<int> numbers)
        {
            var sortedNumbers = numbers.OrderByDescending(n => n).Distinct().ToList();
            if (sortedNumbers.Count > 1)
            {
                int secondMax = sortedNumbers[1];
                int secondMaxIndex = numbers.IndexOf(secondMax);
                Console.WriteLine($"Second Max Value: {secondMax} at Position: {secondMaxIndex}");
            }
            numbers.RemoveAll(n => n % 2 != 0); // Удаление всех нечетных элементов
        }

        static void PrintAboveAverage(List<double> doubleList)
        {
            if (doubleList.Count > 0)
            {
                double average = doubleList.Average();
                var aboveAverage = doubleList.Where(n => n > average).ToList();
                aboveAverage.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }

        static void ReverseNumbersInFile(string inputPath, string outputPath)
        {
            string[] numbersFromFile = File.ReadAllLines(inputPath);
            Array.Reverse(numbersFromFile);
            File.WriteAllLines(outputPath, numbersFromFile);
        }

        static List<Employee> ReadEmployeesFromFile(string filePath)
        {
            // Реализация чтения данных о сотрудниках из файла
            return new List<Employee>();
        }

        static void SortAndPrintEmployees(List<Employee> employees)
        {
            var lessThan10000 = employees.Where(e => e.Salary < 10000);
            var moreOrEqual10000 = employees.Where(e => e.Salary >= 10000);

            foreach (var employee in lessThan10000.Concat(moreOrEqual10000))
            {
                Console.WriteLine($"{employee.FullName}, {employee.Salary}");
            }
        }
        public class Employee
        {
            public string FullName { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }
            // Конструктор и/или другие методы
        }
    }

    public class CD
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public List<string> Songs { get; private set; }

        public CD(string title, string artist)
        {
            Title = title;
            Artist = artist;
            Songs = new List<string>();
        }

        public void AddSong(string song)
        {
            Songs.Add(song);
        }

        public void RemoveSong(string song)
        {
            Songs.Remove(song);
        }

        public override string ToString()
        {
            return $"{Title} by {Artist}";
        }
    }


    public class CDCatalog
    {
        private Hashtable catalog;

        public CDCatalog()
        {
            catalog = new Hashtable();
        }

        public void AddCD(CD cd)
        {
            catalog[cd.Title] = cd;
        }

        public void RemoveCD(string title)
        {
            catalog.Remove(title);
        }

        public void PrintAllCDs()
        {
            foreach (CD cd in catalog.Values)
            {
                Console.WriteLine(cd);
                foreach (var song in cd.Songs)
                {
                    Console.WriteLine($" - {song}");
                }
            }
        }

        public void PrintCDsByArtist(string artist)
        {
            foreach (CD cd in catalog.Values)
            {
                if (cd.Artist == artist)
                {
                    Console.WriteLine(cd);
                    foreach (var song in cd.Songs)
                    {
                        Console.WriteLine($" - {song}");
                    }
                }
            }
        }
    }

}