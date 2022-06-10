using UnityEngine;

public class Character : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }


    }

    public void TakeDamage(int damage)
    {

        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //Clamping damage so it only deals damage between 0 and maxValue, avoid double negatives

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

        Debug.Log(transform.name + " died.");

    }



}
