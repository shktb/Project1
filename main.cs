using FirstClass;
using ClassPaper;
using LabResearch;
using EnumTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main()
        {

            // 1. Создать один объект ResearchTeam и вывести ToShortString()
            ResearchTeam team = new ResearchTeam("Квантовые вычисления", "МГУ", 404, TimeFrame.Year);
            Console.WriteLine("--- Пункт 1: ToShortString ---");
            Console.WriteLine(team.ToShortString());
            Console.WriteLine();

            // 2. Вывести значения индексатора для Year, TwoYears, Long
            Console.WriteLine("--- Пункт 2: Проверка индексатора ---");
            Console.WriteLine($"TimeFrame.Year: {team[TimeFrame.Year]}");
            Console.WriteLine($"TimeFrame.TwoYears: {team[TimeFrame.TwoYears]}");
            Console.WriteLine($"TimeFrame.Long: {team[TimeFrame.Long]}");
            Console.WriteLine();

            // 3. Присвоить значения всем свойствам и вывести ToString()
            Console.WriteLine("--- Пункт 3: Изменение свойств и ToString ---");
            team.Theme = "Биоинформатика";
            team.Organization = "СПбГУ";
            team.RegistrationNumber = 505;
            team.Duration = TimeFrame.Long;
            Console.WriteLine(team.ToString());
            Console.WriteLine();

            // 4. Добавить элементы через AddPapers и вывести данные
            Console.WriteLine("--- Пункт 4: Добавление публикаций (AddPapers) ---");
            Person author = new Person("Иван", "Иванов", new DateTime(1995, 5, 10));

            Paper p1 = new Paper("Исследование ДНК", author, new DateTime(2023, 10, 1));
            Paper p2 = new Paper("Нейросети в медицине", author, new DateTime(2025, 3, 15));

            team.AddPapers(p1, p2);
            Console.WriteLine(team.ToString());
            Console.WriteLine();

            // 5. Вывести самую позднюю публикацию
            Console.WriteLine("--- Пункт 5: Самая поздняя публикация ---");
            Paper latest = team.LatestPaper;
            Console.WriteLine(latest != null ? latest.ToString() : "Список пуст");
            Console.WriteLine();

            // 6. Сравнение времени выполнения для массивов объектов Paper (одномерный, прямоугольный, ступенчатый)
            Console.WriteLine("--- Пункт 6: Замер времени массивов Paper ---");
            int nrow = 1000, ncolumn = 1000;
            int total = nrow * ncolumn;

            Paper[] oneDim = new Paper[total];
            Paper[,] twoDim = new Paper[nrow, ncolumn];
            Paper[][] jagged = new Paper[nrow][];
            for (int i = 0; i < nrow; i++) jagged[i] = new Paper[ncolumn];

            // Инициализация
            for (int i = 0; i < total; i++) oneDim[i] = new Paper();
            for (int i = 0; i < nrow; i++)
                for (int j = 0; j < ncolumn; j++)
                {
                    twoDim[i, j] = new Paper();
                    jagged[i][j] = new Paper();
                }

            // Замер для одномерного
            int start = Environment.TickCount;
            for (int i = 0; i < total; i++) oneDim[i].Title = "Updated";
            int t1 = Environment.TickCount - start;

            // Замер для двумерного прямоугольного
            start = Environment.TickCount;
            for (int i = 0; i < nrow; i++)
                for (int j = 0; j < ncolumn; j++)
                    twoDim[i, j].Title = "Updated";
            int t2 = Environment.TickCount - start;

            // Замер для ступенчатого
            start = Environment.TickCount;
            for (int i = 0; i < nrow; i++)
                for (int j = 0; j < ncolumn; j++)
                    jagged[i][j].Title = "Updated";
            int t3 = Environment.TickCount - start;

            Console.WriteLine($"Одномерный массив: {t1} мс");
            Console.WriteLine($"Прямоугольный массив: {t2} мс");
            Console.WriteLine($"Ступенчатый массив: {t3} мс");

            // Equals Validation

            Paper p1Copy = new Paper("Исследование ДНК", author, new DateTime(2023, 10, 1));
            Paper p1_ref = p1;

            bool result_equals = Object.Equals(p1, p1Copy);
            bool result = p1 == p1Copy;

            bool result_equals_ref = Object.Equals(p1, p1_ref);
            bool result_ref = p1 == p1_ref;

            Console.WriteLine("Проверка equals");
            Console.WriteLine($"Результат equals: {result_equals}");
            Console.WriteLine($"Результат сравнения: {result}");

            Console.WriteLine($"Результат equals: {result_equals_ref}");
            Console.WriteLine($"Результат сравнения: {result_ref}");

            Console.ReadLine();
        }
    }
}

