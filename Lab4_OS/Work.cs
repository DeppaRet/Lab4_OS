using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_OS
{
  class Work
  {
    public static void Find()
    {
      string start;
      start = File.ReadAllText("./test.txt");
      int[] startA = new int[4];
      int[] startB = new int[4];
      int[] startC = new int[4];
      int[] startD = new int[4];
      int[] endA = new int[4];
      int[] endB = new int[4];
      int[] endC = new int[4];
      int[] endD = new int[4];
      int[] used = new int[4];
      int[] needed = new int[4];
      int[] free = { 4, 4, 4, 4 };
      bool[] checkedR = new bool[4];
      string[] res = new string[4];
      var tmp = start.Split(' ');
      int k = 4;
      for (int i = 0; i < k; i++)
      {
        startA[i] = Convert.ToInt32(tmp[i]);
        endA[i] = Convert.ToInt32(tmp[i + 4]);
        startB[i] = Convert.ToInt32(tmp[i + 8]);
        endB[i] = Convert.ToInt32(tmp[i + 12]);
        startC[i] = Convert.ToInt32(tmp[i + 16]);
        endC[i] = Convert.ToInt32(tmp[i + 20]);
        startD[i] = Convert.ToInt32(tmp[i + 24]);
        endD[i] = Convert.ToInt32(tmp[i + 28]);
      }
      Console.WriteLine("Введите количество ресурсов (каждое значение вводить с новой строки): ");
      for (int i = 0; i < k; i++)
      {
        free[i] = Check.GetInt();
      }
      Console.WriteLine("Всего ресурсов предоставлено: " + free[0] + " " + free[1] + " " + free[2] + " " + free[3]);
      Console.WriteLine("           Предоставлено ресурсов    Максимальная потребность");
      Console.WriteLine("Процесс A:          " + startA[0] + " " + startA[1] + " " + startA[2] + " " + startA[3] + "                   " + endA[0] + " " + endA[1] + " " + endA[2] + " " + endA[3]);
      Console.WriteLine("Процесс B:          " + startA[0] + " " + startA[1] + " " + startA[2] + " " + startA[3] + "                   " + endB[0] + " " + endB[1] + " " + endB[2] + " " + endB[3]);
      Console.WriteLine("Процесс C:          " + startA[0] + " " + startA[1] + " " + startA[2] + " " + startA[3] + "                   " + endC[0] + " " + endC[1] + " " + endC[2] + " " + endC[3]);
      Console.WriteLine("Процесс D:          " + startA[0] + " " + startA[1] + " " + startA[2] + " " + startA[3] + "                   " + endD[0] + " " + endD[1] + " " + endD[2] + " " + endD[3]);
      //сначала складываем все элементы, после чего 
      for (int i = 0; i < 4; i++)
      {
        used[i] = startA[i] + startB[i] + startC[i] + startD[i];
        needed[i] = endA[i] + endB[i] + endC[i] + endD[i];
        free[i] = free[i] - used[i];
        checkedR[i] = false;
      }
      int f = 0;
      for (int j = 0; j < 4; j++)
      { 
        bool which;
        if ((j == 0) && (checkedR[j] == false))
        {
          which = WhichOne(startA, endA, free);
          if (which == true)
          {
            checkedR[j] = true;
            res[f] = "A";
            f = f + 1;
            j = -1;
            for (int i = 0; i < 4; i++)
            {
              free[i] = free[i] + startA[i];
            }
            Console.WriteLine("A; Свободных ресурсов: " + free[0] + " " + free[1] + " " + free[2] + " " + free[3]);
          }
          else
            continue;
        }
        else if ((j == 1) && (checkedR[j] == false))
        {
          which = WhichOne(startB, endB, free);
          if (which == true)
          {
            checkedR[j] = true;
            res[f] = "B";
            f = f + 1;
            j = -1;
            for (int i = 0; i < 4; i++)
            {
              free[i] = free[i] + startB[i];
            }
            Console.WriteLine("B; Свободных ресурсов: " + free[0] + " " + free[1] + " " + free[2] + " " + free[3]);
          }
          else
            continue;
        }
        else if ((j == 2) && (checkedR[j] == false))
        {
          which = WhichOne(startC, endC, free);
          if (which == true)
          {
            checkedR[j] = true;
            res[f] = "C";
            f = f + 1;
            j = -1;
            for (int i = 0; i < 4; i++)
            {
              free[i] = free[i] + startC[i];
            }
            Console.WriteLine("C; Свободных ресурсов: " + free[0] + " " + free[1] + " " + free[2] + " " + free[3]);
          }
          else
            continue;
        }
        else if ((j == 3) && (checkedR[j] == false))
        {
          which = WhichOne(startD, endD, free);
          if (which == true)
          {
            checkedR[j] = true;
            res[f] = "D";
            f = f + 1;
            j = -1;
            for (int i = 0; i < 4; i++)
            {
              free[i] = free[i] + startD[i];
            }
            Console.WriteLine("D; Свободных ресурсов: " + free[0] + " " + free[1] + " " + free[2] + " " + free[3]);
          }
          else
            continue;
        }
      }
      for (int i = 0; i < 4; i++)
      {
        if (checkedR[i] == true)
        {
          continue;
        }
        else
        {
          Console.WriteLine("Состояние системы является НЕ безопасным!");
          return;
        } 
      }
      Console.WriteLine("Состояние системы является безопасным!");
    }

    public static bool WhichOne(int[] start, int[] end, int[] free)
    {
      int[] temp = new int[4];
      for (int i = 0; i < 4; i++)
      {
        temp[i] = free[i] + start[i];
        if (temp[i] < end[i])
        {
          //break;
          return false;
        }
      }
      return true;
    }
  }
}
/* for (int j = 0; j < 4; j++)
        {
          if (i == 0)
          {
            temp[j] = free[j] + startA[j];
            if (temp[j] < endA[j])
              break;
          }
          else if (i == 1)
          {
            temp[j] = free[j] + startB[j];
            if (temp[j] < endB[j])
              break;
          }
          else if (i == 2)
          {
            temp[j] = free[j] + startC[j];
            if (temp[j] < endC[j])
              break;
          }
          else if (i == 3)
          {
            temp[j] = free[j] + startD[j];
            if (temp[j] < endD[j])
              break;
          }
        }
*/