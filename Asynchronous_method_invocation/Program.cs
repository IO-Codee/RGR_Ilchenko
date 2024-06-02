
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main thread starting...");

        Task<int> task = HandleAsyncOperation();

        // You can do other work that doesn't rely on task before calling await.
        Console.WriteLine("Main thread continuing...");

        // Now we can await the task to get the result
        task.Wait(); // This will block the main thread until the task completes.
        Console.WriteLine($"Result: {task.Result}");

        Console.WriteLine("Main thread ending...");
    }

    static async Task<int> HandleAsyncOperation()
    {
        Console.WriteLine("Async operation started...");
        await Task.Delay(2000); // Simulate async operation with 2 sec delay
        Console.WriteLine("Async operation completed...");
        return 42; // return some result
    }
}
