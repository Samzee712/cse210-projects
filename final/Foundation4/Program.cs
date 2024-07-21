public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 07, 21), 30, 4.8),
            new Cycling(new DateTime(2024, 07, 20), 45, 20.0),
            new Swimming(new DateTime(2024, 07, 15), 25, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}