public class HealthSystem
{
    public int health;
    public int healthMax;

    public HealthSystem(int healthMax)
    {
        // the first healthMax is the varible above.
        // While the secound one the max health value
        // that will be inserted when using the healthSystem.
        this.healthMax = healthMax;
        health = healthMax;
    }
    public int getHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
    }
}