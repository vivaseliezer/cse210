using System;

public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Penalty is returned as a negative value
        return -Math.Abs(_points);
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[Bad Habit] {_shortName} ({_description}) -- Penalty: -{_points} pts";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName}|{_description}|{_points}";
    }
}
