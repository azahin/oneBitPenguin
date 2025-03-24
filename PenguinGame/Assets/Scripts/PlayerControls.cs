using UnityEngine;

public class PlayerControls : MonoBehaviour {
    private Vector3 moveDirection = Vector3.zero;

    private void Start() {
        InputManager.instance.playerTransform = transform;
    }

    private void Update() {
        moveDirection = InputManager.instance.cameraTransform.forward * InputManager.instance.moveInput.y + InputManager.instance.cameraTransform.right * InputManager.instance.moveInput.x;
        if (moveDirection == Vector3.zero) {
            moveDirection = InputManager.instance.cameraTransform.forward;
        }
        moveDirection.y = 0;

        transform.LookAt(transform.position + Vector3.Slerp(transform.forward, moveDirection, 10*Time.deltaTime));
    }
}