using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerPosition;
    public float moveSpeed = 3f;
    public float offsetDistance = 5f; // Minimum distance to maintain from the player
    private Animator animator;
    private bool isAlive = true;

    public bool isTakingDamage;

    public GameObject AmmoBoxPrefab;


    [Header("Script References")]
    public Gun gun;
    public Player player;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAlive)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = playerPosition.position - transform.position;
            float distance = direction.magnitude;

            if (distance > offsetDistance)
            {
                // Move the enemy towards the player
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
                transform.LookAt(playerPosition.position);

                // Trigger walk animation when moving
                animator.SetTrigger("Walk");
                animator.ResetTrigger("Attack");

                isTakingDamage = false;

            }
            else if(distance < offsetDistance && !isTakingDamage)
            {
                // Stop moving and trigger attack animation when close to the player
                animator.ResetTrigger("Walk");
                animator.SetTrigger("Attack");

                StartCoroutine(DamageDelay(0.5f));
                isTakingDamage = true;
            }
        }
        else
        {
            // Enemy is dead, stop all animations and movement
            animator.ResetTrigger("Walk");
            animator.ResetTrigger("Attack");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet") && isAlive)
        {
            isAlive = false;
            animator.SetTrigger("Die");

            Instantiate(AmmoBoxPrefab, transform.position, Quaternion.identity);

            GameManager.Instance.AddScore();
            GameManager.Instance.UpdateEnemyCount(-1);
            StartCoroutine(SpawnDelay(2f));


            //gun.maxAmmo += 20;

            //if (gun.currentAmmo <= 30)
            //    gun.currentAmmo += 30;
            //else
            //    gun.currentAmmo = 60;
        }
    }

    private IEnumerator SpawnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // If the GameManager's enemy count is still low, spawn a new enemy
        if (GameManager.Instance.enemyCount < 2)
        {
            int randomIndex = Random.Range(0, GameManager.Instance.spawnPoints.Length);
            Instantiate(GameManager.Instance.enemyPrefab, GameManager.Instance.spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }

    private IEnumerator DamageDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        player.currentHealth -= 20;

    }
}
