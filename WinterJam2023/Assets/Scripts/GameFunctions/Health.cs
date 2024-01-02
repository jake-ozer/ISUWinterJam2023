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
    public AudioClip hitClip;

    void Start()
    {
        curHealth = maxHealth;
    }

    public bool HealCheck()
    {
        if (curHealth == maxHealth)
        {
            return false;
        }
        return true;
    }

    public void RestoreHealthToFull()
    {
        curHealth = maxHealth;
        healthBar.SetHealth(curHealth);
    }

    bool canTakeDamage = true;
    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            FindObjectOfType<SoundManager>().PlaySound(hitClip);
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
                    FindObjectOfType<LevelManager>().ResetScene();
                }
                else
                {
                    stateCon.curState = NPCStateController.NPCState.dead;
                }
            }
            canTakeDamage = false;
            Invoke("InvincibleTime", 0.05f);
        }
    }

    private void InvincibleTime()
    {
        canTakeDamage = true;
    }
        

    public void AddHealth(float health)
    {
        if (curHealth == maxHealth)
        {
            //do nothing
        }
        else
        {
            curHealth += health;
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
            healthBar.SetHealth(curHealth);
        }

        if (GetComponent<NPC>() != null)
        {
            GetComponent<NPC>().FlashHealthBar();
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
