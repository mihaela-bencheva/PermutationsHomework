using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PermutationsHomework
{
    class Program
    {
        const int N = 4;
        public static int[] permutationArray = new int[N];

        static void Main()
        {
            GetPermutationArray();
            Console.WriteLine("Recursion: ");
            RecursionPermutation(0);
            Console.WriteLine();
            Console.WriteLine("Non Recursive Method: ");
            NonRecursionPermutations();
        }

        // Adds elements from 1 to N into the array
        public static void GetPermutationArray()
        {
            for (int i = 0; i < N; i++)
            {
                permutationArray[i] = i + 1;
            }
        }

        public static void RecursionPermutation(int currentIndex)
        {
            // When it reaches the bottom of the recursion (N),
            // the permutations are written on the console
            if (currentIndex == N)
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write(permutationArray[i]);
                }
                Console.WriteLine();
            }
            else
            {
                // Loop through the elements of the array
                for (int i = currentIndex; i < N; i++)
                {
                    // Creates new permutation
                    Swap(ref permutationArray[currentIndex], ref permutationArray[i]);

                    RecursionPermutation(currentIndex + 1);

                    // Returns the permutation to its original state
                    Swap(ref permutationArray[currentIndex], ref permutationArray[i]);
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static void NonRecursionPermutations()
        {
            // Creates a list from type int that will store all permutations
            List<int[]> permutations = new List<int[]>();

            // Adds the first element of the array to the list
            permutations.Add(new int[] { permutationArray[0] });

            for (int i = 0; i < N; i++)
            {
                // Gets the current element of the array with index i
                int currentElement = permutationArray[i];

                // Gets the current number of permutation
                int currentIndex = permutations.Count;

                for (int j = currentIndex - 1; j >= 0; j--)
                {
                    // Gets the current permutation
                    int[] currentPermutation = permutations[j];

                    // Removes the current permutation from the list
                    permutations.Remove(currentPermutation);

                    // Creates new permutations from the current permutation
                    for (int k = 0; k < currentPermutation.Length; k++)
                    {
                        // Adds new permutation to the list
                        permutations.Add(Insert(currentPermutation, k, currentElement));
                    }
                }
            }

            // Removes the last element of the array 
            for (int i = 0; i < permutations.Count; i++)
            {
                int[] tmpArr = permutations[i];

                if (tmpArr.Length > N)
                {
                    tmpArr = tmpArr.Reverse().Skip(1).Reverse().ToArray();
                }

                permutations[i] = tmpArr;
            }

            // All permutations are written on the console
            foreach (var item in permutations)
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write(item[i]);
                }
                Console.WriteLine();
            }
        }

        // Inserts currentElement in currentPermutation on position "position"
        // All elements right from index "position" are moved 1 position to the right
        private static int[] Insert(int[] currentPermutation, int position, int currentElement)
        {
            int[] array = new int[currentPermutation.Length + 1];

            for (int i = 0; i < position; i++)
            {
                array[i] = currentPermutation[i];
            }
            array[position] = currentElement;

            for (int i = position + 1; i < array.Length; i++)
            {
                array[i] = currentPermutation[i - 1];
            }

            return array;
        }
    }
}
