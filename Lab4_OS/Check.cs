using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_OS
{
  enum Checking { Empty = 0, Yes, Create }
  enum FileCheck { Start = 0, Read = 1, Write, Exit, End }

  class Check
  {
    public static int GetInt()
    {
      int resulted;
      bool check;
      string userInput = Console.ReadLine();
      do
      {
        check = Int32.TryParse(userInput, out resulted);
        if (!check)
        {
          Console.WriteLine("Введенные данные не верны, попробуйте еще раз!");
          userInput = Console.ReadLine();
        }
      } while (!check);
      return resulted;
    }
  }
}
