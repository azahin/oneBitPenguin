using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour {
    PlayerInput input;
    Vector2 movement;

    private void Start() {
        input = GetComponent<PlayerInput>();
        movement = input.actions["Move"].ReadValue<Vector2>();
    }

    private void Update() {
        Debug.Log(movement);
    }
}