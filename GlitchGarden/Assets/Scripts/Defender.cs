using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 10;


    public int GetStarCost() { return starCost; }

    public void AddStars(int starsToAdd)
    {
        FindObjectOfType<StarDisplay>().AddStars(starsToAdd);
    }

}
