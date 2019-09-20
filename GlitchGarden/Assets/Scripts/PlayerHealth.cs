using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        UpdateDisplay();
        if(health<=0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
