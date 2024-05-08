using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerPos;
    public Transform bulletSpawnPoint;
    public float fireRate = 1f;
    private float lastFireTime;

    public FirstPersonController player;
    public AICharacterControl aiEnemy;

    [Header("Enemy")]
    public ThirdPersonCharacter thirdPerson;

    private GameObject enemyGun;


    private void Start()
    {
        // Find gun gameobject
        Transform gunTransform = transform.Find("UMP-45");
        enemyGun = gunTransform.gameObject;
    }



    private void Update()
    {
        if(Time.time > lastFireTime + 1f / fireRate && aiEnemy.isFollowingPlayer)
        {
            if(!thirdPerson.hasEnemyDied)
            {
                ShootAtPlayer();
            } 
            
            lastFireTime = Time.time;
        }

        HidePlayer();

    }

    private void ShootAtPlayer()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Vector3 playerDirection = (playerPos.transform.position - bulletSpawnPoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = playerDirection * 50;

    }

    private void HidePlayer()
    {
        if (thirdPerson.hasEnemyDied)
        {
            enemyGun.SetActive(false);
        }
    }
}
