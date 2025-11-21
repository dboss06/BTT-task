Console.WriteLine("Please Enter Min Value");
int min = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Please Enter Max Value");
int max = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Please Enter Interval");
int interval = Convert.ToInt32(Console.ReadLine());

int mod = (max-min) % interval;

if (mod == 0)
{
    int n = (max - min) / interval;
    int i = 1;
    int sum = 0;

    while(i <= n)
    {
        sum = sum + min;
        min = min + interval;
        i = i + 1;

        Console.WriteLine($"{sum},{min},{i},{n}");
    }
    Console.WriteLine($"{sum}");
}
else
{
    Console.WriteLine("Invalid Interval");
}