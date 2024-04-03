using ClassLibraryLab10;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;

            while (menu != 4)
            {
                Console.WriteLine("1) Задание 1");
                Console.WriteLine("2) Задание 2");
                Console.WriteLine("3) Задание 3");
                Console.WriteLine("4) Выход");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        int menu1 = 0;
                        ArrayList al = new ArrayList();
                        for (int i = 0; i < 5; i++)
                        {
                            BankCard c = new BankCard();
                            al.Add(c);
                            c.RandomInit();
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            DebitCard c = new DebitCard();
                            al.Add(c);
                            c.RandomInit();
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            YouthCard c = new YouthCard();
                            al.Add(c);
                            c.RandomInit();
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            CreditCard c = new CreditCard();
                            al.Add(c);
                            c.RandomInit();
                        }

                        while (menu1 != 10)
                        {
                            Console.WriteLine("1) Добавление объектов в коллекцию");
                            Console.WriteLine("2) Удаление объектов из коллекции");
                            Console.WriteLine("3) Нахождение общего баланса всех дебетовых карт");
                            Console.WriteLine("4) Нахождения среднего процента кэшбэка молодежных карт");
                            Console.WriteLine("5) Нахождение самого большого лимита из всех кредитных карт");
                            Console.WriteLine("6) Перебор элементов коллекции");
                            Console.WriteLine("7) Клонирование коллекции");
                            Console.WriteLine("8) Сортировка коллекции");
                            Console.WriteLine("9) Поиск заданного элемента в коллекции");
                            Console.WriteLine("10) Назад");
                            menu1 = int.Parse(Console.ReadLine());
                            switch (menu1)
                            {
                                case 1:
                                    BankCard cardToAdd = new BankCard();
                                    cardToAdd.Init();
                                    al.Add(cardToAdd);
                                    break;
                                case 2:
                                    Console.WriteLine("Введите номер элемента, который хотите удалить:");
                                    int pos = int.Parse(Console.ReadLine());
                                    if (pos >= 0)
                                    {
                                        Console.WriteLine($"Удаление {al[pos]}");
                                        al.RemoveAt(pos);
                                    }
                                    break;
                                case 3:
                                    double sum = 0;
                                    foreach (BankCard item in al)
                                    {
                                        if (item is DebitCard dc)
                                        {
                                            sum += dc.Balance;
                                        }
                                    }
                                    Console.WriteLine($"Общий баланс всех дебетовых карт: {sum} руб.");
                                    break;
                                case 4:
                                    int countYouthCardNumber = 0;
                                    int sumCashback = 0;
                                    foreach (BankCard item in al)
                                    {
                                        YouthCard crd = item as YouthCard;
                                        if (crd != null)
                                        {
                                            sumCashback += crd.Cashback;
                                            countYouthCardNumber++;
                                        }
                                    }
                                    double averageCashbackPercent = (double)sumCashback / countYouthCardNumber;
                                    Console.WriteLine($"Средний процент кэшбека молодежных карт: {averageCashbackPercent}%");
                                    break;
                                case 5:
                                    int maxLimit = 0;
                                    foreach (BankCard item in al)
                                    {
                                        if (item is CreditCard cd)
                                        {
                                            if (cd.Limit > maxLimit)
                                            {
                                                maxLimit = cd.Limit;
                                            }
                                        }
                                    }
                                    Console.WriteLine($"Самый большой лимит из всех кредитных карт: {maxLimit}\n");
                                    break;
                                case 6:
                                    foreach (object c in al)
                                    {
                                        Console.WriteLine(c.ToString());
                                    }
                                    Console.WriteLine($"Count = {al.Count}");
                                    Console.WriteLine($"Capacity = {al.Capacity}");
                                    break;
                                case 7:
                                    ArrayList clonedList = (ArrayList)al.Clone();

                                    Console.WriteLine("Клонированная коллекция:");
                                    foreach (object item in clonedList)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    break;
                                case 8:
                                    al.Sort();
                                    break;
                                case 9:
                                    Console.WriteLine("Введите элемент для поиска");
                                    BankCard card = new BankCard();
                                    card.Init();
                                    if (al.Contains(card))
                                    {
                                        Console.WriteLine("Найден");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Не найден");
                                    }
                                    break;
                                case 10:
                                    break;

                            }
                        }
                        break;

                    case 2:
                        int menu2 = 0;

                        Dictionary<BankCard, CreditCard> dict = new Dictionary<BankCard, CreditCard>();

                        for (int i = 0; i < 12; i++)
                        {
                            try
                            {
                                CreditCard cc = new CreditCard();
                                cc.RandomInit();
                                BankCard bc = new BankCard(cc.Number, cc.Owner, cc.Duration);
                                dict.Add(bc, cc);
                            }
                            catch (Exception e)
                            {
                                i--;
                            }
                        }

                        while (menu2 != 10)
                        {
                            Console.WriteLine("1) Добавление объектов в коллекцию");
                            Console.WriteLine("2) Удаление объектов из коллекции");
                            Console.WriteLine("3) Нахождение количества дебетовых карт в коллекции");
                            Console.WriteLine("4) Нахождение количества молодежных карт в коллекции");
                            Console.WriteLine("5) Нахождение количества кредитных карт в коллекции");
                            Console.WriteLine("6) Перебор элементов коллекции");
                            Console.WriteLine("7) Клонирование коллекции");
                            Console.WriteLine("8) Сортировка коллекции");
                            Console.WriteLine("9) Поиск заданного элемента в коллекции");
                            Console.WriteLine("10) Назад");

                            menu1 = int.Parse(Console.ReadLine());

                            switch (menu1)
                            {
                                case 1:
                                    CreditCard cc = new CreditCard();
                                    cc.Init();
                                    BankCard bc = new BankCard(cc.Number, cc.Owner, cc.Duration);
                                    dict.Add(bc, cc);
                                    break;
                                case 2:
                                    dict.Clear();
                                    foreach (var item in dict.Keys)
                                    {
                                        Console.WriteLine($"Ключ:\n{item}Значение:\n{dict[item]}");
                                    }
                                    Console.WriteLine($"В словаре {dict.Count} элементов");
                                    break;
                                case 3:
                                    int countdc = 0;
                                    foreach (var item in dict)
                                    {
                                        if (item is DebitCard)
                                            countdc++;
                                    }
                                    Console.WriteLine($"Количество дебетовых карт = {countdc}");
                                    break;
                                case 4:
                                    int countyc = 0;
                                    foreach (var item in dict)
                                    {
                                        if (item is YouthCard)
                                            countyc++;
                                    }
                                    Console.WriteLine($"Количество молодежных карт = {countyc}");
                                    break;
                                case 5:
                                    int countcc = 0;
                                    foreach (var item in dict)
                                    {
                                        if (item is CreditCard)
                                            countcc++;
                                    }
                                    Console.WriteLine($"Количество кредитных карт = {countcc}");
                                    break;
                                case 6:
                                    foreach (var item in dict.Keys)
                                    {
                                        Console.WriteLine($"Ключ:\n{item}Значение:\n{dict[item]}");
                                    }
                                    Console.WriteLine($"В словаре {dict.Count} элементов");
                                    break;
                                case 7:
                                    Dictionary<BankCard, CreditCard> clonedDict = new Dictionary<BankCard, CreditCard>(dict);
                                    Console.WriteLine("\nКлонированный словарь:");
                                    foreach (var item in clonedDict.Keys)
                                    {
                                        Console.WriteLine($"Ключ:\n{item}Значение:\n{clonedDict[item]}");
                                    }
                                    break;
                                case 8:
                                    var sortedByValue = dict.OrderBy(kvp => kvp.Value);

                                    Console.WriteLine("Сортировка по значению:");
                                    foreach (var item in dict.Keys)
                                    {
                                        Console.WriteLine($"Ключ:\n{item}Значение:\n{dict[item]}");
                                    }
                                    break;
                                case 9:
                                    // Поиск элемента по ключу
                                    BankCard bc1 = new BankCard();
                                    bc1.Init();
                                    bool okKey = dict.ContainsKey(bc1);
                                    if (okKey)
                                    {
                                        Console.WriteLine($"Элемент найден");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Элемент не найден");
                                    }
                                    // Поиск элемента по значению
                                    CreditCard cc1 = new CreditCard();
                                    cc1.Init();
                                    bool okValue = dict.ContainsValue(cc1);
                                    if (okValue)
                                    {
                                        Console.WriteLine($"Элемент найден");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Элемент не найден");
                                    }
                                    break;
                                case 10:
                                    break;


                            }
                        }
                        break;
                }
            }
        }
    }
}
