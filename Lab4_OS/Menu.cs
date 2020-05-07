using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_OS
{
  enum Operation { No = 0, Yes, Close }
  enum Menus { Start = 0, About = 1, Work, Exit, End }

  class Menu
  {
    public static void MenuUI()
    {
      Console.WriteLine("___________________________________________");
      Console.WriteLine("********|-----------МЕНЮ----------|********");
      Console.WriteLine("*******************************************");
      Console.WriteLine("*******|         Ваш выбор         |*******");
      Console.WriteLine("*******************************************");
      Console.WriteLine("* 1. О программе                          *");
      Console.WriteLine("* 2. Старт                                *");
      Console.WriteLine("* 3. Выход                                *");
      Console.WriteLine("*******************************************");
    }
    public static int About()
    {
      Console.WriteLine("Задание: В контексте «алгоритма банкира» определите и обоснуйте, \nявляется ли приведенное состояние опасным или безопасным с точки зрения возникновения тупиков. \nВыполнил студент группы 484, Левинский Илья");
      return (0);
    }

    public static int WorkWithMenu()
    {
      for (int userChoice = (int)Menus.Start; userChoice < (int)Menus.End; userChoice++)
      {
        MenuUI();
        userChoice = Check.GetInt();
        if (userChoice == (int)Menus.About)
        {
          About();
          if (WhatsNext() == (int)Operation.No)
          {
            break;
          }
          else
          {
            MenuUI();
            WorkWithMenu();
          }
        }
        else if (userChoice == (int)Menus.Work)
        {
          Work.Find();
          if (WhatsNext() == (int)Operation.No)
          {
            break;
          }
          else
          {
            MenuUI();
            WorkWithMenu();
          }
        }
        else if (userChoice == (int)Menus.Exit)
        {
          break;
        }
        else
        {
          Console.WriteLine("Ошибка. Такого пункта в меню нет. Попробуйте еще раз");
          WorkWithMenu();
        }
      }
      return (0);
    }

    static int WhatsNext()
    {
      Console.WriteLine("1. Меню");
      Console.WriteLine("2. Выход");
      int userCh = 0;
      userCh = Check.GetInt();
      if (userCh == (int)Operation.Yes)
      {
        WorkWithMenu();
      }
      else if (userCh == (int)Operation.Close)
      {
        return (0);
      }
      else
      {
        Console.WriteLine("Ошибка. Такого пункта нет. Попробуйте еще раз");
        WhatsNext();
      }
      return (0);
    }
  }
}

