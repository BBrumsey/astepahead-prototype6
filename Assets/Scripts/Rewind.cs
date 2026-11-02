using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class Rewind : MonoBehaviour
{
    private Rigidbody rb;
    private bool isRewinding = false;
    public List<PlayerSnapshot> playerSnapshots = new List<PlayerSnapshot>();

    // Recording and rewind methods will go here.

  void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    IEnumerator RewindCoroutine()
    {
        isRewinding = true;
        rb.isKinematic = true;

        for (int i = playerSnapshots.Count - 1; i >= 0; i--)
        {
            transform.position = playerSnapshots[i].position;
            yield return null;
        }

        rb.isKinematic = false;
        rb.linearVelocity = playerSnapshots[0].velocity;
        playerSnapshots.Clear();
        isRewinding = false;
    }

    public void Do()
    {
     
        if (isRewinding || playerSnapshots.Count == 0)
        {
            return;
        }

        StartCoroutine(RewindCoroutine());
    }

    void OnRewind(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Rewind button received");
            Do();
        }
    }

    void Update()
    {
        if (isRewinding)
        {
            return;
        }

        playerSnapshots.Add(new PlayerSnapshot
        {
            position = transform.position,
            velocity = rb.linearVelocity
        });


    }
[System.Serializable]
 
public class PlayerSnapshot
{
    public Vector3 position;
    public Vector3 velocity;

 
}
    }

