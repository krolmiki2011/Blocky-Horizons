using UnityEngine;
using PurrNet;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : NetworkBehaviour
{
    [Header("Movement Settings")]
    float speed;
    [SerializeField] float normalSpeed = 5;
    [SerializeField] float runSpeed = 10;

    private CharacterController controller;


    protected override void OnSpawned()
    {
        base.OnSpawned();

        enabled = isOwner;

        controller = GetComponent<CharacterController>();

        Debug.Log("Hello player!");
    }

    // Update is called once per frame
    void Update()
    {
        speed = normalSpeed;
        HandleMovement();
        HandleSpeed();
    }

    void HandleSpeed()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        dir = dir.normalized;

        controller.Move(dir * speed * Time.deltaTime);
    }
}
