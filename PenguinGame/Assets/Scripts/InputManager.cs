using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public static InputManager instance;

    [SerializeField] private float sensitivity = 50.0f;
    [HideInInspector] public Vector2 lookInput;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LookInput(PlayerInput input) {
        lookInput = sensitivity * Vector2.Scale(input.actions["Look"].ReadValue<Vector2>(), new(1.0f, -0.8f));
        if (input.currentControlScheme == "Keyboard&Mouse") {
            lookInput *= 0.001f;
        } else {
            lookInput *= 0.02f;
        }
    }
}