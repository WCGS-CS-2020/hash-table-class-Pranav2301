using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace Hash_table
{
    public class hashTable
    {
        LinkedList<string>[] Hashtable = new LinkedList<string>[0];
        private int size;
        private int pos;
        public hashTable(int Size)
        {
            size = Size;
            Hashtable = new LinkedList<string>[size];
            for (int i = 0; i < size; i++)
            {
                Hashtable[i] = new LinkedList<string>();
            }
        }
        public int hashFunction(string item)
        {
            int index;
            int totalAsc = 0;
            byte[] asciiSum = Encoding.ASCII.GetBytes(item);
            foreach (var ascVal in asciiSum)
            {
                totalAsc += ascVal;
            }
            index = totalAsc % size;
            return index;
        }
        public void addItem(string item)
        {
            pos = hashFunction(item);
            Hashtable[pos].AddLast(item);
        }
        public bool searchHash(string item)
        {
            bool isExist = false;
            pos = hashFunction(item);
            foreach (string element in Hashtable[pos])
            {
                if (element == item)
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;

        }
        public void printHash()
        {
            foreach (LinkedList<string>val in Hashtable)
            {
                foreach (string item in val)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void deleteHash(string item)
        {
            searchHash(item);
            if (searchHash(item) == false)
            {
                Console.WriteLine("Item is not found");
            }
            else
            {
                pos = hashFunction(item);
                Hashtable[pos].Remove(item);
                Console.WriteLine("Item removed");
            }
        }
        public void getLoadFactor()
        {
            int count = 0;
            double loadFactor = 0;
            foreach (LinkedList<string>val in Hashtable)
            {
                foreach (string item in val)
                {
                    count++;
                }
            }
            loadFactor = (double)count / size * 100;
            Console.WriteLine("The load factor of the hash table is {0}%", loadFactor);
        }
        class Program
        {
            public static void Main()
            {
                bool isExit = false;
                string option;
                int size = 51;
                string userItem;
                hashTable ht = new hashTable(size);
                while (isExit == false)
                {
                    Console.WriteLine(@"1: Add to hash table
2: Search the hash table
3: Delete from hash table
4: Print hash table
5: Output load factor");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Enter the item you want to add to the hash table");
                            userItem = Console.ReadLine();
                            ht.addItem(userItem);
                            break;
                        case "2":
                            Console.WriteLine("Enter the item you want to search from the hash table");
                            userItem = Console.ReadLine();
                            ht.searchHash(userItem);
                            if (ht.searchHash(userItem) == false)
                            {
                                Console.WriteLine("Item not found");
                            }
                            else
                            {
                                Console.WriteLine("Item exists in the index {0}", ht.hashFunction(userItem));
                            }
                            break;
                        case "3":
                            Console.WriteLine("Enter the item you want to delete from the hash table");
                            userItem = Console.ReadLine();
                            ht.deleteHash(userItem);
                            break;
                        case "4":
                            ht.printHash();
                            break;
                        case "5":
                            ht.getLoadFactor();
                            break;
                    }
                }
            }
        }
    }
}

