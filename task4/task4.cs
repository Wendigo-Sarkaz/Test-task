class Task4
{
    private static void Main(string[] args)
    {
        string pathOne;
        List<int> values = new List<int>();
        int[] array;
        int point = 0;
        int steps = 0;
        try
        {
            Console.WriteLine("Введите полный путь до файла с числами.");
            pathOne = Console.ReadLine().ToString();
            StreamReader sr = new StreamReader(pathOne);
            while (true)
            {
                string? temp = sr.ReadLine();
                if (temp != null)
                {
                    values.Add(Convert.ToInt32(temp));
                }
                else
                {
                    break;
                }
            }
            sr.Close();
            array = values.ToArray();
            Array.Sort(array);

            if (array.Length % 2 == 0)
            {
                point = (int)(array[(array.Length / 2) - 1] + array[(array.Length / 2)]) / 2;
            }
            else if (array.Length % 2 == 1)
            {
                point = array[(int)Math.Round(((decimal)(array.Length / 2)), MidpointRounding.AwayFromZero)];
            }

            for (int i = 0; i < array.Length; i++)
            {
                while (array[i] != point)
                {
                    if (array[i] > point)
                    {
                        array[i]--;
                    }
                    else if (array[i] < point)
                    {
                        array[i]++;
                    }
                    steps++;
                }
            }

            Console.WriteLine("Ходы: " + steps);

        }
        catch (Exception e) 
        {
            Console.WriteLine("Ошибка");
            Console.WriteLine(e.Message);
        }
    }
}