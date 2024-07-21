public class Program
{
    public static void Main()
    {
        var address1 = new Address("18 Park Ave", "New York", "NY", "USA");
        var address2 = new Address("La Posh Hotel And Lounge Coker", "Lagos", "LA", "Nigeria");
        var address3 = new Address("Municipal Park", "Calabar", "CR", "Nigeria");

        var events = new List<Event>
        {
            new Lecture("Tech Talk", "A talk on the latest in tech And Brand Awareness.", "2024-07-21", "10:30 AM", address1, "Johnny Brown", 100),
            new Reception("Networking Night", "An evening of networking and discussing Business.", "2024-07-22", "6:00 PM", address2, "rsvp@outlook.com"),
            new OutdoorGathering("Community Picnic", "A picnic for the community And Loved Ones.", "2024-07-25", "1:00 PM", address3, "Sunny")
        };

        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
        }
    }
}
