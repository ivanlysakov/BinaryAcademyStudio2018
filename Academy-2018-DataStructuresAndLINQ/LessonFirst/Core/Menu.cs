using System;
using System.Collections.Generic;
using System.Text;

namespace LessonFirst.Core
{
    class Menu
    {
        public void mainMenu()
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorSize = 10;
            Console.WriteLine("Зачекайте, будь ласка...я думаю");
            Service service = new Service();
            var users = service.Source.GetData();
            


            bool repeat = false;
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Вітаємо вас!");
                Console.WriteLine("Чого бажаєте? Натисніть, будь ласка, відповідну клавішу");
                Console.WriteLine("========================================================");
                Console.WriteLine("1.   Кількість комментів под постами конкретного юзера (id)");
                Console.WriteLine("2.   Список комментів под постами конкретного юзера (id), де body коммента < 50 символів");
                Console.WriteLine("3.   Список (id, name) зі списка todos котрі виконані для конкретного юзера (id)");
                Console.WriteLine("4.   Список юзерів по алфавіту з відсортованими todo по довжині name (за зменшенням)");
                Console.WriteLine("5.   Нова структура Users (id юзера)");
                Console.WriteLine("6.   Нова структура Posts (id поста)");
                Console.WriteLine("========================================================");
                Console.WriteLine("Esc  Вихід");
                ConsoleKeyInfo keyPressed;
                keyPressed = Console.ReadKey();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:

                        do
                        {
                                                        
                                Console.WriteLine("Введіть ID: ");
                                int userid;
                                try
                                {
                                userid = Int32.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Помилка");
                                    return;
                                }


                                    Console.Clear();
                                    service.GetCommentsForPost(users, userid);


                                    Console.WriteLine("==============================================================");
                                    Console.WriteLine("Бажаєте спробувати ще раз?     ---   Натисніть Enter.");
                                    Console.WriteLine("Повернутися в головне меню?    ---   Натисніть будь-яку клавішу");
                                    Console.WriteLine("==============================================================");

                                    keyPressed = Console.ReadKey();
                                    if (keyPressed.Key == ConsoleKey.Enter)
                                    {
                                        repeat = true;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                      repeat = false;
                                        
                                    }
                               
                            

                            
                        }
                        while (repeat == true);
                        Console.Clear();

                        break;
                    case ConsoleKey.D2:

                        do
                        {

                            Console.WriteLine("Ввведіть ID: ");
                            int a;
                            try
                            {
                                a = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Помилка");
                                return;
                            }
                            Console.Clear();
                            service.GetSmallComments(users, a);

                            Console.WriteLine("==============================================================");
                            Console.WriteLine("Бажаєте спробувати ще раз?     ---   Натисніть Enter.");
                            Console.WriteLine("Повернутися в головне меню?    ---   Натисніть будь-яку клавішу");
                            Console.WriteLine("==============================================================");

                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.Enter)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();

                        break;

                    case ConsoleKey.D3:

                        do
                        {
                            Console.WriteLine("Введіть ID: ");
                            int userid;
                            try
                            {
                                userid = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Помилка");
                                return;
                            }
                            Console.Clear();
                            service.GetTodosCompleted(users, userid);

                            Console.WriteLine("==============================================================");
                            Console.WriteLine("Бажаєте спробувати ще раз?     ---   Натисніть Enter.");
                            Console.WriteLine("Повернутися в головне меню?    ---   Натисніть будь-яку клавішу");
                            Console.WriteLine("==============================================================");

                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.Enter)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();

                        break;

                    case ConsoleKey.D4:

                        do
                        {

                            Console.Clear();
                            service.GetSortedUsers(users);

                            Console.WriteLine("==============================================================");
                            Console.WriteLine("Бажаєте спробувати ще раз?     ---   Натисніть Enter.");
                            Console.WriteLine("Повернутися в головне меню?    ---   Натисніть будь-яку клавішу");
                            Console.WriteLine("==============================================================");

                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.Enter)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();

                        break;

                    case ConsoleKey.D5:

                        do
                        {
                            Console.WriteLine("Введіть ID: ");
                            int userid;
                            try
                            {
                                userid = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Помилка");
                                return;
                            }
                            Console.Clear();
                            service.GetUserNewStruct(users, userid);

                            Console.WriteLine("==============================================================");
                            Console.WriteLine("Бажаєте спробувати ще раз?     ---   Натисніть Enter.");
                            Console.WriteLine("Повернутися в головне меню?    ---   Натисніть будь-яку клавішу");
                            Console.WriteLine("==============================================================");

                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.Enter)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();

                        break;
                    case ConsoleKey.D6:

                        do
                        {
                            Console.WriteLine("Ввведіть ID: ");
                            int userid;
                            try
                            {
                                userid = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Помилка");
                                return;
                            }
                            Console.Clear();
                            service.GetPostNewStruct(users, userid);

                            Console.WriteLine("==============================================================");
                            Console.WriteLine("Бажаєте спробувати ще раз?     ---   Натисніть Enter.");
                            Console.WriteLine("Повернутися в головне меню?    ---   Натисніть будь-яку клавішу");
                            Console.WriteLine("==============================================================");

                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.Enter)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();

                        break;


                    case ConsoleKey.Escape:
                        Console.WriteLine("Have a nice day)");
                        exit = true;
                        return;

                    default:
                        Console.WriteLine("Oooops!! Зробіть Ваш вибір");
                        continue;
                }
            }

            while (!exit);
        }
    }
}
