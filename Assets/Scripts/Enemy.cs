using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Movement")]
    [SerializeField] float shootCounter;
    [SerializeField] float minTimeBetweenShoot = 0.2f;
    [SerializeField] float maxTimeBetweenShoot = 3f;

    [Header("Enemy SFX")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.75f;
    [SerializeField] [Range(0, 1)] float shootSFXVolume = 0.5f;

    [Header("Projectile")]
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject desthVFX;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float durationOfExplosion = 1f;

    [Header("Enemy Status")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 150;
    // Start is called before the first frame update
    private void Start()
    {
        shootCounter = Random.Range(minTimeBetweenShoot, maxTimeBetweenShoot);
    }
    private void Update()
    {
        CountDownAndShoot();

    }

    private void CountDownAndShoot()
    {
        shootCounter -= Time.deltaTime;
        if (shootCounter <= 0f)
        {
            Fire();
            shootCounter = Random.Range(minTimeBetweenShoot, maxTimeBetweenShoot);
        }
    }
    private void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSFXVolume);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        FindObjectOfType<GameScession>().UpdateScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(desthVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }
}
