using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInputVector;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft = 1f;
    [SerializeField] float paddingRight = 1f;
    [SerializeField] float paddingTop = 1f;
    [SerializeField] float paddingBottom = 1f;
    Vector2 minScreenBounds;
    Vector2 maxScreenBounds;

    Shooter shooter;

    void Awake() {
        shooter = GetComponent<Shooter>();
    }

    void Start () {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds() {
        Camera mainCamera = Camera.main;
        minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move() {
        Vector2 delta = rawInputVector * moveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minScreenBounds.x + paddingLeft, maxScreenBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minScreenBounds.y + paddingBottom, maxScreenBounds.y - paddingTop);
        transform.position = newPosition;
    }

    void OnMove(InputValue value)
    {
        rawInputVector = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter) {
            shooter.isFiring = value.isPressed;
            
        }
    }
}
