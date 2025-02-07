using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> habitTracker = new Dictionary<string, int>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n🔹 Simple Habit Tracker 🔹");
            Console.WriteLine("1. Add Habit");
            Console.WriteLine("2. Log Progress");
            Console.WriteLine("3. View Summary");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddHabit();
                    break;
                case "2":
                    LogProgress();
                    break;
                case "3":
                    ViewSummary();
                    break;
                case "4":
                    Console.WriteLine("✅ Exiting... See you next time!");
                    return;
                default:
                    Console.WriteLine("❌ Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddHabit()
    {
        Console.Write("Enter the name of the habit: ");
        string habit = Console.ReadLine();
        if (!habitTracker.ContainsKey(habit))
        {
            habitTracker[habit] = 0;
            Console.WriteLine($"✅ Habit '{habit}' added successfully.");
        }
        else
        {
            Console.WriteLine("⚠️ Habit already exists.");
        }
    }

    static void LogProgress()
    {
        Console.Write("Enter the habit name: ");
        string habit = Console.ReadLine();
        if (habitTracker.ContainsKey(habit))
        {
            habitTracker[habit]++;
            Console.WriteLine($"✅ Progress logged! You have done '{habit}' {habitTracker[habit]} times.");
        }
        else
        {
            Console.WriteLine("⚠️ Habit not found. Add it first.");
        }
    }

    static void ViewSummary()
    {
        Console.WriteLine("\n📊 Habit Progress Summary:");
        if (habitTracker.Count == 0)
        {
            Console.WriteLine("⚠️ No habits logged yet.");
        }
        else
        {
            foreach (var habit in habitTracker)
            {
                Console.WriteLine($"📌 {habit.Key}: {habit.Value} times");
            }
        }
    }
}
