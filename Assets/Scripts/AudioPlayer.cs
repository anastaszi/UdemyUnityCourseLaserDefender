using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingSFX;
    [SerializeField] [Range(0,1)] float shootingSFXVolume = 0.5f;

        [Header("Damage")]
    [SerializeField] AudioClip damageSFX;
    [SerializeField] [Range(0,1)] float damageSFXVolume = 0.5f;

    public void PlayShootingSFX() {
        PlayClip(shootingSFX, shootingSFXVolume);
    }

    public void PlayDamageSFX() {
        PlayClip(damageSFX, damageSFXVolume);
    }

    void PlayClip(AudioClip clip, float volume) {
        Vector3 cameraPosition = Camera.main.transform.position;
        if (clip != null) {
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }
}
