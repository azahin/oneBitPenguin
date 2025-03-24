using UnityEngine;

public class CameraLogic : MonoBehaviour {
    [Header("Initialization")]
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new(0, 1, 1);
    [SerializeField] private Vector3 rotation = new(30f, 0, 0);

    [Header("Settings")]
    [SerializeField] private Vector2 lookLimit = new(5, 70);

    private void Start() {
        transform.position = offset;
        transform.eulerAngles = rotation;
    }

    private void Update() {
        transform.position = player.position + offset;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(transform.eulerAngles.x + InputManager.instance.lookInput.y, lookLimit.x, lookLimit.y),
            transform.eulerAngles.y + InputManager.instance.lookInput.x,
            0f
        );
    }
}