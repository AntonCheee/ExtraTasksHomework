using System;

namespace ExtraTasksHomework
{
    class Program
    {
        static void Main()
        {
            //string[] result = ExtraTask("You are my dear friend", "EA");

            //(int x, int y)[] array = new (int x, int y)[5] {(0,0), (1, 1), (5, 5), (4, 4), (3, 3) };

            //(int, int)[] result = FindLongestLineBetweenTwoPoints(array);

            int[,] result = MakeSpiralMatrix(7);

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static string[] FindExpressionIntoText(string text, string expression)
        {
            string element = string.Empty;
            int countWords = 0;

            foreach (char item in text)
            {
                if (char.IsWhiteSpace(item))
                {
                    ++countWords;
                }
            }

            string[] listOfWords = new string[countWords];

            foreach (char item in text)
            {
                if (!char.IsWhiteSpace(item))
                {
                    element += item;
                }
                else
                {
                    listOfWords[--countWords] = element;
                    element = string.Empty;
                }
            }

            var countWordsContainsExpression = 0;

            foreach (var item in listOfWords)
            {
                if (item.ToLower().Contains(expression.ToLower()))
                {
                    ++countWordsContainsExpression;
                }
            }

            string[] resultList = new string[countWordsContainsExpression];
            int position = 0;

            foreach (var item in listOfWords)
            {
                if (item.ToLower().Contains(expression.ToLower()))
                {
                    resultList[position++] = item;
                }
            }

            return resultList;
        }

        private static (double, double) FindLongestAndShortestDistanceBetweenTwoPoints((int x, int y)[] array)
        {
            double minLength = double.MaxValue;
            double maxLength = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    double length = Math.Sqrt((array[i].x - array[j].x) * (array[i].x - array[j].x) + (array[i].y - array[j].y) * (array[i].y - array[j].y));

                    if (length > maxLength)
                    {
                        maxLength = length;
                    };

                    if (length < minLength)
                    {
                        minLength = length;
                    };
                }
            }

            return (minLength, maxLength);
        }
        

        public static int[,] MakeSpiralMatrix(int size)
        {
            int iMin = 0;
            int jMin = 0;
            int iMax = size;
            int jMax = size;

            int number = 1;
            int count = 0;

            int[,] array = new int[size, size];

            while (count < size * size)
            {
                for (int j = jMin; j < jMax; j++)
                {
                    array[iMin, j] = number++;
                    count++;
                }

                ++iMin;

                for (int i = iMin; i < iMax; i++)
                {
                    array[i, jMax - 1] = number++;
                    count++;
                }

                --jMax;

                for (int j = jMax - 1; j >= jMin; j--)
                {
                    array[iMax - 1, j] = number++;
                    count++;
                }

                --iMax;

                for (int i = iMax - 1; i >= iMin; i--)
                {
                    array[i, jMin] = number++;
                    count++;
                }

                ++jMin;
            }

            return array;
        }
    }
}
