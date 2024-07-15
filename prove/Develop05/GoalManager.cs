// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _experience;
    private List<string> _badges;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _experience = 0;
        _badges = new List<string>();
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!\n");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Experience: {_experience}");
        Console.WriteLine("Badges: " + string.Join(", ", _badges));
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i}. {_goals[i].GetStringRepresentation()}");
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            var goal = _goals[goalIndex];
            goal.RecordEvent();
            if (goal is NegativeGoal)
            {
                _score -= goal.GetPoints();
            }
            else
            {
                _score += goal.GetPoints();
                _experience += goal.GetPoints();
                CheckLevelUp();
            }
            Console.WriteLine($"Recorded event for goal: {goal.GetStringRepresentation()}");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(_experience);
            writer.WriteLine(string.Join(",", _badges));
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                _score = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _experience = int.Parse(reader.ReadLine());
                _badges = new List<string>(reader.ReadLine().Split(','));
                _goals.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(':');
                    string goalType = parts[0];
                    string[] goalDetails = parts[1].Split(',');

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            var simpleGoal = new SimpleGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]));
                            if (bool.Parse(goalDetails[3])) simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            var eternalGoal = new EternalGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]));
                            _goals.Add(eternalGoal);
                            break;
                        case "ChecklistGoal":
                            var checklistGoal = new ChecklistGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]), int.Parse(goalDetails[4]), int.Parse(goalDetails[5]));
                            for (int i = 0; i < int.Parse(goalDetails[3]); i++) checklistGoal.RecordEvent();
                            _goals.Add(checklistGoal);
                            break;
                        case "NegativeGoal":
                            var negativeGoal = new NegativeGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]));
                            _goals.Add(negativeGoal);
                            break;
                        case "ProgressGoal":
                            var progressGoal = new ProgressGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]), int.Parse(goalDetails[4]));
                            for (int i = 0; i < int.Parse(goalDetails[3]); i++) progressGoal.RecordEvent();
                            _goals.Add(progressGoal);
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    private void CheckLevelUp()
    {
        int experienceNeeded = _level * 100;
        if (_experience >= experienceNeeded)
        {
            _experience -= experienceNeeded;
            _level++;
            Console.WriteLine($"Congratulations! You've leveled up to level {_level}!");
            _badges.Add($"Level {_level} Badge");
            Console.WriteLine($"You've earned a new badge: Level {_level} Badge!");
        }
    }
}
