
using Diplomska.Dal.RootTable;
using Diplomska.Domain.Models;

public class Rootobject
{
    public MRData MRData { get; set; }
}


public class ResultRecetable
{
    public string season { get; set; }
    public string round { get; set; }
    public List<Race> Races{ get; set; }
}

/*public class Race
{
    public string season { get; set; }
    public string round { get; set; }
    public string url { get; set; }
    public string raceName { get; set; }
    public Circuit Circuit { get; set; }
    public string date { get; set; }
    public string time { get; set; }
    public Result[] Results { get; set; }
}*/




/*public class Result
{
    public string number { get; set; }
    public string position { get; set; }
    public string positionText { get; set; }
    public string points { get; set; }
    public Driver Driver { get; set; }
    public Constructor Constructor { get; set; }
    public string grid { get; set; }
    public string laps { get; set; }
    public string status { get; set; }
    public Time Time { get; set; }
    public Fastestlap FastestLap { get; set; }
}*/
/*
public class Driver
{
    public string driverId { get; set; }
    public string permanentNumber { get; set; }
    public string code { get; set; }
    public string url { get; set; }
    public string givenName { get; set; }
    public string familyName { get; set; }
    public string dateOfBirth { get; set; }
    public string nationality { get; set; }
}

public class Constructor
{
    public string constructorId { get; set; }
    public string url { get; set; }
    public string name { get; set; }
    public string nationality { get; set; }
}

public class Time
{
    public string millis { get; set; }
    public string time { get; set; }
}

public class Fastestlap
{
    public string rank { get; set; }
    public string lap { get; set; }
    public Time1 Time { get; set; }
    public Averagespeed AverageSpeed { get; set; }
}

public class Time1
{
    public string time { get; set; }
}

public class Averagespeed
{
    public string units { get; set; }
    public string speed { get; set; }
}
*/
