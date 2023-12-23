using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Xml.XPath;

//задача 1
void GetNatureNumbersFromInterval ()
{
   static string OutPutNumbers(int m, int n, string  str) //рекурсивная функция выводит натуральные числа в [m,n]
   {
     if (m == n) return str + " " + n;
     else 
     {
       return OutPutNumbers(m+1, n, str + " "+ m); 
     }
   }
 
   Double N;  
   Double M;
   Console.WriteLine("Введите промежуток [M,N], для которого нужно вывести натуральные числа");
   Console.WriteLine("M,N - могут быть дробными");
   Console.Write("Введите число M: "); 
   M = Convert.ToDouble(Console.ReadLine());
   Console.Write("Введите число N: "); 
   N = Convert.ToDouble(Console.ReadLine());

   double M_write = M;
   if ((M < 1) && (N < 1)) 
   {
     Console.WriteLine ("В данном промежутке нет натуральных чисел.");
   }
    else 
    {
        if (M <= N) 
        {
          if (M < 1) M = 1;
          int M_int = Convert.ToInt32(Math.Ceiling(M));
          int N_int = Convert.ToInt32(Math.Floor(N));
          string str = "";
          Console.WriteLine(OutPutNumbers(M_int,N_int, str) + " - натуральные числа в промежутке [" + M_write + "; " + N + "]");
        }
         else //если M > N
        {
          Console.WriteLine ("Вводимое число M начала промежутка должно быть МЕНЬШЕ N.");
          Console.WriteLine ("Попробуйте еще раз.");
        }
    }
} // окончание метода GetNatureNumbersFromInterval (задача 1)


//функция Аккермана Задача 2
static void Function_Akkermana ()
{
   static int  Akkerman (int m, int n)  //рекурсивная функция Аккермана
   {
     if (m == 0) return n+1;
     else if ((m > 0) && (n == 0)) return Akkerman(m-1,1);
          else  return Akkerman(m-1, Akkerman(m,n-1));
   }

    Console.WriteLine("Введите числа m,n (m,n > 0)");
    Console.Write("Задайте m: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write("Задайте n: ");
    int n = Convert.ToInt32(Console.ReadLine());

    if ((m >=0) && (n >= 0))
    {
       int res = Akkerman (m,n);
       Console.WriteLine("A (" + m + ", " + n + ") = " + res);
    }
    else Console.WriteLine("Введенные числа должны быть больше либо равны нулю.");
} //окончание метода Function_Akkermana (Задача 2)


// рекурсивная функция заполняет массив рандомными числами от 1 до 99 (для задач 3 и 3.1)
static int [] FillArray (int [] mas, int i) 
{
  if (i >= mas.Length) return mas;
  else 
  {
     mas[i] = new Random().Next(1,100);
     return mas = FillArray(mas, i+1);
  }
}

//Задача 3
//задать произвольный массив и вывести его элементы, начиная с конца
static void PrintArrayFromEnd ()
{
   void ReArray(int [] array, int h) // рекурсивная функция выводит элементы массива, начиная с конца
   {
      if (h < 0) return;
      else 
      {
         Console.Write(array[h] + " ");
         ReArray(array, h - 1);
      }
   }
   // основное тело метода (Задача 3)
   Console.WriteLine("Введите размер массива: "); 
   int n = Convert.ToInt32(Console.ReadLine());
   if (n > 0)
   {
     int [] mass = new int [n];
     int i = 0;
     mass = FillArray(mass,i); //вызов рекурсивной функции, заполняющей массив рандомными числами
     Console.WriteLine(String.Join(" ",mass)); //печатаем заполненный массив
     int h = mass.Length - 1;
     Console.Write ("выводим массив в обратном порядке: ");
     ReArray(mass,h); //вызов рекурсивной функции, печатающей массив в обратном порядке
   }
   else Console.WriteLine("Число элементов массива должно быть больше нуля."); 
} // окончание метода PrintArrayFromEnd (задача 3)



//Задача 3.1
//задать произвольный массив и ПЕРЕЗАПИСАТЬ элементы массива в обратном порядке
static void FillArrayFromEnd ()
{
// рекурсивная функция перезаписывает элементы массива в обратном порядке
// функция получает на вход какой-то массив и возвращает на выход массив с переставленными элементами
  int [] ReArray_1(int [] array, int h) //h - индекс
  {
    if (h >= array.Length/2) return array;
    else 
    {
       int temp = array[h];
       array[h] = array [array.Length - h - 1];
       array [array.Length - h - 1] = temp;
       array = ReArray_1(array, h + 1);
       return array;
    }
 }
  // основное тело метода PrintArrayFromEnd_1
  Console.WriteLine("Введите размер массива: "); 
  int n = Convert.ToInt32(Console.ReadLine());
  if (n >=0 )
  {
  int [] mass = new int [n];  
  switch (n)
  {
        case (> 1): 
          {
          int i = 0;
          mass = FillArray(mass, i);
          Console.WriteLine("Сформированный массив: " + String.Join(" ",mass));
          Console.WriteLine(" проверяем: в первоначальном массиве элемент с индексом 1 = " + mass[1]); 
          int h = 0; 
          Console.Write ("Элементы первоначального массива перезаписаны в обратном порядке: ");
          mass = ReArray_1(mass,h);     // вызов рекурсивной функции, перезаписывающей массив в обратном порядке
          Console.WriteLine(String.Join(" ",mass) + " проверяем: теперь элемент с индексом 1 = " + mass[1]);
          break;
          }
        case 1: 
        {
          int i = 0;
          mass = FillArray(mass, i);
          Console.WriteLine("Сформированный массив: " + String.Join(" ",mass));
          Console.WriteLine("Массив не изменится: " + mass[0]); 
          break;
        }
        case 0: Console.WriteLine("Число элементов массива должно быть больше нуля."); break;
  }
  }
  else Console.WriteLine("Число элементов массива не может быть отрицательным числом!");            
} // окончание метода FillArrayFromEnd (задача 3.1)


//------------------------------------------------------------------------------------------------------
Console.WriteLine("Укажите, какую задачу хотите выполнить? (1-4)");
Console.WriteLine("1 - программа выводит натуральные числа в промежутке [m,n], где m,n могут быть дробные");
Console.WriteLine("2 - программа считает функцию Аккермана A(m,n)");
Console.WriteLine("3 - программа просто выводит созданный массив  в обратном порядке.");
Console.WriteLine("4 - программа перезаписывает созданный массив в обратном порядке.");
int nom = Convert.ToInt32(Console.ReadLine());
switch(nom)
{
  case 1: GetNatureNumbersFromInterval(); break; // вызов задачи 1
  case 2: Function_Akkermana(); break;           // вызов задачи 2
  case 3: PrintArrayFromEnd(); break;            // вызов задачи 3
  case 4: FillArrayFromEnd(); break;             // вызов задачи 3.1
}



//GetNatureNumbersFromInterval();
//Function_Akkermana ();
//FillArrayFromEnd();
//PrintArrayFromEnd();



