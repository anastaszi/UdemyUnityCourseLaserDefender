using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake = false;

    [SerializeField] bool isPlayer = false;

    [SerializeField] int scoreValue = 50;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;

    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null) {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth() {
        return health;
    }

    void TakeDamage(int damage) {
        health -= damage;
        if (audioPlayer != null) {
            audioPlayer.PlayDamageSFX();
        }
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        if (!isPlayer && scoreKeeper != null) {
                scoreKeeper.ModifyScore(scoreValue);
        }  
        Destroy(gameObject);
    }

    void PlayHitEffect() {
        if (hitEffect != null) {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera() {
        if (applyCameraShake && cameraShake != null) {
            cameraShake.Play();
        }
    }

}
