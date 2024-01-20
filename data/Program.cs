using System;

class Date
{
    private int day;
    private int month;
    private int year;

    public Date(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    // Перегрузка оператора +
    public static Date operator +(Date date, int days)
    {
        return date.AddDays(days);
    }

    // Перегрузка оператора -
    public static Date operator -(Date date, int days)
    {
        return date.AddDays(-days);
    }

    // Перегрузка оператора ==
    public static bool operator ==(Date date1, Date date2)
    {
        return date1.Equals(date2);
    }

    // Перегрузка оператора !=
    public static bool operator !=(Date date1, Date date2)
    {
        return !date1.Equals(date2);
    }

    // Метод для добавления дней
    public Date AddDays(int days)
    {
        DateTime dt = new DateTime(year, month, day);
        dt = dt.AddDays(days);
        return new Date(dt.Day, dt.Month, dt.Year);
    }

    // Метод для вывода даты в формате "ДД.ММ.ГГГГ"
    public string ToShortDateString()
    {
        return $"{day:D2}.{month:D2}.{year:D4}";
    }

    // Метод для вывода даты в формате "Месяц День, Год"
    public string ToLongDateString()
    {
        DateTime dt = new DateTime(year, month, day);
        return dt.ToString("MMMM dd, yyyy");
    }

    // Переопределение метода Equals для сравнения объектов Date
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Date otherDate = (Date)obj;
        return day == otherDate.day && month == otherDate.month && year == otherDate.year;
    }

    // Переопределение метода GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(day, month, year);
    }
}
class Program
{
    static void Main()
    {
        Date date1 = new Date(20, 1, 2024);
        Date date2 = date1 + 7;
        Date date3 = date1 - 3;

        Console.WriteLine($"Date 1: {date1.ToShortDateString()}");
        Console.WriteLine($"Date 2 (after adding 7 days): {date2.ToShortDateString()}");
        Console.WriteLine($"Date 3 (after subtracting 3 days): {date3.ToShortDateString()}");

        Console.WriteLine($"Date 1 == Date 2: {date1 == date2}");
        Console.WriteLine($"Date 1 != Date 3: {date1 != date3}");

        Console.WriteLine($"Date 1 in long format: {date1.ToLongDateString()}");
    }
}