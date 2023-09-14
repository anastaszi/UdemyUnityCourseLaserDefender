using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInputVector;
    [SerializeField] float moveSpeed = 5f;
    void Update()
    {
        Vector3 delta = rawInputVector * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInputVector = value.Get<Vector2>();
        Debug.Log("Move: " + rawInputVector);
    }
}
