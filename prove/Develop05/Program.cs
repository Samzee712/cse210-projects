using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();

        while (true)
        {
            Console.WriteLine(" Menu Options:\n");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create New Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit \n");
            Console.Write("Please Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.DisplayPlayerInfo();
                    break;
                case 2:
                    manager.ListGoalDetails();
                    break;
                case 3:
                    CreateNewGoal(manager);
                    break;
                case 4:
                    RecordEvent(manager);
                    break;
                case 5:
                    manager.SaveGoals();
                    break;
                case 6:
                    manager.LoadGoals();
                    break;
                case 7:
                    return;
            }
        }
    }

    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.WriteLine("5. Progress Goal");
        Console.Write("Choose a goal type: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Enter short name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                manager.CreateGoal(new SimpleGoal(name, description, points));
                break;
            case 2:
                manager.CreateGoal(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Enter target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.CreateGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case 4:
                manager.CreateGoal(new NegativeGoal(name, description, points));
                break;
            case 5:
                Console.Write("Enter target: ");
                target = int.Parse(Console.ReadLine());
                manager.CreateGoal(new ProgressGoal(name, description, points, target));
                break;
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        Console.WriteLine("Choose a goal to record an event for:");
        manager.ListGoalNames();
        int index = int.Parse(Console.ReadLine());
        manager.RecordEvent(index);
    }
}
//  I Added a leveling up, earning badges, and also introduce negative goals and progressive goals.
//User can load and save file from the program.
