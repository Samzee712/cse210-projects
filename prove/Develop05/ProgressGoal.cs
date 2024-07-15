
using System;

public class ProgressGoal : Goal
{
    private int _progress;
    private int _target;

    public ProgressGoal(string name, string description, int points, int target)
        : base(name, description, points)
    {
        _progress = 0;
        _target = target;
    }

    public override void RecordEvent()
    {
        _progress++;
    }

    public override bool IsComplete()
    {
        return _progress >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} - {_description}, Points per unit: {_points}, Progress: {_progress}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{_shortName},{_description},{_points},{_progress},{_target}";
    }
}
