using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Heap
    {
        int[] HeapSort;
        int Count;
        private bool sort = false;

        public Heap(int[] array)
        {
            Count = array.Length;
            HeapSort = new int[Count];
            HeapSort = array;
            SortHeap();
        }
        public void SortHeap()
        {
            for (int j = Count / 2 - 1; j >= 0; j--)
            {
                SortHeap(j, Count);
            }
        }
        void SortHeap(int indexfrom, int count)
        {
            int left = indexfrom * 2 + 1;
            int right = indexfrom * 2 + 2;

            int max = indexfrom;

            if (left < count && HeapSort[max] < HeapSort[left])
                max = left;
            if (right < count && HeapSort[max] < HeapSort[right])
                max = right;

            if (max == indexfrom)
                return;

            Swap(max, indexfrom);
            SortHeap(max, count);
        }
        void Swap(int max, int from)
        {
            int temp = HeapSort[max];
            HeapSort[max] = HeapSort[from];
            HeapSort[from] = temp;
        }
        public void SortArray()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                Swap(0, i);
                SortHeap(0, i);
            }
            sort =true;
        }
        public void ArrayWrite()
        {
            if (sort)
            {
                for (int i = 0; i < Count - 1; i++)
                {
                    Console.Write(HeapSort[i]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("<");
                    Console.ResetColor();
                }
                Console.Write(HeapSort[Count - 1]);
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Write(HeapSort[i]+ " ");
                }
            }
            Console.WriteLine();
        }
        public void Add(int value)
        {
            Count++;
            int[] tempHeap = new int[Count];
            for (int i = 0; i < HeapSort.Length; i++)
            {
                tempHeap[i] = HeapSort[i];
            }
            tempHeap[Count - 1] = value;
            HeapSort = new int[Count];
            HeapSort = tempHeap;
            SortHeap();
            sort = false;
        }
        public bool Search(ref int value)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                if (HeapSort[i] == value)
                {
                    value = i;
                    return true;
                }
            }
            return false;
        }
        public bool Delete(int value)
        {
            if (Search(ref value))
            {
                Count--;
                int[] tempHeap = new int[Count];
                int step = 0;
                for (; step < value; step++)
                {
                    tempHeap[step] = HeapSort[step];
                }
                for (; step < Count; step++)
                {
                    tempHeap[step] = HeapSort[step + 1];
                }
                HeapSort = new int[Count];
                HeapSort = tempHeap;
                SortHeap();
                sort = false;
                return true;
            }
            else
                return false;
        }
        public void HeapWrite()
        {
            TreeOne(0, 0, true);
            Console.WriteLine();
        }
        private void TreeOne(int index, int lvl, bool thisstring)
        {
            if (index >= Count) // end of the branch 
                return;
            if (index != 0)
            {
                if (!thisstring) // move to the next string 
                {
                    int tempcount = lvl;
                    while (tempcount > 0)
                    {
                        Console.Write("\t");
                        tempcount--;
                    }

                }
                else // keep writing in this string 
                    Console.Write("\t");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("->");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(HeapSort[index]);
            int left = index * 2 + 1;
            if (index == 0) // with left branch always keep in this string 
            {
                TreeOne(left, lvl + 1, true); 
            }
            else
                TreeOne(left, lvl + 1, true);
            int right = index * 2 + 2;
            if (right<= Count)
            {
                Console.WriteLine();
                TreeOne(right, lvl + 1, false); //with right branch always move to the next string
            }
        }
    }
}



