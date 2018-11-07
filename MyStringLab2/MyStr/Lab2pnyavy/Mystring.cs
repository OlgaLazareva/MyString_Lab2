//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab2pnyavy
{
    class Mystring
    {
        public char[] Text;



        //конструктор

        public Mystring()
        {
            Text = new char[512];
        }

        public Mystring(string temp)  //с одним параметром
        {
            Text = new char[temp.Length];
            for (int i = 0; i < temp.Length; i++)
                Text[i] = temp[i];

        }
        public Mystring(int tmp) //конструктор создающий пустую строку нашего типа заданной длины
        {
            Text = new char[tmp];

        }
        //длина массива
        public int Length
        {
            get { return this.Text.Length; } // возвращает длину массива
        }

        // Индексация.
        public char this[int index]
        {
            get // получить
            {
                return Text[index];
            }
            set // задать
            {
                Text[index] = value;
            }
        }

        //перегрузка операторов

        public static Mystring operator +(Mystring s1, Mystring s2) // сложение строк
        {
            Mystring strsum = new Mystring(s1.Length + s2.Length);
            for (int i = 0; i < s1.Length; i++)
                strsum.Text[i] = s1.Text[i];
            for (int i = 0; i < s2.Length; i++)
                strsum.Text[i + s1.Length] = s2.Text[i];
            return strsum;
        }

        public static bool operator ==(Mystring obj1, Mystring obj2) // сравнение по длине
        {
            if ((obj1.Text == null) && (obj2.Text == null)) return true;
            if (obj1.Length != obj2.Length)
                return false;
            else
            {
                for (int i = 0; i < obj1.Length; i++)
                    if (obj1.Text[i] != obj1.Text[i]) return false;
                return true;
            }
        }

        public static int Compare(Mystring obj1, Mystring obj2) // Сравнение по алфавиту
        {
            int result = 0;
            int min = Math.Min(obj1.Length, obj2.Length);
            for (int i=0; i<min; i++)
            {
                if (obj1[i] > obj2[2])
                    result = -1; // первая строка выше по алфавиту
                else if (obj1[i] < obj2[2])
                    result = 1; // первая ниже

            }
            return result; // если одинаковые
        }

        public static bool operator !=(Mystring obj1, Mystring obj2)
        {
            if (obj1 == obj2) return false;
            else return true;
        }

        //методы
        //1 метод
        public Mystring Replace(Mystring Str, char Old, char New, bool flag) //Замена символа - 1 ПЕРЕГРУЗКА
        {
            string TempText;
            TempText = Str; // Преобразование типов "Mystring" -> "string".
            int i = 0;
            foreach (char Simvol in TempText)
            {
                if (Simvol == Old)
                {
                    Str[i] = New;
                    if (flag) break;
                }
                i++;
            }
            return Str;
        }

        public Mystring Replace(Mystring Str, char Old, char New, int num) //замена символа с num элемента- 2 ПЕРЕГРУЗКА
        {
            string TempText;
            TempText = Str; // Преобразование типов "Mystring" -> "string".
            int i = 0;
            foreach (char Simvol in TempText)
            {
                if ((i >= num) & (Simvol == Old))
                {
                    Str[i] = New;
                }
                i++;

            }
            return Str;
        }
        //2 метод
        public int Index(Mystring s2) //поиск в строке  подстроки s2 - 1 ПЕРЕГРУЗКА
        {
            int findindex = -1;
            if (Text.Length >= s2.Length)
            {
                for (int i = 0; i < Text.Length - s2.Length + 1; i++)
                {
                    for (int j = 0; j < s2.Length; j++)
                    {
                        if (Text[i + j] != s2.Text[j]) break;
                        if (j == s2.Length - 1) findindex = i;
                    }
                    if (findindex > -1) break;
                }
            }
            return findindex;
        }

        public int Index(Mystring s2, int num) //поиск в строке  подстроки s2 начиная с элемента номер num - 2 ПЕРЕГРУЗКА
        {

            int findindex = -1;
            if (s2.Length + num <= Text.Length)
            {
                if (Text.Length >= s2.Length)
                {
                    for (int i = num; i < Text.Length - s2.Length + 1; i++)
                    {
                        for (int j = 0; j < s2.Length; j++)
                        {
                            if (Text[i + j] != s2.Text[j]) break;
                            if (j == s2.Length - 1) findindex = i;
                        }
                        if (findindex > -1) break;
                    }
                }
            }
            return findindex;
        }

        //3метод
        public Mystring Cut(int num, int count) //вырезать из строки символы начиная с num количеством count - 1 ПЕРЕГРУЗКА
        {
            Mystring chstr = new Mystring();

            if (num + count <= Text.Length)
            {
                Mystring Text_tmp = new Mystring(Text.Length - count);
                for (int i = 0; i < num; i++)
                    Text_tmp.Text[i] = Text[i];

                for (int i = num + count; i < Text.Length; i++)
                    Text_tmp.Text[i - count] = Text[i];

                Text =Text_tmp.Text;
            }
            for (int i = 0; i < Text.Length; i++)
                chstr[i] = Text[i];
            return chstr;
        }

        public Mystring Cut(Mystring s2) //вырезать из строки все вхождения подстроки s2 - 2 ПЕРЕГРУЗКА
        {
            Mystring chstr = new Mystring();
            if (s2.Length <= Text.Length)
            {
                Mystring Text_tmp = new Mystring();
                Mystring Text_tmp2 = new Mystring();
                int findindex = 1, n = 0;
                while (findindex != -1)
                {
                    findindex = -1;
                    if (Text.Length >= s2.Length)
                    {
                        for (int i = n; i < Text.Length - s2.Length + 1; i++)
                        {
                            for (int j = 0; j < s2.Length; j++)
                            {
                                if (Text[i + j] != s2.Text[j]) break;
                                if (j == s2.Length - 1) findindex = i;
                            }
                            if (findindex > -1) break;
                        }
                    }
                    if (findindex > -1)
                    {
                        Text_tmp2 = new Mystring(findindex);
                        for (int i = 0; i < findindex; i++)
                            Text_tmp2.Text[i] = Text[i];
                        n = findindex;

                        Text_tmp = new Mystring(this.Length - findindex - s2.Length);
                        for (int i = findindex + s2.Length; i < this.Length; i++)
                            Text_tmp.Text[i - findindex - s2.Length] = Text[i];
                        Text_tmp2 += Text_tmp;
                        Text = Text_tmp2.Text;
                    }
                }
                
            }
            for (int i = 0; i < Text.Length; i++)
                chstr[i] = Text[i];
            return chstr;
        }

        //4 метод substring подстрока
        public Mystring ApplySubstring(Mystring obj, int Ind) // взятие подстроки - 1 ПЕРЕГРУЗКА
        {
            string Text;
            Text = obj; // Преобразование типов "Mystring" -> "string".
            Mystring chstr = new Mystring();

            int i = 0;
            int j = 0;
            foreach (char Simvol in Text)
            {
                if (i >= Ind)
                {
                    chstr[j] += Text[i];
                    j++;
                }
                i++;
            }
            return chstr;
        }

        public int Lenght(string Text)   // длина строки
        {
            int i = 0;
            foreach (char smb in Text)
                i++;
            return (i);
        }

        public int FindSymbol(char symbol) // поиск символа
        {
            int i = 0;
            foreach (char Simvol in Text)
            {
                if (Simvol == symbol)
                    return i;
                i++;
            }
            return -1;
        }


        public Mystring ApplySubstring(Mystring obj, int Ind, int Count) // взятие подстроки с заданой длиной - 2 ПЕРЕГРУЗКА
        {
            string Text;
            Text = obj; // Преобразование типов "Mystring" -> "string".
            Mystring chstr = new Mystring();

            int i = 0;
            int j = 0;
            foreach (char Simvol in Text)
            {
                if ((i >= Ind) && (i <= Count+1))
                {
                    chstr[j] += Text[i];
                    j++;
                }
                i++;
            }
            return chstr;
        }

        


        // Преобразование типов "Mystring" -> "string".
        public static implicit operator string(Mystring MyStr) // неявное преобразование "Mystring" -> "string"
        {
            int len = MyStr.Length;
            char[] mch = new char[len];
            string chstr = "";
            for (int i = 0; i < MyStr.Length; i++)
            {
                mch[i] = MyStr[i];
            }
            for (int i = 0; i < MyStr.Length; i++)
            {
                chstr = chstr + mch[i];
            }
            return chstr;
        }

        // Преобразование типов "string" -> "Mystring".
        public static implicit operator Mystring(string Str) // неявное преобразование "string" -> "Mystring"
        {
            Mystring p = new Mystring(Str.Length);
            p = ToArray(Str.ToCharArray());
            return p;
        }

        public char[] ToArray(Mystring MyStr) // "Mystring" -> "char[]"
        {
            char[] res = new char[MyStr.Length];
            for (int i = 0; i < MyStr.Length; i++)
            {
                res[i] = MyStr.Text[i];
            }
            return res;
        }

        public static Mystring ToArray(char[] arr) // "char[]" -> "Mystring"
        {
            int p;
            Mystring res = new Mystring(arr.Length);
            p = arr.Length;
            for (int i = 0; i < p; i++)
            {
                res.Text[i] = arr[i];
            }
            return res;
        }


        
    }
}