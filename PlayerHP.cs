using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int health;
    public Text helthDisplay;
    private void Update()
    {
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        helthDisplay.text = "HP: " + health;
    }
}
