// Eventful HPValueWarning warning and OnCheckStatus handler
using System;

public delegate void CalculateHealth(float amount);

public enum Modifier
{
    Weak,
    Base,
    Strong
}

public delegate float CalculateModifier(float baseValue, Modifier modifier);

public class CurrentHPArgs : EventArgs
{
    public readonly float currentHp;

    public CurrentHPArgs(float newHp)
    {
        this.currentHp = newHp;
    }
}

public class Player
{
    private string name;
    private float maxHp;
    private float hp;
    private string status;

    public event EventHandler<CurrentHPArgs> HPCheck;

    public Player(string name = "Player", float maxHp = 100f)
    {
        if (maxHp <= 0f)
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        else
        {
            this.maxHp = maxHp;
        }

        this.hp = this.maxHp;
        this.name = name;
        this.status = $"{this.name} is ready to go!";
        this.HPCheck += CheckStatus;
    }

    public void PrintHealth()
    {
        Console.WriteLine($"{this.name} has {this.hp} / {this.maxHp} health");
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0f)
        {
            damage = 0f;
        }

        Console.WriteLine($"{this.name} takes {damage} damage!");
        ValidateHP(this.hp - damage);
    }

    public void HealDamage(float heal)
    {
        if (heal < 0f)
        {
            heal = 0f;
        }

        Console.WriteLine($"{this.name} heals {heal} HP!");
        ValidateHP(this.hp + heal);
    }

    public void ValidateHP(float newHp)
    {
        if (newHp < 0f)
        {
            this.hp = 0f;
        }
        else if (newHp > this.maxHp)
        {
            this.hp = this.maxHp;
        }
        else
        {
            this.hp = newHp;
        }

        OnCheckStatus(new CurrentHPArgs(this.hp));
    }

    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        if (modifier == Modifier.Weak)
        {
            return (float)((decimal)baseValue * 0.5m);
        }

        if (modifier == Modifier.Base)
        {
            return baseValue;
        }

        if (modifier == Modifier.Strong)
        {
            return (float)((decimal)baseValue * 1.5m);
        }

        return baseValue;
    }

    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == this.maxHp)
        {
            this.status = $"{this.name} is in perfect health!";
        }
        else if (e.currentHp >= (this.maxHp / 2f))
        {
            this.status = $"{this.name} is doing well!";
        }
        else if (e.currentHp >= (this.maxHp / 4f))
        {
            this.status = $"{this.name} isn't doing too great...";
        }
        else if (e.currentHp > 0f)
        {
            this.status = $"{this.name} needs help!";
        }
        else
        {
            this.status = $"{this.name} is knocked out!";
        }

        Console.WriteLine(this.status);
    }

    private void HPValueWarning(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == 0f)
        {
            Console.WriteLine("Health has reached zero!");
        }
        else
        {
            Console.WriteLine("Health is low!");
        }
    }

    public virtual void OnCheckStatus(CurrentHPArgs e)
    {
        if (e.currentHp <= (this.maxHp / 4f))
        {
            this.HPCheck -= HPValueWarning;
            this.HPCheck += HPValueWarning;
        }
        else
        {
            this.HPCheck -= HPValueWarning;
        }

        this.HPCheck?.Invoke(this, e);
    }
}
