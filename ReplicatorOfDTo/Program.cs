int[] array = new int[5];

for  (int i = 0; i < array.Length; i++) {
    Console.Write("What's your next number? ");
    array[i] = int.Parse(Console.ReadLine());
}

int[] copy = array[..];

for (int i = 0; i < array.Length; i++)
    Console.WriteLine($"{i + 1}. {array[i]} {copy[i]}");
