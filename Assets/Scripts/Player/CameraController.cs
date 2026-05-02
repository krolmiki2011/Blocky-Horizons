using UnityEngine;
using PurrNet;

public class CameraController : NetworkBehaviour
{
    [SerializeField] float mouseSensivity = 350f;

    Transform playerBody;

    float xRot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected override void OnSpawned()
    {
        base.OnSpawned();

        if (!isOwner)
        {
            Debug.Log("Camera go bye bye!");
            gameObject.SetActive(false);
            return;
        }

        playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        CameraLook();
    }

    void CameraLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 80f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
