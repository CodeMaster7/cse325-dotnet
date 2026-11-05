var currentDate = DateTime.Now;

Console.WriteLine("Hello, World!");
Console.WriteLine($"The current time is {currentDate.ToString("HH:mm:ss")}");
Console.WriteLine($"There are {(DateTime.Parse("2026-12-25") - currentDate.Date).Days} days until the next Christmas");