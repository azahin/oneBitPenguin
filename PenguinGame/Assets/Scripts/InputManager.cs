using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public static InputManager instance;
    public Transform playerTransform;
    public Transform cameraTransform;

    [SerializeField] private float sensitivity = 50.0f;
    [HideInInspector] public Vector2 lookInput;
    [HideInInspector] public Vector3 moveInput = Vector3.zero;

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

    public void LookInput(InputAction.CallbackContext ctx) {
        lookInput = sensitivity * Vector2.Scale(ctx.ReadValue<Vector2>(), new(1.0f, -0.8f));
        if (ctx.control.device is Mouse) {
            lookInput *= 0.001f;
        } else {
            lookInput *= 0.02f;
        }
    }

    public void MoveInput(InputAction.CallbackContext ctx) {
        Vector2 input = ctx.ReadValue<Vector2>();
        moveInput.x = input.x;
        moveInput.z = input.y;
    }
}