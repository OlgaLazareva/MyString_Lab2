using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2pnyavy
{
    class Program
    {
        static void Main(string[] args)
        {
            Mystring myclass = new Mystring();
            Mystring str1, str2, str3;
            char rem, rep;
            int a, len;
            string line, output;

            do
            {
                Console.Clear();
                Console.WriteLine("\n[1]: Подстрока\n[2]: Подстрока с заданной длиной\n[3]: Длина строки\n[4]: Сравнение (+/==/!=)\n[5]: Индекс символа в строке\n[6]: Замена символа в строке\n[7]: Поиск по строке\n[8]: Удаление\n[9]: Выйти ");
                Console.WriteLine("Введите команду:");
                string answer = Console.ReadLine();
                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Вы ничего не выбрали");
                    continue;
                }
                int comand = Convert.ToInt32(answer);
               
                switch (comand)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите строку");
                            str1 = new Mystring(Console.ReadLine());
                            Console.WriteLine("После какого символа брать подстроку?");
                            a = Convert.ToInt32(Console.ReadLine());                          
                            Console.WriteLine("Подстрока: " + myclass.ApplySubstring(str1, a));
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите строку");
                            str1 = new Mystring(Console.ReadLine());
                            Console.WriteLine("После какого символа брать подстроку?");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Длина подстроки");
                            len = Convert.ToInt32(Console.ReadLine());
                            len--;
                            Console.WriteLine("Подстрока: " + myclass.ApplySubstring(str1, a, len));
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите строку");
                            str1 = Console.ReadLine();
                            Console.WriteLine("Длина строки: " + myclass.Lenght(str1));
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите строку");
                            str1 = new Mystring(Console.ReadLine());
                            Console.WriteLine("Введите еще одну строку");
                            str2 = new Mystring(Console.ReadLine());
                            Console.WriteLine("Сумма 2 строк: " + (str1 + str2));
                            if (str1==str2)
                                Console.WriteLine("Строки одинаковые по длине");
                            else Console.WriteLine("Строки не равны по длине");
                            Console.WriteLine(Mystring.Compare(str1, str2));
                            Console.ReadKey();
                            break;

                        }
                    case 5:
                        {
                            Console.WriteLine("Введите строку");
                            str1 = Console.ReadLine();
                            line = Convert.ToString(str1);
                            Mystring mycl = new Mystring(line);
                            Console.WriteLine("Введите символ");
                            char ch = Convert.ToChar(Console.ReadLine());
                            Console.WriteLine("Новая строка: " + mycl.FindSymbol(ch));
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Введите строку:");
                            str1 = new Mystring(Console.ReadLine());
                            Console.WriteLine("Введите заменяемый символ:");
                            rem = Convert.ToChar(Console.ReadLine());
                            Console.WriteLine("Введите заменяющий символ:");
                            rep = Convert.ToChar(Console.ReadLine());
                            // Console.WriteLine("Строка после замещения одного символа: " + myclass.Replace(str1, rem, rep, true));
                            // Console.WriteLine("Строка после замещения всех символов: " + myclass.Replace(str1, rem, rep, false));
                            Console.WriteLine("Введите номер символа с которого будет сделана замена:");
                            int num = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Строка после замещения всех символов после Num: " + myclass.Replace(str1, rem, rep, num));
                            Console.ReadKey();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Введите исходную строку:");
                            str1 = new Mystring(Console.ReadLine());
                            Console.WriteLine("Введите строку для поиска:");
                            str2 = new Mystring(Console.ReadLine());
                            Console.WriteLine("Задайте отступ:");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Индекс первого вхождения: " + str1.Index(str2));
                            Console.WriteLine("Индекс первого вхождения после отступа:" + str1.Index(str2, a));
                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Введите строку:");
                            str1 = new Mystring(Console.ReadLine());
                            str3 = new Mystring(str1);
                            Console.WriteLine("a)Индекс символа для начала удаления:");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Количество удаляемых символов:");
                            len = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("б)Удаляемая подстрока:");
                            str2 = new Mystring(Console.ReadLine());
                            Console.WriteLine("a)Полученная строка: " + str1.Cut(a, len));
                            Console.WriteLine("б)Полученная строка: " + str3.Cut(str2));
                            Console.ReadKey();
                            break;
                        }
                    case 9: Environment.Exit(0); break;
                    default: break;

                }
            } while (true);
        }
    }
}
