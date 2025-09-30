using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class HashPhoneBook
    {
        private class Entry
        {
            public string Name;
            public string Number;
            public string Key;

            public Entry(string name, string number)
            {
                Name = name;
                Number = number;
                Key = Normalize(name);
            }
        }

        private List<Entry>[] _buckets;
        private int _count;

        public HashPhoneBook(int capacity = 16)
        {
            _buckets = new List<Entry>[capacity];
        }

        public void AddOrUpdate(string name, string number)
        {
            EnsureCapacity();
            string key = Normalize(name);
            int index = Hash(key);

            if (_buckets[index] == null) _buckets[index] = new List<Entry>();

            foreach (var e in _buckets[index])
            {
                if (e.Key == key)
                {
                    e.Name = name;
                    e.Number = number;
                    return;
                }
            }

            _buckets[index].Add(new Entry(name, number));
            _count++;
        }

        public bool Remove(string name)
        {
            string key = Normalize(name);
            int index = Hash(key);
            var bucket = _buckets[index];
            if (bucket == null) return false;

            for (int i = 0; i < bucket.Count; i++)
            {
                if (bucket[i].Key == key)
                {
                    bucket.RemoveAt(i);
                    _count--;
                    return true;
                }
            }
            return false;
        }

        public bool TryGet(string name, out string number)
        {
            string key = Normalize(name);
            int index = Hash(key);
            var bucket = _buckets[index];
            if (bucket != null)
            {
                foreach (var e in bucket)
                {
                    if (e.Key == key)
                    {
                        number = e.Number;
                        return true;
                    }
                }
            }
            number = null;
            return false;
        }

        public bool Edit(string name, string newNumber)
        {
            string key = Normalize(name);
            int index = Hash(key);
            var bucket = _buckets[index];
            if (bucket != null)
            {
                foreach (var e in bucket)
                {
                    if (e.Key == key)
                    {
                        e.Number = newNumber;
                        return true;
                    }
                }
            }
            return false;
        }

        public void PrintAll()
        {
            Console.WriteLine("Phonebook contents:");
            for (int i = 0; i < _buckets.Length; i++)
            {
                var bucket = _buckets[i];
                if (bucket == null || bucket.Count == 0) continue;

                Console.Write($"Bucket {i}: ");
                for (int j = 0; j < bucket.Count; j++)
                {
                    var e = bucket[j];
                    Console.Write($"[{e.Name} -> {e.Number}]");
                    if (j < bucket.Count - 1) Console.Write(" , ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Total contacts: {_count}");
        }

        private static string Normalize(string s) =>
            (s ?? string.Empty).Trim().ToLowerInvariant();

        private int Hash(string key)
        {
            int sum = 0;
            for (int i = 0; i < key.Length; i++)
                sum += key[i];
            if (sum < 0) sum = -sum;
            return sum % _buckets.Length;
        }

        private void EnsureCapacity()
        {
            if (_count < _buckets.Length * 3 / 4) return;

            var oldBuckets = _buckets;
            _buckets = new List<Entry>[oldBuckets.Length * 2];
            _count = 0;

            foreach (var bucket in oldBuckets)
            {
                if (bucket == null) continue;
                foreach (var e in bucket)
                {
                    AddOrUpdate(e.Name, e.Number);
                }
            }
        }
    }
}
