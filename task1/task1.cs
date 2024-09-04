int position = 0;
int n, m;
string stream, way = "";
int[] array;
string[] insert;
Console.WriteLine("Введите размер массива и интервала через пробел. (<число> <число>)");
stream = Console.ReadLine().ToString();
stream = stream.Trim();
try
{
    insert = stream.Split(' ');
    if (insert.Length < 3)
    {
        n = Convert.ToInt32(insert[0]);
        m = Convert.ToInt32(insert[1]);
        array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = i + 1;
        }
        do
        {
            way += array[position].ToString();
            for (int i = 0; i < m; i++)
            {

                if (position + i > array.Length - 1)
                {
                    position -= array.Length;
                }

                Console.Write(array[position + i]);
            }
            Console.WriteLine();
            position += m - 1;

        }
        while (array[0] != array[position]);
        Console.WriteLine(way);
    }
    else
    {
        Console.WriteLine("Ошибка, введено больше 2 чисел");
    }
} catch
{
    Console.WriteLine("Ошибка, введён не верный формат данных");
}


