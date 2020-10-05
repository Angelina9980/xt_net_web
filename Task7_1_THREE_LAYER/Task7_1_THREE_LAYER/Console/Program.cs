using Controllers;
using Models;
using System;
using System.Collections.Generic;
using Epam.Common;
using System.Globalization;

namespace Epam.Nodes
{
    class Program
    {
        static void Main(string[] args)
        {

            bool IsWorking = true;
            var userLogic = UserResolver.UserLogic;
            var awardLogic = AwardResolver.AwardLogic;
            UserController userController = new UserController(userLogic);
            AwardController awardController = new AwardController(awardLogic);

            while (IsWorking)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - добавить пользователя");
                Console.WriteLine("2 - добавить награду");
                Console.WriteLine("3 - посмотреть список пользователей");
                Console.WriteLine("4 - посмотреть список наград");
                Console.WriteLine("5 - удалить пользователя");
                Console.WriteLine("6 - Выход");
                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Введите имя пользователя");
                        string userName = Console.ReadLine();
                        while(userName == null)
                        {
                            Console.WriteLine("Введите корректное имя");
                            userName = Console.ReadLine();
                        }

                        Console.WriteLine("Введите дату рождения пользователя в формате dd.MM.yyyy");
                        string dateInput = Console.ReadLine();
                        DateTime dateTime;
                        while (!DateTime.TryParseExact(dateInput, "dd.MM.yyyy", null, DateTimeStyles.None, out dateTime)) {
                            Console.WriteLine("Введите дату формата dd.MM.yyyy");
                            dateInput = Console.ReadLine();
                        }
                        List<int> awardList = new List<int>();
                        Console.WriteLine("Добавить пользователю наград? ");
                        Console.Write("1 - да, 2 - нет : ");
                        int awardChoice = int.Parse(Console.ReadLine());
                        switch(awardChoice)
                        {
                            case 1:
                                Console.Write("Введите количество наград пользователя: ");
                                int awardCount = int.Parse(Console.ReadLine());
                                if (awardCount <= 0 || awardCount.ToString() == null)
                                {
                                    Console.WriteLine("Выбрано действие по умолчанию - без добавления наград");
                                }
                                else
                                {
                                    for (int i = 0; i < awardCount; i++)
                                    {
                                        Console.Write("Номер награды {0} : ", i+1);
                                        int number;
                                        while ((!int.TryParse(Console.ReadLine(), out number)) || number < 1)
                                        {
                                            Console.WriteLine("Введите корректный номер награды, начиная с 1");
                                        }
                                        awardList.Add(number);
                                    }
                                }
                                break;
                            case 2:
                                Console.WriteLine("Награды не добавлены!");
                                break;
                            default:
                                Console.WriteLine("Выбрано действие по умолчанию - без добавления наград");
                                break;
                        }
                        userController.AddUser(new UserModel {Name = userName, DateOfBirth = dateTime, ListOfAwards =  awardList});
                        break;
                    case 2:
                        Console.Write("Введите название награды: ");
                        string awardTitle = Console.ReadLine();
                        while (awardTitle == null)
                        {
                            Console.WriteLine("Введите корректное название");
                            awardTitle = Console.ReadLine();
                        }
                        awardController.AddAward(new AwardModel { Title = awardTitle});
                        break;
                    case 3:
                        if (userLogic.GetAllUsers().Count == 0)
                        {
                            Console.WriteLine("Список пользователей пуст!");
                        }
                        else
                        {
                            foreach (var user in userLogic.GetAllUsers())
                            {
                                Console.WriteLine($"Пользователь: {user.Name}, Дата рождения {user.DateOfBirth}, возраст {user.Age}");
                                if (user.ListOfAwards != null)
                                {
                                    Console.WriteLine("Список наград пользователя:");
                                    foreach (var award in user.ListOfAwards)
                                    {
                                        Console.WriteLine(award);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Список наград пользователя пуст.");
                                }
                            }
                        }
                        break;
                    case 4:
                        if (awardLogic.GetAllAwards() == null)
                        {
                            Console.WriteLine("Список наград пуст!");
                        }
                        else
                        {
                            foreach (var award in awardLogic.GetAllAwards())
                            {
                                Console.WriteLine($"Награда : {award.Title} id: {award.Id}");
                            }
                        }
                        break;
                    case 5:
                        Console.Write("Введите номер пользователя, которого следует удалить : ");
                        int userId = int.Parse(Console.ReadLine());
                        while (userId < 1)
                        {
                            Console.WriteLine("Введите корректный номер пользователя");
                            userId = int.Parse(Console.ReadLine());
                        }
                        if (userController.GetAllUsers().Count != 0)
                        {
                            userController.DeleteUserById(userId);
                            Console.WriteLine("Пользователь удален");
                        }
                        else
                        {
                            Console.WriteLine("Не найден пользователь по заданному номеру!");
                        }
                        break;
                    case 6:
                        IsWorking = false;
                        Console.WriteLine("Нажмите любую клавишу для выхода");
                        break;
                    default:
                        Console.WriteLine("Извините, но такой команды нет");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
