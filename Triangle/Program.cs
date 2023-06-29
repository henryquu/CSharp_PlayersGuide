// See https://aka.ms/new-console-template for more information

Console.WriteLine("Length of the base of the triangle: ");
int base_ = int.Parse(Console.ReadLine());

Console.WriteLine("Height of the triangle: ");
int height = int.Parse(Console.ReadLine());

int area = base_ * height / 2;

Console.WriteLine("The area of the triangle is: " + area);