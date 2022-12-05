using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    CharacterStats stats;
    
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
        stats = FindObjectOfType<CharacterStats>();
    }

    void onEquipmentChanged(Eq newItem, Eq oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }
        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }
    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
            
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentHealth <= 95)
            {
                Heal(5);
            }
            else if (currentHealth == 96)
            {
                Heal(4);
            }
            else if (currentHealth == 97)
            {
                Heal(3);
            }
            else if (currentHealth == 98)
            {
                Heal(2);
            }
            else if (currentHealth == 99)
            {
                Heal(1);
            }
        }
        
        
    }

}
