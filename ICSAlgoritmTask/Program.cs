using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSAlgoritmTask
{
    public class Program
    {
        public void Main(string[] args)
        {
            int[] A = { -1, -2, -7, 3, -5 };
            int[] B = { -1, -2, -3, -4, -5 };

            WriteArr(A);
            WriteArr(B);

            int[] segments = GetArrOfSegments(A, B);

            Console.WriteLine("Искомый массив: ");
            WriteArr(segments);
        }

        private void WriteArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                    Console.Write(arr[i] + ", ");
                else
                    Console.WriteLine(arr[i]);
            }
        }

        private int[] GetArrOfSegments(int[] arrA, int[] arrB)
        {
            int[] segmentsResult = new int[arrB.Length];

            for (int i = 0; i < arrB.Length; i++)
            {
                var listSegments = new List<int>();
                for (int j = 0; j < arrA.Length; j++)
                {
                    if (arrB[i] <= arrA[j])
                    {
                        int segmentsSum = arrA[j];

                        if (j != arrA.Length - 1)
                            while ((arrB[i] <= arrA[++j]))
                            {
                                segmentsSum += arrA[j];
                                if (j == arrA.Length - 1)
                                    break;
                            }
                        listSegments.Add(segmentsSum);
                    }
                }
                if (listSegments.Count < 1)
                    segmentsResult[i] = 0;
                else
                    segmentsResult[i] = listSegments.Max();
            }
            return segmentsResult;
        }
    }
}
