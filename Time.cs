using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obeme
{
    internal class Time : ITriad
    {
        //Поля класса
        private int hour, minute, second;

        //Геттеры и Сеттеры
        public int Hour
        {
            get { return hour; }
            set { if (value >= 0 && value < 24) hour = value; }
        }
        public int Minute
        {
            get { return minute; }
            set { if (value >= 0 && value < 60) minute = value; }
        }
        public int Second
        {
            get { return second; }
            set { if (value >= 0 && value < 60) second = value; }
        }

        //Конструкторы
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        public Time(string str)
        {
            int temp = int.Parse(str.Replace(":", ""));
            Hour = temp / 10000;
            Minute = (temp / 100) % 100;
            Second = temp % 100;
        }
        public Time(TimeOnly time)
        {
            Hour = time.Hour;
            Minute = time.Minute;
            Second = time.Second;
        }
        public Time(int sec)
        {
            Hour = sec / 3600;
            Minute = (sec % 3600) / 60;
            Second = (sec % 3600) % 60;
        }

        //Методы класса
        public int DifferenceBetween(Time t)
        {
            int moment1 = (Hour * 3600) + (Minute * 60) + Second;
            int moment2 = (t.Hour * 3600) + (t.Minute * 60) + t.Second;
            int difference = (moment1 - moment2);
            return Math.Abs(difference);
        }

        //Сложение
        public Time Addition(int sec)
        {
            int secs = (Hour * 3600) + (Minute * 60) + Second + sec;
            return new Time(secs);
        }
        public Time Addition(Time t)
        {
            int secs = (t.Hour * 3600) + (t.Minute * 60) + t.Second +
                        (Hour * 3600) + (Minute * 60) + Second;
            return new Time(secs);
        }

        //Вычитание
        public Time Subtract(int sec)
        {
            int secs = ((Hour * 3600) + (Minute * 60) + Second) - sec;
            if (secs < 0)
            {
                secs %= 86400;
                secs = 86400 - secs;
            }

            return new Time(secs);
        }

        public bool CompareEqu(Time d)
        {
            return Hour == d.Hour && Minute == d.Minute && Second == d.Second;
        }
        public bool CompareBefore(Time d)
        {
            if (Hour > d.Hour)
                return true;
            else if (Minute > d.Minute && Hour == d.Hour)
                return true;
            else if (Second > d.Second && Minute == d.Minute && Hour == d.Hour)
                return true;

            return false;
        }
        public bool CompareAfter(Time d)
        {
            if (Hour < d.Hour)
                return true;
            else if (Minute < d.Minute && Hour == d.Hour)
                return true;
            else if (Second < d.Second && Minute == d.Minute && Hour == d.Hour)
                return true;

            return false;
        }

        public int ToSeconds()
        {
            return (Hour * 3600) + (Minute * 60) + Second;
        }
        public int ToMinutes()
        {
            return (Hour * 60) + Minute;
        }

        //Перегрузка методов
        public ITriad Addition1()
        {
            if (Second + 1 == 60)
            {
                Second = 0;
                if (Minute + 1 == 60) { Minute = 0; Hour = (Hour + 1) % 24; }
                else Minute++;
            }
            else Second++;
            return new Time(Hour, Minute, Second);
        }

        public override string ToString()
        {
            return $"{Hour}:{Minute}:{Second}";
        }
    }
}

