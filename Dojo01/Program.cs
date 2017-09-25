using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] scales = { "Celsius", "Fahrenheit", "Reamur", "Kelvin" };

            Console.WriteLine("Please enter measure units");
            Console.WriteLine("0 = Celsius, 1 = Fahrenheit, 2 = Reamur, 3 = Kelvin");
            string type = ReadTemperatureType(scales);

            Console.WriteLine("Please enter temperature value");
            double value = ReadTemperatureValue();

            Console.WriteLine(ConvertTemperature(scales, type, value));
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static string ReadTemperatureType(string[] scales)
        {
            for (; ; ) {
                try { return scales[Convert.ToInt32(Console.ReadLine())]; }
                catch (FormatException) { Console.WriteLine("Please enter value from 0 till 3"); }
                catch (OverflowException) { Console.WriteLine("Please enter value from 0 till 3"); }
                catch (IndexOutOfRangeException) { Console.WriteLine("Please enter value from 0 till 3"); }
            }
        }

        static double ReadTemperatureValue()
        {
            for (; ; )
            {
                try { return Convert.ToDouble(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine("Please enter decimal value"); }
                catch (OverflowException) { Console.WriteLine("Please enter decimal value"); }
            }
        }

        static string ConvertTemperature(string[] scales, string type, double value)
        {
            double baseCelsius;
            switch (type) {
                default:            baseCelsius = value; break;
                case "Fahrenheit":  baseCelsius = (value - 32) / 1.8; break;
                case "Kelvin":      baseCelsius = value - 273.15; break;
                case "Reamur":      baseCelsius = value * 1.25; break;
            }

            string result = "Temperature of " + value + " grad " + type + " is:\n";
            foreach (string scale in scales) {
                if (!scale.Equals(type))
                {
                    switch (scale) {
                        case "Celsius":     result += baseCelsius + " grad " + scale + "\n"; break;
                        case "Fahrenheit":  result += (baseCelsius * 1.8 + 32) + " grad " + scale + "\n"; break;
                        case "Kelvin":      result += (baseCelsius + 273.15) + " grad " + scale + "\n"; break;
                        case "Reamur":      result += (baseCelsius * 0.8) + " grad " + scale + "\n"; break;
                    }
                }
            }
            return result;
        }
    }
}
