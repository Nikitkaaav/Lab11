using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class TestCollections
    {
        private LinkedList<DebitCard> collection1;
        private LinkedList<string> collection2;
        private SortedDictionary<BankCard, DebitCard> collection3;
        private SortedDictionary<string, DebitCard> collection4;

        public TestCollections()
        {
            collection1 = new LinkedList<DebitCard>();
            collection2 = new LinkedList<string>();
            collection3 = new SortedDictionary<BankCard, DebitCard>();
            collection4 = new SortedDictionary<string, DebitCard>();

            for (int i = 0; i < 1000; i++)
            {
                DebitCard newDebitCard = new DebitCard("3456345667894561", "DENIS IVANOV", new DateTime(2024, 01, 01), 2442);
                collection1.AddLast(newDebitCard);

                string debitCardString = newDebitCard.ToString();
                collection2.AddLast(debitCardString);

                BankCard newBankCard = new BankCard("3456345667894561", "DENIS IVANOV", new DateTime(2024, 01, 01));
                collection3.Add(newBankCard, newDebitCard);

                string bankCardString = newBankCard.ToString();
                collection4.Add(bankCardString, newDebitCard);
            }
        }

        public void MeasureSearchTime()
        {

            Stopwatch stopwatch = new Stopwatch();

            // Измерение времени поиска для первого элемента
            stopwatch.Start();
            bool result1 = collection1.Contains(collection1.First.Value);
            stopwatch.Stop();
            Console.WriteLine("Время на поиск первого элемента в коллекции 1: " + stopwatch.Elapsed);

            stopwatch.Restart();
            bool result2 = collection2.Contains(collection2.First.Value);
            stopwatch.Stop();
            Console.WriteLine("Время на поиск первого элемента в коллекции 2: " + stopwatch.Elapsed);

            stopwatch.Restart();
            bool result3 = collection3.ContainsValue(collection1.First.Value);
            stopwatch.Stop();
            Console.WriteLine("Время на поиск первого элемента в коллекции 3: " + stopwatch.Elapsed);

            stopwatch.Restart();
            bool result4 = collection4.ContainsValue(collection1.First.Value);
            stopwatch.Stop();
            Console.WriteLine("Время на поиск первого элемента в коллекции 4: " + stopwatch.Elapsed);

        }
    }
}
