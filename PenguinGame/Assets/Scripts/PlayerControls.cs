using UnityEngine;

public class PlayerControls : MonoBehaviour {
    Vector2 movement;

    private void Start() {
        //input = GetComponent<PlayerInput>();
        //movement = input.actions["Move"].ReadValue<Vector2>();
    }

    private void Update() {
        transform.position += Time.deltaTime * new Vector3(0, 0, 1);
    }
}