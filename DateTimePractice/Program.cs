using System;
using System.Globalization;
using System.Threading;

namespace DateTimePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!" + Environment.NewLine);
            var helper = new DateHelper();
            var date = DateTime.Now;

            // standard formats
            Console.WriteLine("standard formats");
            Console.WriteLine(helper.Parse(date));
            Console.WriteLine(helper.Parse(date, "D"));
            Console.WriteLine(helper.Parse(date, "f"));
            Console.WriteLine(helper.Parse(date, "F"));
            Console.WriteLine(helper.Parse(date, "g"));
            Console.WriteLine(helper.Parse(date, "G"));
            Console.WriteLine(helper.Parse(date, "M"));
            Console.WriteLine(helper.Parse(date, "O"));
            Console.WriteLine();


            // custom formats
            Console.WriteLine("custom formats");
            Console.WriteLine(helper.Parse(date, "dd-MM-yyyy"));
            Console.WriteLine(helper.Parse(date, "dd-MMM-yyyy"));
            Console.WriteLine(helper.Parse(date, "ddd-MMM-yyyy"));
            Console.WriteLine();

            // format using standard format and culture
            Console.WriteLine("format using standard format and custom culture");
            Console.WriteLine(helper.Parse(date, "d", new CultureInfo("fr")));
            Console.WriteLine(helper.Parse(date, "f", new CultureInfo("fr")));
            Console.WriteLine(helper.Parse(date, "F", new CultureInfo("fr")));
            Console.WriteLine(helper.Parse(date, "g", new CultureInfo("fr")));
            Console.WriteLine(helper.Parse(date, "G", new CultureInfo("fr")));
            Console.WriteLine(helper.Parse(date, "M", new CultureInfo("fr")));
            Console.WriteLine(helper.Parse(date, "O", new CultureInfo("fr")));
            Console.WriteLine();

            // format using standard format and culture
            Console.WriteLine("format using standard format and custom culture");
            Console.WriteLine(helper.Parse(date, "d", new CultureInfo("gb")));
            Console.WriteLine(helper.Parse(date, "f", new CultureInfo("gb")));
            Console.WriteLine(helper.Parse(date, "F", new CultureInfo("gb")));
            Console.WriteLine(helper.Parse(date, "g", new CultureInfo("gb")));
            Console.WriteLine(helper.Parse(date, "G", new CultureInfo("gb")));
            Console.WriteLine(helper.Parse(date, "M", new CultureInfo("gb")));
            Console.WriteLine(helper.Parse(date, "O", new CultureInfo("gb")));
            Console.WriteLine();

            // format using custom format and custom culture
            Console.WriteLine("format using custom format and custom culture");
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("fr")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("fr-fr")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("en-fr")));
            Console.WriteLine();

            //
            Console.WriteLine("Finland");
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("fi")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("fi-FI")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("en-FI")));
            Console.WriteLine();

            //
            Console.WriteLine("German of different region");
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("de-AT")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("de-DE")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("de-CH")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("de-LI")));
            Console.WriteLine(helper.Parse(date, "dd MMMM yyyy", new CultureInfo("de-LU")));
            Console.WriteLine();

            // 
            Console.WriteLine(helper.Parse(date, "dd MMMM yy", new CultureInfo("en-US")));
            Console.WriteLine();

            Console.ReadKey();
        }

    }

    public class DateHelper
    {
        public DateTime ToDateTime(string value, string format = null, IFormatProvider formatProvider = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            var date = DateTime.ParseExact(value, format ?? "d", formatProvider ?? Thread.CurrentThread.CurrentUICulture);

            return date;
        }

        public DateTimeOffset ToDateTimeOffset(string value, string format = null, IFormatProvider formatProvider = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            var date = DateTimeOffset.ParseExact(value, format ?? "d", formatProvider ?? Thread.CurrentThread.CurrentUICulture);

            return date;
        }

        public string Parse(object value, string format = null, IFormatProvider formatProvider = null)
        {
            string parsedValue = null;
            if (value == null)
            {
                return parsedValue;
            }

            if (value is DateTime)
            {
                parsedValue = ((DateTime)value).ToString(format ?? "d", formatProvider ?? Thread.CurrentThread.CurrentUICulture);
            }

            if (value is DateTimeOffset)
            {
                parsedValue = ((DateTimeOffset)value).ToString(format ?? "d", formatProvider ?? Thread.CurrentThread.CurrentUICulture);
            }


            return parsedValue;
        }
    }
}
