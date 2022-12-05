using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class CharacterStats : MonoBehaviour
{
    #region Lua
    void OnEnable()
    {
        // Make the functions available to Lua: (Replace these lines with your own.)
        Lua.RegisterFunction("Heal", this, SymbolExtensions.GetMethodInfo(() => Heal((double)0)));
        
    }
    void OnDisable()
    {
        Lua.UnregisterFunction("Heal");
        
    }


    #endregion
    public int MaxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    


    private void Awake()
    {
        currentHealth = MaxHealth;
        
    }
    private void Update()
    {
        
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        

    }
    public void Heal(double Heal)
    {
        currentHealth += (int)Heal;
        
    }
    

    public void TakeDamage(int damage)
    {
        

        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + "damage.");

        if (currentHealth <= 0)
        {

            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died");
    }

}
