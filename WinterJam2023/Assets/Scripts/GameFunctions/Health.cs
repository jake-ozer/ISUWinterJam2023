using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float curHealth = 0;
    public float maxHealth = 180;
    public Material def;
    public Material flash;

    public HealthBar healthBar;
    public SpriteRenderer sr;
    public NPCStateController stateCon;

    void Start()
    {
        curHealth = maxHealth;
    }

    public void RestoreHealthToFull()
    {
        curHealth = maxHealth;
        healthBar.SetHealth(curHealth);
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        StartCoroutine("Flash");
        healthBar.SetHealth(curHealth);
        if (GetComponent<NPC>() != null)
        {
            GetComponent<NPC>().FlashHealthBar();
        }

        if (curHealth <= 0)
        {
            if (this.gameObject.name == "Player")
            {
                Destroy(this.gameObject);
            }
            else
            {
                stateCon.curState = NPCStateController.NPCState.dead;
            }
        }
    }

    public bool AddHealth(float health)
    {
        if (curHealth == maxHealth)
        {
            return false;
        }
        else
        {
            curHealth += health;
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
            healthBar.SetHealth(curHealth);
            return true;
        }
    }

    public void UpdateHealthBar()
    {
        healthBar.SetHealth(curHealth);
    }

    private IEnumerator Flash()
    {
        sr.material = flash;
        yield return new WaitForSeconds(0.08f);
        sr.material = def;
    }
}
