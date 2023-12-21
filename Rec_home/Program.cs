using System.Xml.XPath;

//задача 1
void GetNatureNumbersFromInterval ()
{
   static string OutPutNumbers(int m, int n, string  str) 
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
        if (M < N)
        {
         if (M < 1) M = 1;
         int M_int = Convert.ToInt16(Math.Ceiling(M));
         int N_int = Convert.ToInt16(Math.Floor(N));
         string str = "";
         Console.WriteLine(OutPutNumbers(M_int,N_int, str) + " - натуральные числа в промежутке [" + M_write + "; " + N + "]");
        }
         else //если M > N
        {
          Console.WriteLine ("Вводимое число M начала промежутка должно быть МЕНЬШЕ N.");
          Console.WriteLine ("Попробуйте еще раз.");
        }
    }
}


GetNatureNumbersFromInterval(); // вызов задачи 1


//Задача 2

