using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralArrayFillTest
{
    class Program
    {
        static void FillDownLeft(int[,] arr, int n, int positionX, int positionY, int stepCount, int currentElement)
        {
            int lastFilledElement;

            //fill to down
            for (int i = 0; i < stepCount; i++)
            {

                if (n % 2 != 0) lastFilledElement = arr[n - 1, n - 1];
                else lastFilledElement = arr[0, 0];
                if (lastFilledElement != 0) break;
                arr[positionX++, positionY] = currentElement;
                currentElement++;
            }

            //fill to left
            for (int j = 0; j < stepCount; j++)
            {

                if (n % 2 != 0) lastFilledElement = arr[n - 1, n - 1];
                else lastFilledElement = arr[0, 0];
                if (lastFilledElement != 0) break;
                arr[positionX, positionY--] = currentElement;
                currentElement++;
            }

            stepCount++;
            if (stepCount < n + 1)
            {
                FillUpRight(arr, n, positionX, positionY, stepCount, currentElement);
            }
        }
        static void FillUpRight(int[,] arr, int n, int positionX, int positionY, int stepCount, int currentElement)
        {
            int lastFilledElement;

            //fill to up
            for (int i = 0; i < stepCount; i++)
            {
                if (n % 2 != 0) lastFilledElement = arr[n - 1, n - 1];
                else lastFilledElement = arr[0, 0];
                if (lastFilledElement != 0) break;
                arr[positionX--, positionY] = currentElement;
                currentElement++;
            }

            //fill to right
            for (int j = 0; j < stepCount; j++)
            {

                if (n % 2 != 0) lastFilledElement = arr[n - 1, n - 1];
                else lastFilledElement = arr[0, 0];
                if (lastFilledElement != 0) break;
                arr[positionX, positionY++] = currentElement;
                currentElement++;
            }

            stepCount++;
            if (stepCount < n + 1)
            {
                FillDownLeft(arr, n, positionX, positionY, stepCount, currentElement);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter n (for nxn matrix): ");
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            int positionX;
            if (n % 2 == 0) positionX = n / 2 - 1;
            else positionX = n / 2;
            int positionY = n / 2;
            int stepCount = 1;
            arr[positionX, positionY] = 0;

            FillDownLeft(arr, n, positionX, positionY, stepCount, 0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
