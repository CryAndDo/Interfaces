
using Obeme;

Console.Write("Введите год: ");
int year = int.Parse(Console.ReadLine());
Console.Write("Введите месяц: ");
int month = int.Parse(Console.ReadLine());
Console.Write("Введите день: ");
int day = int.Parse(Console.ReadLine());
Date date = new Date(year, month, day);
Console.WriteLine($"Метод увеличения на 1 (даты):{date.Addition1()}");

Console.Write("Введите часы: ");
int hour = int.Parse(Console.ReadLine());
Console.Write("Введите минуты: ");
int minute = int.Parse(Console.ReadLine());
Console.Write("Введите секунды: ");
int second = int.Parse(Console.ReadLine());
Time time = new Time(hour, minute, second);
Console.WriteLine($"Метод увеличения на 1 (времени): {time.Addition1()}");