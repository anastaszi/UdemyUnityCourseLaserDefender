using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake = false;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;

    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
         audioPlayer = FindObjectOfType<AudioPlayer>();
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

    void TakeDamage(int damage) {
        health -= damage;
        if (audioPlayer != null) {
            audioPlayer.PlayDamageSFX();
        }
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect() {
        if (hitEffect != null) {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //instance.Play();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera() {
        if (applyCameraShake && cameraShake != null) {
            cameraShake.Play();
        }
    }

}
