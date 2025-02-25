namespace ConsoleApp
{
    internal class Program
    {
        public static void Main()
        {
            int[][] matrix =
            {
                new int[] {2, 1, 0, 0, 0, 0},
                new int[] {1, 1, 2, 1, 0, 0},
                new int[] {2, 0, 1, 0, 0, 0},
                new int[] {1, 1, 2, 1, 0, 1},
                new int[] {0, 0, 1, 2, 0, 0},
                new int[] {0, 0, 0, 0, 0, 5},
                new int[] {1, 0, 0, 0, 0, 0},
                new int[] {0, 1, 1, 0, 0, 0},
                new int[] {0, 0, 0, 1, 1, 3},
                new int[] {1, 0, 0, 2, 1, 4},
                new int[] {0, 1, 2, 0, 0, 0}
            };
            Console.WriteLine("\nArray of groups:");
            Console.WriteLine(Print(matrix));

            int[] vector = { 0, 1, 2, 0, 0, 0 };
            Console.WriteLine("\nChecked vector:");
            Console.WriteLine(Print(vector));

            List<double> result = Compare(vector, matrix, 3);
            Console.WriteLine("\nResult:");
            Console.WriteLine(Print(result));

            double bestSimLevel = result.Min();
            int bestIndex = result.IndexOf(bestSimLevel);
            Console.WriteLine("\nBest similarity value = " + bestSimLevel + " / matrix[" + bestIndex + "]");

            Console.ReadKey();
        }

        private static string Print(List<double> list)
        {
            int len = list.Count;
            string str = "[";

            for (int i = 0; i < len; i++)
            {
                str += "  " + list[i];
            }
            str += " ]";

            return str;
        }
        private static string Print(int[] a)
        {
            int len = a.Length;
            string str = "[";

            for (int i = 0; i < len; i++)
            {
                str += "  " + a[i];
            }
            str += " ]";

            return str;
        }
        private static string Print(int[][] matrix)
        {
            int rows = matrix.GetLength(0);

            string str = "";

            for (int i = 0; i < rows; i++)
            {
                int cols = matrix[i].Length;

                str += "[" + i + "]:\t";

                for (int j = 0; j < cols; j++)
                {
                    str += "  " + matrix[i][j];
                }
                str += "\n";
            }
            return str;
        }

        private static List<double> Compare(int[] a, int[][] matrix, int round = 1)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                double value = 1 - Dot(a, matrix[i]) / (Len(a) * Len(matrix[i]));
                result.Add(Math.Round(value, round));
            }
            return result;
        }

        private static double Len(int[] a)
        {
            int before_sqrt = SumOfQrt(a);
            double result = Math.Sqrt(before_sqrt);
            //Console.WriteLine(result);
            return result;
        }

        private static int SumOfQrt(int[] a)
        {
            int len = a.Length;
            int result = 0;
            for (int i = 0; i < len; ++i)
            {
                result += a[i] * a[i];
            }
            //Console.WriteLine(result);
            return result;
        }

        private static int Dot(int[] a, int[] b)
        {
            int len = a.Length;
            if (len != b.Length) return -1;

            int result = 0;
            for (int i = 0; i < len; ++i)
            {
                result += a[i] * b[i];
            }
            //Console.WriteLine(result);
            return result;
        }

    }
}
