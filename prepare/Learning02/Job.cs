public class Job
{
    public string _jobTittle;
    public string _company;
    public int _startYear;
    public int _endYear;
public void Display()
{
    Console.WriteLine($"{_jobTittle}, ({_company}) {_startYear}--{_endYear}");

}


    

}
