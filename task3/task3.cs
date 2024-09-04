using System.IO;
using Newtonsoft.Json;


class Task3
{
    public class TestResult
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class Test
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Test> values { get; set; }
    }

    public class TestsData
    {
        public List<Test> tests { get; set; }
    }

    public class valuesData
    {
        public List<TestResult> values { get; set; }
    }

    public static void UpdateTestValues(List<Test> tests, List<TestResult> values)
    {
        if (tests == null || values == null)
        {
            return;
        }

        foreach (var test in tests)
        {
            if (test == null) continue;

            var result = values.Find(r => r.id == test.id);
            if (result != null)
            {
                test.value = result.value;
            }

            if (test.values != null && test.values.Count > 0)
            {
                UpdateTestValues(test.values, values);
            }
        }
    }


    static void Main(string[] args)
    {
        try 
        {
            string pathOne, pathTwo, pathThree;

            Console.WriteLine("Введите путь до файла tests.json (Пример: C:\\Your\\Path\\to\\file\\)");
            pathOne = Console.ReadLine().ToString();
            Console.WriteLine("Введите путь до файла values.json (Пример: C:\\Your\\Path\\to\\file\\)");
            pathTwo = Console.ReadLine().ToString();
            Console.WriteLine("Введите путь до файла report.json (Пример: C:\\Your\\Path\\to\\file\\)");
            pathThree = Console.ReadLine().ToString();

            var testsJson = File.ReadAllText(@"" + pathOne + "tests.json");
            var valuesJson = File.ReadAllText(@"" + pathTwo + "values.json");

            var testsData = JsonConvert.DeserializeObject<TestsData>(testsJson);
            var valuesData = JsonConvert.DeserializeObject<valuesData>(valuesJson);

            UpdateTestValues(testsData.tests, valuesData.values);

            var resultJson = JsonConvert.SerializeObject(testsData, Formatting.Indented);
            File.WriteAllText(@"" + pathThree + "report.json", resultJson);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка");
            Console.WriteLine(e.Message);
        }
    }
}
