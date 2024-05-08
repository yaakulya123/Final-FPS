using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyLocater : MonoBehaviour
{
    public FirstPersonController FPS;
    public string enemyName;

    public bool isEnemyDead;

    private void Start()
    {
        isEnemyDead = false;
    }

    private void Update()
    {
        hasEnemyDied();
    }

    public void hasEnemyDied()
    {
        Transform childEnemy = transform.Find(enemyName);

        if (childEnemy == null)
            isEnemyDead = true;

        else
           isEnemyDead = false;
    }


    public float CalculateDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, FPS.transform.position);
    }
}
