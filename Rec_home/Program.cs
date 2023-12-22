using System.Diagnostics.Contracts;
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
 
   Double N;  Double M;
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


//Задача 3
//задать произвольный массив и вывести его элементы, начиная с конца
static void PrintArrayFromEnd ()
{
static void FillArray (int [] mas) // метод заполняет массив рандомными числами от 1 до 99
{
  for(int i = 0; i < mas.Length; i++)
  mas[i] = new Random().Next(1,100);

}

void ReArray(int [] array, int h) // рекурсивная функция выводит элементы массива, начиная с конца
{
   if (h < 0) return;
   else 
   {
      Console.Write(array[h] + " ");
      ReArray(array, h - 1);
   }
}

Console.WriteLine("Введите размер массива: "); // основное тело программы
int n = Convert.ToInt32(Console.ReadLine());
int [] mass = new int [n];
FillArray(mass);
Console.WriteLine(String.Join(" ",mass));
int h = mass.Length - 1;
Console.Write ("выводим массив в обратном порядке: ");
ReArray(mass,h); 
} // окончание меода PrintArrayFromEnd (задача 3)


//Задача 3.1
//задать произвольный массив и ПЕРЕЗАПИСАТЬ элементы массива в обратном порядке
static void PrintArrayFromEnd_1 ()
{
   static void FillArray_1 (int [] mas) // метод заполняет массив рандомными числами от 1 до 99
   {
     for(int i = 0; i < mas.Length; i++)
     mas[i] = new Random().Next(1,100);
   }

// рекурсивная функция переписывает элементы массива в обратном порядке
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

// основное тело программы
Console.WriteLine("Введите размер массива: "); 
int n = Convert.ToInt32(Console.ReadLine());
int [] mass = new int [n];                
FillArray_1(mass);
Console.WriteLine(String.Join(" ",mass)+ " проверяем: здесь элемент с индексом 1 = " + mass[1]); // печатаем первоначальный массив
int h = 0; 
Console.Write ("Элементы первоначального массива перезаписаны в обратном порядке: ");
mass = ReArray_1(mass,h);                  // в существующий массив mass перезаписываем элементы в обратном порядке
Console.WriteLine(String.Join(" ",mass) + " проверяем: теперь элемент с индексом 1 = " + mass[1]);

} // окончание меода PrintArrayFromEnd_1 (задача 3.1)


//------------------------------------------------------------------------------------------------------
// Console.WriteLine("Укажите, какую задачу хотите выполнить? (1-4)");
// Console.WriteLine("1 - программа выводит натуральные числа в промежутке [m,n], где m,n могут быть дробные");
// Console.WriteLine("2 - А");
// Console.WriteLine("3 - программа просто выводит созданный массив  в обратном порядке.");
// Console.WriteLine("4 - программа перезаписывает созданный массив в обратном порядке.");
// int nom = Convert.ToInt32(Console.ReadLine());
// switch(nom)
// {
//   case 1: GetNatureNumbersFromInterval(); break;// вызов задачи 1
//   //case 2: 
//   case 3: PrintArrayFromEnd(); break;           // вызов задачи 3
//   case 4: PrintArrayFromEnd_1(); break;         // вызов задачи 3.1
// }


//PrintArrayFromEnd_1();
PrintArrayFromEnd();