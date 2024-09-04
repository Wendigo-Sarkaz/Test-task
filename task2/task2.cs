using System.IO;

string pathOne, pathTwo;
string[] points = new string[100];
string[] round = new string[2];
string[] coordinates = new string[2];
double xO, yO, rO, x, y, r;
try
{
    Console.WriteLine("Введите полный путь до файла с координатами центра и радиусом");
    pathOne = Console.ReadLine().ToString();
    using (StreamReader sr = new StreamReader(pathOne))
    {
        round[0] = sr.ReadLine();
        round[1] = sr.ReadLine();
    }
    coordinates = round[0].Split(' ');
    xO = Convert.ToDouble(coordinates[0]);
    yO = Convert.ToDouble(coordinates[1]);
    rO = Convert.ToDouble(round[1]);

    Console.WriteLine("Введите полный путь до файла с координатами точек");
    pathTwo = Console.ReadLine().ToString();

    using (StreamReader sr = new StreamReader(pathTwo))
    {
        int i = 0;
        string temp;
        while ((temp = sr.ReadLine()) != null)
        {
            points[i] = temp;
            i++;
        }
    }

    foreach (string point in points)
    {
        if (point != null)
        {
            x = Convert.ToDouble((point.Split(' ')[0]));
            y = Convert.ToDouble((point.Split(' ')[1]));
            r = Math.Sqrt(Math.Pow((x - xO), 2) + Math.Pow((y - yO), 2));
            if (r == rO)
            {
                Console.WriteLine(0);
            }
            else if (r > rO)
            {
                Console.WriteLine(2);
            }
            else if (r < rO)
            {
                Console.WriteLine(1);
            }
        }
        else break;
    }
}
catch (Exception e)
{
    Console.WriteLine("Ошибка");
    Console.WriteLine(e.Message);
}