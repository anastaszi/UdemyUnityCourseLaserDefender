using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 1f;

    [Header("AI")]
    [SerializeField] bool useAI;

    [SerializeField] float firingTimeVariance = 0.3f;
    [SerializeField] float minFiringTime = 0.2f;

    Coroutine firingCoroutine;

    [HideInInspector] public bool isFiring;

    void Start()
    {
        if (useAI) {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
      Fire();   
    }

    void Fire() {
        if (isFiring && firingCoroutine == null){
            firingCoroutine = StartCoroutine(FireContinuously());
        } else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinuously() {
        while (true) {
            GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            Destroy(laser, projectileLifeTime);
            yield return new WaitForSeconds(GetRandomShootingTime());
        }

    }

    float GetRandomShootingTime() {
        float firingTime = Random.Range(firingRate-firingTimeVariance, firingRate+firingTimeVariance);
        return Mathf.Clamp(firingTime, minFiringTime, float.MaxValue);
    }
}
