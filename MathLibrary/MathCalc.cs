using System;
using System.Data;
using System.Runtime.ExceptionServices;
using System.Security;

namespace MathLibrary
{
    /// <summary>
    /// Библиотека математических операций, поддерживающая работу с целыми числами (int), 
    /// числами с плавающей точкой (double) и строковым представлением чисел.
    /// </summary>
    /// <remarks>
    /// <para>Основные возможности:</para>
    /// <list type="bullet">
    ///   <item>Арифметические операции: сложение, вычитание, умножение, деление.</item>
    ///   <item>Возведение в степень (только для целых степеней).</item>
    ///   <item>Вычисление квадратного корня (метод Ньютона).</item>
    /// </list>
    /// <para>Поддерживает обработку ошибок:</para>
    /// <list type="bullet">
    ///   <item>Проверка корректности входных данных (строки, отрицательные числа, деление на ноль).</item>
    ///   <item>Генерация исключений с информативными сообщениями.</item>
    /// </list>
    /// </remarks>
    /// <example>
    /// Пример использования:
    /// <code>
    /// double resultAdd = MathCalc.Add("5,5", "4,5"); // 10.0
    /// double resultSqrt = MathCalc.Sqrt(25); // 5.0
    /// </code>
    /// </example>
    public class MathCalc
    {
        /// <summary>
        /// Проверяет, можно ли преобразовать строку в число типа double.
        /// Если преобразование невозможно, выбрасывает исключение.
        /// </summary>
        /// <param name="number">Строка для проверки</param>
        /// <returns>Преобразованное число</returns>
        /// <exception cref="ArgumentException">Если строка не является числом</exception>
        public static double CheckContentsForDouble(string number)
        {
            bool result = double.TryParse(number, out double num);
            if (!result)
                throw new ArgumentException("Строка должна быть в виде числа! " +
                    "Если нужно показать остаток, то используем \",\" а не \".\"", nameof(number));
            return num;
        }

        /// <summary>
        /// Складывает два целых числа и возвращает результат как double.
        /// </summary>
        /// <param name="a">Первое слагаемое</param>
        /// <param name="b">Второе слагаемое</param>
        /// <returns>Сумма a и b в double</returns>
        public static double Add(int a, int b)
        {
            double result = a + b;
            return result;
        }

        /// <summary>
        /// Складывает два числа типа double.
        /// </summary>
        /// <param name="a">Первое слагаемое</param>
        /// <param name="b">Второе слагаемое</param>
        /// <returns>Сумма a и b</returns>
        public static double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Складывает два числа, представленных в виде строк.
        /// </summary>
        /// <param name="a">Первое число (строка)</param>
        /// <param name="b">Второе число (строка)</param>
        /// <returns>Сумма a и b</returns>
        /// <exception cref="ArgumentException">Если строки не являются числами</exception>
        public static double Add(string a, string b)
        {
            double numberA = CheckContentsForDouble(a);
            double numberB = CheckContentsForDouble(b);

            return numberA + numberB;
        }

        /// <summary>
        /// Вычитает два целых числа и возвращает результат как double.
        /// </summary>
        /// <param name="a">Уменьшаемое</param>
        /// <param name="b">Вычитаемое</param>
        /// <returns>Разность a и b в double</returns>
        public static double Substract(int a, int b)
        {
            double result = a - b;
            return result;
        }

        /// <summary>
        /// Вычитает два числа типа double.
        /// </summary>
        /// <param name="a">Уменьшаемое</param>
        /// <param name="b">Вычитаемое</param>
        /// <returns>Разность a и b</returns>
        public static double Substract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Вычитает два числа, представленных в виде строк.
        /// </summary>
        /// <param name="a">Уменьшаемое (строка)</param>
        /// <param name="b">Вычитаемое (строка)</param>
        /// <returns>Разность a и b</returns>
        /// <exception cref="ArgumentException">Если строки не являются числами</exception>
        public static double Substract(string a, string b)
        {
            double numberA = CheckContentsForDouble(a);
            double numberB = CheckContentsForDouble(b);

            return numberA - numberB;
        }

        /// <summary>
        /// Умножает два целых числа и возвращает результат как double.
        /// </summary>
        /// <param name="a">Первый множитель</param>
        /// <param name="b">Второй множитель</param>
        /// <returns>Произведение a и b в double</returns>
        public static double Multiply(int a, int b)
        {
            double result = a * b;
            return result;
        }

        /// <summary>
        /// Умножает два числа типа double.
        /// </summary>
        /// <param name="a">Первый множитель</param>
        /// <param name="b">Второй множитель</param>
        /// <returns>Произведение a и b</returns>
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Умножает два числа, представленных в виде строк.
        /// </summary>
        /// <param name="a">Первый множитель (строка)</param>
        /// <param name="b">Второй множитель (строка)</param>
        /// <returns>Произведение a и b</returns>
        /// <exception cref="ArgumentException">Если строки не являются числами</exception>
        public static double Multiply(string a, string b)
        {
            double numberA = CheckContentsForDouble(a);
            double numberB = CheckContentsForDouble(b);

            return numberA * numberB;
        }

        /// <summary>
        /// Делит два целых числа и возвращает результат как double.
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <returns>Частное a и b</returns>
        /// <exception cref="ArgumentException">Если делитель равен 0</exception>
        public static double Divide(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("На 0 делить нельзя! Параметр должен отличаться от 0", nameof(b));

            double numberA = Convert.ToDouble(a);
            double numberB = Convert.ToDouble(b);
            double result = numberA / numberB;
            return result;
        }

        /// <summary>
        /// Делит два числа типа double.
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <returns>Частное a и b</returns>
        /// <exception cref="ArgumentException">Если делитель равен 0</exception>
        public static double Divide(double a, double b)
        {
            if (b == 0.0)
                throw new ArgumentException("На 0 делить нельзя! Параметр должен отличаться от 0", nameof(b));
            return a / b;
        }

        /// <summary>
        /// Делит два числа, представленных в виде строк.
        /// </summary>
        /// <param name="a">Делимое (строка)</param>
        /// <param name="b">Делитель (строка)</param>
        /// <returns>Частное a и b</returns>
        /// <exception cref="ArgumentException">Если строки не являются числами или делитель равен 0</exception>
        public static double Divide(string a, string b)
        {
            double numberA = CheckContentsForDouble(a);
            double numberB = CheckContentsForDouble(b);

            if (numberB == 0.0)
                throw new ArgumentException("На 0 делить нельзя! Параметр должен отличаться от 0", nameof(b));

            return numberA / numberB;
        }

        /// <summary>
        /// Возводит целое число в целую степень.
        /// </summary>
        /// <param name="number">Основание степени</param>
        /// <param name="degree">Показатель степени (должен быть целым)</param>
        /// <returns>Результат возведения в степень</returns>
        /// <exception cref="ArgumentException">Если степень не целая</exception>
        public static double Pow(int number, int degree)
        {
            double num = Convert.ToDouble(number);
            double deg = Convert.ToDouble(degree);
            return Pow(num, deg);
        }

        /// <summary>
        /// Возводит число в степень (степень должна быть целой).
        /// </summary>
        /// <param name="number">Основание степени</param>
        /// <param name="degree">Показатель степени (должен быть целым)</param>
        /// <returns>Результат возведения в степень</returns>
        /// <exception cref="ArgumentException">Если степень не целая</exception>
        public static double Pow(double number, double degree)
        {
            if (degree % 1 != 0.0)
                throw new ArgumentException("Степень должна быть целым числом без остатка", nameof(degree));

            if (degree == 0.0)
                return 1.0;

            else if (degree > 0.0)
            {
                double pow = 0.0;
                for (int i = 1; i <= degree; i++)
                {
                    if (i == 1)
                    {
                        pow = number;
                        continue;
                    }
                    pow *= number;
                }
                return pow;
            }
            else
            {
                double numerator = 1.0;
                double denominator = 0.0;
                for (int i = -1; i >= degree; i--)
                {
                    if (i == -1)
                    {
                        denominator = number;
                        continue;
                    }
                    denominator *= number;
                }
                return numerator / denominator;
            }
        }

        /// <summary>
        /// Возводит число (в виде строки) в степень (в виде строки).
        /// </summary>
        /// <param name="number">Основание степени (строка)</param>
        /// <param name="degree">Показатель степени (строка, должен быть целым)</param>
        /// <returns>Результат возведения в степень</returns>
        /// <exception cref="ArgumentException">Если строки не являются числами или степень не целая</exception>
        public static double Pow(string number, string degree)
        {
            double num = CheckContentsForDouble(number);
            double deg = CheckContentsForDouble(degree);

            return Pow(num, deg);
        }

        /// <summary>
        /// Вычисляет квадратный корень из целого числа.
        /// </summary>
        /// <param name="number">Число, из которого извлекается корень</param>
        /// <returns>Квадратный корень числа</returns>
        /// <exception cref="ArgumentException">Если число отрицательное</exception>
        public static double Sqrt(int number)
        {
            double num = number;
            return Sqrt(num);
        }

        /// <summary>
        /// Вычисляет квадратный корень из числа (метод Ньютона).
        /// </summary>
        /// <param name="number">Число, из которого извлекается корень</param>
        /// <returns>Квадратный корень числа</returns>
        /// <exception cref="ArgumentException">Если число отрицательное</exception>
        public static double Sqrt(double number)
        {
            double epsilon = 1e-15;

            if (number < 0)
                throw new ArgumentException("Число не может быть отрицательным", nameof(number));

            if (number == 0)
                return 0;

            double currentApproximation = number;
            double difference;

            do
            {
                double nextApproximation = 0.5 * (currentApproximation + number / currentApproximation);
                difference = nextApproximation - currentApproximation;
                currentApproximation = nextApproximation;
            }
            while (!(difference < epsilon && difference > -epsilon));

            return currentApproximation;
        }

        /// <summary>
        /// Вычисляет квадратный корень из числа, представленного в виде строки.
        /// </summary>
        /// <param name="number">Число (строка)</param>
        /// <returns>Квадратный корень числа</returns>
        /// <exception cref="ArgumentException">Если строка не является числом или число отрицательное</exception>
        public static double Sqrt(string number)
        { 
            double num = CheckContentsForDouble(number);
            return Sqrt(num);
        }
    }
}