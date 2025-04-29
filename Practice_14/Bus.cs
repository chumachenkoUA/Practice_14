using System;

public interface IDriveable
{
    string Drive();
}

public interface IServiceable
{
    string Service();
}

public class Bus : IDriveable, IServiceable
{
    public string Name { get; set; }
    public event EventHandler? OnDeparted;

    public Bus(string name)
    {
        Name = name;
    }

    public virtual string Drive()
    {
        return $"{Name} їде по маршруту.";
    }

    public virtual string Service()
    {
        return $"{Name} проходить технічне обслуговування.";;
        
    }

    public  void Depart()
    {
        OnDeparted?.Invoke(this, EventArgs.Empty);
    }

    public virtual string GetInfo()
    {
        return "Автобус";
    }
}

public class ExpressBus : Bus
{
    public ExpressBus(string name) : base(name) { }

    public override string GetInfo()
    {
        return "Експрес";
    }
}

public class SuburbanBus : Bus
{
    public SuburbanBus(string name) : base(name) { }

    public override string GetInfo()
    {
        return "Приміський";
    }
}

public class CityBus : Bus
{
    public CityBus(string name) : base(name) { }

    public override string GetInfo()
    {
        return "Міський";
    }
}
