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
            Console.WriteLine("4. Edit Habit");
            Console.WriteLine("5. Delete Habit");
            Console.WriteLine("6. Exit");
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
                    EditHabit();
                    break;
                case "5":
                    DeleteHabit();
                    break;
                case "6":
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
            Console.Write("Enter the number of days to log: ");
            if (int.TryParse(Console.ReadLine(), out int daysToLog) && daysToLog > 0)
            {
                habitTracker[habit] += daysToLog;
                Console.WriteLine($"✅ Logged {daysToLog} day(s) for '{habit}'. Total: {habitTracker[habit]} times.");
            }
            else
            {
                Console.WriteLine("⚠️ Invalid input. Please enter a positive number.");
            }
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
            return;
        }

        Console.Write("View all habits (A) or a specific habit (S)? ");
        string choice = Console.ReadLine().Trim().ToUpper();

        if (choice == "A")
        {
            foreach (var habit in habitTracker)
            {
                Console.WriteLine($"📌 {habit.Key}: {habit.Value} times");
            }
        }
        else if (choice == "S")
        {
            Console.Write("Enter the habit name: ");
            string habitName = Console.ReadLine();
            if (habitTracker.ContainsKey(habitName))
            {
                Console.WriteLine($"📌 {habitName}: {habitTracker[habitName]} times");
            }
            else
            {
                Console.WriteLine("⚠️ Habit not found.");
            }
        }
        else
        {
            Console.WriteLine("⚠️ Invalid selection.");
        }
    }

    static void EditHabit()
    {
        Console.Write("Enter the habit name to edit: ");
        string oldHabit = Console.ReadLine();
        if (habitTracker.ContainsKey(oldHabit))
        {
            Console.Write("Enter the new name for the habit: ");
            string newHabit = Console.ReadLine();
            if (!habitTracker.ContainsKey(newHabit))
            {
                habitTracker[newHabit] = habitTracker[oldHabit];
                habitTracker.Remove(oldHabit);
                Console.WriteLine($"✅ Habit renamed from '{oldHabit}' to '{newHabit}'.");
            }
            else
            {
                Console.WriteLine("⚠️ A habit with this name already exists.");
            }
        }
        else
        {
            Console.WriteLine("⚠️ Habit not found.");
        }
    }

    static void DeleteHabit()
    {
        Console.Write("Enter the habit name to delete: ");
        string habit = Console.ReadLine();
        if (habitTracker.ContainsKey(habit))
        {
            habitTracker.Remove(habit);
            Console.WriteLine($"🗑️ Habit '{habit}' deleted successfully.");
        }
        else
        {
            Console.WriteLine("⚠️ Habit not found.");
        }
    }
}
