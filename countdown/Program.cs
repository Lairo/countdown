using System;
using System.Threading;

class CountdownTimer
{
    static int targetTime = 5000; // Change this value to set the countdown duration in milliseconds
    static bool isRunning = true;

    static void Main()
    {
        Console.WriteLine("Countdown Timer (in milliseconds)");

        // Start the timer in a separate thread
        Thread timerThread = new Thread(TimerLoop);
        timerThread.Start();

        // Wait for the timer to finish
        timerThread.Join();

        Console.WriteLine("Countdown finished!");
    }

    static void TimerLoop()
    {
        DateTime startTime = DateTime.Now;
        int elapsedTime;

        while (isRunning)
        {
            elapsedTime = (int)(DateTime.Now - startTime).TotalMilliseconds;

            // Calculate remaining time
            int remainingTime = targetTime - elapsedTime;

            if (remainingTime <= 0)
            {
                isRunning = false;
                break;
            }

            // Update the display every millisecond
            Console.WriteLine($"Time remaining: {remainingTime} ms");

            // Sleep for 1 millisecond before updating again
            Thread.Sleep(1);
        }
    }
}