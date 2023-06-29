using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System;

Console.Write(
@"The following items are available:
1 – Rope
2 – Torches
3 – Climbing Equipment
4 – Clean Water
5 – Machete
6 – Canoe
7 – Food Supplies
What number do you want to see the price of? "
);
int item = int.Parse(Console.ReadLine());

Console.Write("What's your name? ");
string name = Console.ReadLine();

float costMultiplier = (name == "Sebastian") ? 0.5f : 1;

string response = item switch{
    1 => $"Rope costs {10 * costMultiplier} gold.",
    2 => $"Torches cost {15 * costMultiplier} gold.",
    3 => $"Climbing Equipment costs {25 * costMultiplier} gold.",
    4 => $"Clean Water costs {1 * costMultiplier} gold.",
    5 => $"Machete costs {20 * costMultiplier} gold.", 
    6 => $"Canoe costs {200 * costMultiplier} gold.",
    7 => $"Food Supplies cost {1 * costMultiplier} gold.",
    _ => $"Apologies. I do not know that one."
};
Console.WriteLine(response);