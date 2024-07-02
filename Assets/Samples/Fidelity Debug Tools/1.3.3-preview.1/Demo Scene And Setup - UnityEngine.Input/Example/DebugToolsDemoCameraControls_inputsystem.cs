using UnityEngine;
using Fidelity.DebugTools;

public class DebugToolsDemoCameraControls_inputsystem : MonoBehaviour {
    public float dragSpeed = 0.6f;
    public float movementSpeed = 0.6f;
    private Vector2 moveVector;
    private DebugTools debugTools;
    private SampleInput sampleInput;
    private void Start() {
        sampleInput = new SampleInput();
        sampleInput.Player.Enable();
    }

    void Update() {
        // If this line throws a nullref, the DebugMenu isn't initialized properly. Have you added FIDELITY_DEBUG as a define symbol? Check README.md for other suggestions
        if(!debugTools.IsMenuFocused()) {
            moveVector = sampleInput.Player.Move.ReadValue<Vector2>();
            transform.Translate(new Vector3(moveVector.x * (Time.deltaTime * movementSpeed), 0, moveVector.y * (Time.deltaTime * movementSpeed)));

            if(sampleInput.Player.Fire.IsPressed()) {
                Vector2 lookVector = sampleInput.Player.Look.ReadValue<Vector2>();
                transform.Rotate(-dragSpeed * lookVector.y, dragSpeed * lookVector.x, 0);
                transform.Rotate(0, 0, -transform.eulerAngles.z);
            }
        }

        if (sampleInput.Player.ToggleDebugMenu.WasPressedThisFrame()) {
            debugTools.toggleDebugMenu?.Invoke();
        }

        if (sampleInput.Player.ToggleConsole.WasPressedThisFrame()) {
            debugTools.toggleConsoleMenu?.Invoke();
        }
    }
}
