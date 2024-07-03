using UnityEngine;
using Fidelity.DebugTools;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class DebugCategory : DebugCategoryBase {
    public static DebugCategory Gameplay => new DebugCategory(3, "Gameplay");
    public static DebugCategory General => new DebugCategory(1, "General");

    private DebugCategory(int id, string name) : base(id, name) {
    }
}

public enum DropdownEnum {
    Option1,
    Option2,
    Option3
}



public class DebugToolsSetup : MonoBehaviour {

    [SerializeField]
    private DebugSettings debugSettings;
    private SliderElement sliderElement;
    public PaddleMovement paddleMovementLeft;
    public PaddleMovement paddleMovementRight;
    public BallMovement ballMovement;

    private List<DebugCategoryBase> extraCategories = new() {
        DebugCategory.General,
        DebugCategory.Gameplay
    };
    private DebugTools debugTools;
    private SliderElement paddleSlider;
    private SliderElement ballSlider;
    private void Awake() {
        debugTools = new DebugTools();
        debugTools.InitializeDebugMenu(debugSettings, DebugMenuMode.FlatScreen, extraCategories, transform);
        CreateLocalDebugMenu();
    }

    private void CreateLocalDebugMenu() {

        debugTools.debugMenu.AddCommand("HideDebugMenu", () => { debugTools.toggleDebugMenu?.Invoke(); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand("ToggleLoggerView", () => { debugTools.toggleLoggerMenu?.Invoke(); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand("ToggleConsoleView", () => { debugTools.toggleConsoleMenu?.Invoke(); }, DebugCategory.General, 0);

        debugTools.debugMenu.AddCommand("LogError", () => { Debug.LogError("This is an Error"); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand("LogWarning", () => { Debug.LogWarning("This is a Warning"); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand<float>("RightPaddleSpeed", value => paddleMovementRight.speed = value, DebugCategory.Gameplay, new SliderElement(5,0,20), 0);
        debugTools.debugMenu.AddCommand<float>("LeftPaddleSpeed", value => paddleMovementLeft.speed = value, DebugCategory.Gameplay, new SliderElement(5, 0, 20), 0);
        debugTools.debugMenu.AddCommand<float>("BallSpeed", value => ballMovement.change_speed = value, DebugCategory.Gameplay, new SliderElement(5,0,20), 0);
        // add a dropdown standard enum
        debugTools.debugMenu.AddCommand<DropdownEnum>("DropdownTest", value => Debug.Log(value), DebugCategory.General, new EnumDropDown(typeof(DropdownEnum)));

        // add console command
        debugTools.debugConsole.AddCommand("TestCommand", () => { Debug.Log("Test Command Executed"); }, "Test Command Help Test");
    }

    void Update() {
        debugTools.Tick();
        if(Input.GetKeyDown("`") == true) {
            debugTools.toggleDebugMenu?.Invoke();
        }
    }

    private void OnDestroy() {
        debugTools.Dispose();
    }
}
