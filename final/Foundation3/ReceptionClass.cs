public class Reception : Event
{
    private string _emailRSVP;

    public Reception(string title, string description, string date, string time, Address address, string emailRSVP)
        : base(title, description, date, time, address)
    {
        _emailRSVP = emailRSVP;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Reception\nEmail RSVP: {_emailRSVP}";
    }
}
