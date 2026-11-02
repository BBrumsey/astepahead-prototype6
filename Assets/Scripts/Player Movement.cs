using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;

    public float speed = 5;
   

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveInput.x * speed, rb.linearVelocity.y, moveInput.y * speed);
    }
}
