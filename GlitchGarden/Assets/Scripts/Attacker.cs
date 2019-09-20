using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    static int attackerCount = 0;
    [SerializeField] int damageToPlayer = 10;
    float currentSpeed = 0f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController!=null)
        {
            levelController.AttackerKilled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left *currentSpeed* Time.deltaTime);
        UpdateAnimationState();
    }

    public int GetDamageToPlayer() { return damageToPlayer; }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("bIsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("bIsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget){ return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }

}
