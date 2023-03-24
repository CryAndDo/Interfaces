using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obeme
{
        internal class Date : ITriad
        {
            private int year, month, day;

            public int Year
            {
                get { return year; }
                set { if (value > 0 && value < 9999) year = value; }
            }
            public int Month
            {
                get { return month; }
                set { if (value > 0 && value < 13) month = value; }
            }
            public int Day
            {
                get { return day; }
                set { if (value > 0 && value < 32) day = value; }
            }

            public Date(int year, int month, int day)
            {
                Year = year;
                Month = month;
                Day = day;
            }
            public Date(string str)
            {
                int temp = int.Parse(str.Replace(".", ""));
                Year = temp / 10000;
                Month = (temp / 100) % 100;
                Day = temp % 100;
            }
            public Date(DateOnly date)
            {
                Year = date.Year;
                Month = date.Month;
                Day = date.Day;
            }

            public Date Data_cerez_Kolvo_day(int x)
            {
                DateOnly d = new DateOnly(Year, Month, Day);

                return new Date(d.AddDays(x));
            }
            public Date Sub_Zad_kolvo_day(int x)
            {
                DateOnly d = new DateOnly(Year, Month, Day);

                return new Date(d.AddDays(x));
            }
            public bool Visokos()
            {
                if (Year % 4 == 0)
                    return true;
                return false;
            }

            public bool CompareEqu(Date d)
            {
                return Year == d.Year && Month == d.Month && Day == d.Day;
            }
            public bool CompareBefore(Date d)
            {
                if (Year > d.Year)
                    return true;
                else if (Month > d.Month && Year == d.Year)
                    return true;
                else if (Day > d.Day && Month == d.Month && Year == d.Year)
                    return true;

                return false;
            }
            public bool CompareAfter(Date d)
            {
                if (Year < d.Year)
                    return true;
                else if (Month < d.Month && Year == d.Year)
                    return true;
                else if (Day < d.Day && Month == d.Month && Year == d.Year)
                    return true;

                return false;
            }
            public int Kolvo_day_mejdy_datami(Date t)
            {
                int d = (Year * 365 + Month * 30 + Day) - (t.Year * 365 + t.Month * 30 + t.Day);
                return Math.Abs(d);
            }



            public ITriad Addition1()
            {
                if (((Month <= 7 && Month % 2 != 0) || (Month > 7 && Month % 2 == 0)) && Day == 31
                    || (!(Month <= 7 && Month % 2 != 0 && Month > 7 && Month % 2 == 0) && Day == 30)
                    || (Month == 2 && (Day == 28 && !Visokos() || Day == 29 && Visokos())))
                {
                    Day = 1;
                    if (Month == 12) { Month = 1; Year++; }
                    else Month++;
                }
                else Day++;

                return new Date(Year, Month, Day);
            }

            public override string? ToString()
            {
                return $"{Year}.{Month}.{Day}";
            }
        }
    }

