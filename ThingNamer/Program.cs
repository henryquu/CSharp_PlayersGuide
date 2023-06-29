Console.WriteLine("What kind of thing are we talking about?");
string topic = Console.ReadLine(); // topic of discussion

Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string adjective = Console.ReadLine(); // one-word description


/*
 Print 'The <adjective> <topic> of Doom 3000!'
 */
Console.WriteLine("The " + adjective + " " + topic + "of Doom 3000!");
