using UnityEngine;


public class Player_Movement : MonoBehaviour
{
    public float speed = 5;
    CharacterController controller;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
