bool flag = false;
StreamReader streamReader = null;

do
{
    /* commented out because I don't want to ask the user for the path of the file */
    //Console.Write("Please provide the location of the file: ");
    //var pathFromTheUser = Console.ReadLine();

    try
    {   
        /* commented out because I didnt  ask the user for the path of the file */
        //streamReader = new StreamReader(pathFromTheUser);
        streamReader = new StreamReader(@"C:\Users\desja\Downloads\simple_csv.csv");
        flag = false;
    }
    catch (Exception e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
        flag = true;
        Console.WriteLine("Please try again!");
    }
} while (flag);

var people = new List<Person>();

while (!streamReader.EndOfStream)
{
    var collection = streamReader.ReadLine().Split(',');

    people.Add( new Person
    {
        FirstName = collection[0],
        LastName = collection[1]
    });
}

//close the streamReader
streamReader.Close();

foreach (var person in people)
{
    Console.WriteLine(person.FullName);
}

//add new random people to the list
people.Add(new Person { FirstName = "John", LastName = "Doe" });
people.Add(new Person { FirstName = "Jane", LastName = "Doe" });

StreamWriter streamWriter = new StreamWriter(@"C:\Users\desja\Downloads\simple_csv.csv", false);
foreach (var person in people)
{
    streamWriter.WriteLine($"{person.ToCsv()}");
}

streamWriter.Close();

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

    public string ToCsv()
    {
        return $"{FirstName},{LastName}";
    }
   
}
